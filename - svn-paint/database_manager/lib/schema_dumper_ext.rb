module ActiveRecord
  class SchemaDumper #:nodoc:
    def self.dump_table(table_name, connection=ActiveRecord::Base.connection, stream=STDOUT)
      new(connection).dump_table(table_name, stream)
      stream
    end

    def dump_table(table_name, stream)
      header(stream)

      @connection.tables.sort.each do |tbl|
        table(tbl, stream) if tbl.inspect == table_name.inspect
      end
        
      trailer(stream)
      stream
    end

    def self.clone(database, table_name, options={})
      defaults = {
        :dsn => nil,
        :host => nil,
        :username => nil,
        :password => nil
      }

      options = defaults.merge(options)

      file_name = "#{RAILS_ROOT}/db/#{table_name}_schema.rb"

      File.open(file_name, "w") do |file|
        dump_table(table_name, ActiveRecord::Base.connection, file)
      end

      content = IO.read(file_name)

      # Remove id from the primary key
      content.gsub!(", :force => true do |t|", ", :id => false, :force => true do |t|
    t.integer  \"id\",               :null => false
        ")

      File.open(file_name, "w") do |file|
        file.print content
      end

      config = ActiveRecord::Base.configurations[RAILS_ENV]

      new_config = config.merge({})

      new_config['dsn']     = options[:dsn]     if options[:dsn]
      new_config['host']     = options[:host]     if options[:host]
      new_config['username'] = options[:user]     if options[:user]
      new_config['password'] = options[:password] if options[:password]
      new_config['database'] = "#{database}_#{RAILS_ENV}"
      
      # Create cloned table
      ActiveRecord::Base.establish_connection(new_config)

      load(file_name)

      conn = ActiveRecord::Base.connection

      conn.add_index(table_name, [:id], :name=>"IX_#{table_name}_id", :unique=>true, :clustered=>true)

      File.delete(file_name)

      # Return to original connection
      ActiveRecord::Base.establish_connection(config)

      conn = ActiveRecord::Base.connection

      column_name = nil

      conn.columns(table_name).each do |c|
        next if c.name == "id"
        column_name = c.name
        break
      end
      
      conn.update "UPDATE [#{table_name}] SET [#{column_name}] = [#{column_name}]"
    end
  end
end
