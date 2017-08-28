# encoding: binary

module ActiveRecord
  module ConnectionAdapters #:nodoc:
    class MysqlAdapter < AbstractAdapter
      def native_database_types #:nodoc:
        NATIVE_DATABASE_TYPES.merge(
          {
            :yaml        => { :name => "text" }
          }
        )
      end
    end #class MysqlAdapter < AbstractAdapter

    class PostgreSQLAdapter < AbstractAdapter
      def native_database_types #:nodoc:
        NATIVE_DATABASE_TYPES.merge(
          {
            :yaml        => { :name => "text" }
          }
        )
      end
    end #class PostgreSQLAdapter < AbstractAdapter

    class SQLiteAdapter < AbstractAdapter

      unless method_defined?(:org_native_database_types)
        alias_method :org_native_database_types, :native_database_types
      end

      def native_database_types #:nodoc:
        org_native_database_types.merge(
          {
            :yaml        => { :name => "text" }
          }
        )
      end
    end #class SQLiteAdapter < AbstractAdapter

    class SQLServerAdapter < AbstractAdapter

      unless method_defined?(:org_native_database_types)
        alias_method :org_native_database_types, :native_database_types
      end

      def native_database_types
        org_native_database_types.merge(
          {
            :integer      => { :name => "int"},
            :float        => { :name => "float"},
            :yaml        => { :name => "text" }
          }
        )
      end
  
      def validates_schema_of(system, options={})
        if options.is_a?(Array)
          options.each{|o| validates_schema_of(system, o)}
        else
          defaults = {
            :version => "",
            :server => "",
            :up => true
          }

          options = defaults.merge(options)

          database_name = "[#{system}_#{RAILS_ENV}]." unless system.to_s.empty?

          database_name = "[#{options[:server]}].#{database_name}" unless options[:server].to_s.empty?

          version_exists = Base.connection.select_values("SELECT version FROM #{database_name}dbo.#{Migrator.schema_migrations_table_name}").include?(options[:version])

          if options[:up]
            raise "
Migration version missing on #{database_name.gsub(".","")}.
Please execute...

pushd ..\\#{system}_database
rake db:migrate:up RAILS_ENV=#{RAILS_ENV} version=#{options[:version]}
popd
            " unless version_exists
          else
            raise "
Reversed migrating version required on #{database_name.gsub(".","")}.
Please execute...

pushd ..\\#{system}_database
rake db:migrate:down RAILS_ENV=#{RAILS_ENV} version=#{options[:version]}
popd
            " if version_exists
          end
        end
      end

      def validates_trigger_of(table_name, trigger_name)
        table_name = unqualify_table_name(table_name)
        trigger_name = unqualify_table_name(trigger_name)

        raise "Trigger #{trigger_name} on table #{table_name} is required" unless trigger_exists?(table_name, trigger_name)
      end

      def index_name_length
        128
      end
      
      # Adds a new index to the table.  +column_name+ can be a single Symbol, or
      # an Array of Symbols.
      #
      # The index will be named after the table and the first column name,
      # unless you pass <tt>:name</tt> as an option.
      #
      # When creating an index on multiple columns, the first column is used as a name
      # for the index. For example, when you specify an index on two columns
      # [<tt>:first</tt>, <tt>:last</tt>], the DBMS creates an index for both columns as well as an
      # index for the first column <tt>:first</tt>. Using just the first name for this index
      # makes sense, because you will never have to create a singular index with this
      # name.
      #
      # ===== Examples
      #
      # ====== Creating a simple index
      #  add_index(:suppliers, :name)
      # generates
      #  CREATE NONCLUSTERED INDEX suppliers_name_index ON suppliers(name) ON [PRIMER]
      #
      # ====== Creating a unique index
      #  add_index(:accounts, [:branch_id, :party_id], :unique => true)
      # generates
      #  CREATE UNIQUE NONCLUSTERED INDEX accounts_branch_id_party_id_index ON accounts(branch_id, party_id) ON [PRIMER]
      #
      # ====== Creating a clustered index
      #  add_index(:accounts, [:branch_id, :party_id], :clustered => true)
      # generates
      #  CREATE CLUSTERED INDEX accounts_branch_id_party_id_index ON accounts(branch_id, party_id) ON [PRIMER]
      #
      # ====== Creating a named index
      #  add_index(:accounts, [:branch_id, :party_id], :unique => true, :name => 'by_branch_party')
      # generates
      #  CREATE UNIQUE NONCLUSTERED INDEX by_branch_party ON accounts(branch_id, party_id) ON [PRIMER]
      #
      # ====== Creating on a specified FileGroup
      #  add_index(:accounts, [:branch_id, :party_id], :name => 'by_branch_party', :file_group => 'SECONDARY')
      # generates
      #  CREATE NONCLUSTERED INDEX by_branch_party ON accounts(branch_id, party_id) ON [SECONDARY]
      #
      # ====== Creating an index with specific key length
      #  add_index(:accounts, :name, :name => 'by_name', :length => 10)
      # generates
      #  CREATE NONCLUSTERED INDEX by_name ON accounts(name(10)) ON [PRIMER]
      #
      #  add_index(:accounts, [:name, :surname], :name => 'by_name_surname', :length => {:name => 10, :surname => 15})
      # generates
      #  CREATE NONCLUSTERED INDEX by_name_surname ON accounts(name(10), surname(15)) ON [PRIMER]
      #
      # Note: SQLite doesn't support index length
      def add_index(table_name, column_name, options = {})
        column_names = Array(column_name)
        index_name   = index_name(table_name, :column => column_names)
        
        index_cluster = index_with_options = ""
        
        index_file_group  = ""

        if Hash === options # legacy support, since this param was a string
          index_type = options[:unique] ? "UNIQUE" : ""
          index_name = options[:name] || index_name
          
          index_cluster = options[:clustered] ? "CLUSTERED" : "NONCLUSTERED"
          
          with_options = []
          with_options << "STATISTICS_NORECOMPUTE = #{options[:with_statistics_norecompute] ? 'ON' : 'OFF'}"
          with_options << "IGNORE_DUP_KEY = #{options[:with_ignore_dup_key] ? 'ON' : 'OFF'}"
          with_options << "ALLOW_ROW_LOCKS = #{options[:with_allow_row_locks] ? 'ON' : 'OFF'}"
          with_options << "ALLOW_PAGE_LOCKS = #{options[:with_allow_page_locks] ? 'ON' : 'OFF'}"
          
          index_with_options = "WITH(#{with_options.join(", ")})"
            
          index_file_group =  "ON [#{options[:file_group]}]" if options[:file_group]
        else
          index_type = options
        end

        if index_name.length > index_name_length
          @logger.warn("Index name '#{index_name}' on table '#{table_name}' is too long; the limit is #{index_name_length} characters. Skipping.")
          return
        end
        
        if index_exists?(table_name, index_name, false)
          @logger.warn("Index name '#{index_name}' on table '#{table_name}' already exists. Skipping.")
          return
        end
        quoted_column_names = quoted_columns_for_index(column_names, options).join(", ")

        execute "CREATE #{index_type} #{index_cluster} INDEX #{quote_column_name(index_name)} ON #{quote_table_name(table_name)} (#{quoted_column_names}) #{index_with_options} #{index_file_group}"
      end

      # Verify the existence of a trigger.
      def trigger_exists?(table_name, trigger_name)
        triggers(table_name).detect { |i| i.name == trigger_name }
      end

      def triggers(table_name, name = nil)
        unquoted_table_name = unqualify_table_name(table_name)
        select("EXEC sp_helptrigger #{quote_table_name(unquoted_table_name)}",name).inject([]) do |triggeres,trigger|
          name          = trigger['trigger_name']
          on_update     = trigger['isupdate'].to_i == 1
          on_delete     = trigger['isdelete'].to_i == 1
          on_insert     = trigger['isinsert'].to_i == 1
          is_after      = trigger['isafter'].to_i == 1
          is_instead_of = trigger['isinsteadof'].to_i == 1

          triggeres << TriggerDefinition.new(table_name, name, on_update, on_delete, on_insert, is_after, is_instead_of)
        end
      end
    end #class SQLServerAdapter < AbstractAdapter

    class SQLServerColumn < Column 
      def initialize(name, default, sql_type = nil, null = true, sqlserver_options = {})
        @sqlserver_options = sqlserver_options
        sql_type = "yaml" if sql_type == "text" and sqlserver_options[:length] == "16"
        super(name, default, sql_type, null)
      end
    end #class SQLServerColumn < Column

    class Column

      unless method_defined?(:org_simplified_type)
        alias_method :org_simplified_type, :simplified_type
      end

      def simplified_type(field_type)
        org_simplified_type(field_type) or
          case field_type
            when /yaml/i
              :yaml
          end
      end

      unless method_defined?(:org_text?)
        alias_method :org_text?, :text?
      end

      def text?
        org_text? || type == :yaml
      end
    end #class Column

    class TriggerDefinition < Struct.new(:table_name, :name, :on_update, :on_delete, :on_insert, :is_after, :is_instead_of) #:nodoc:
    end

  end #module ConnectionAdapters
end #module ActiveRecord

