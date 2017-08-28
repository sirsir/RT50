module ActiveRecord
  class Migration
    class << self
      # Execute this migration in the named direction
      def migrate(direction)
        return unless respond_to?(direction)

        case direction
          when :up   then announce "migrating"
          when :down then announce "reverting"
        end

        result = nil
        
        begin
          time = Benchmark.measure {
            send("before_#{direction}") if respond_to?("before_#{direction}")
            result = send("#{direction}_without_benchmarks") 
            send("after_#{direction}") if respond_to?("after_#{direction}")
            
            result
            }
        rescue => e
          config = ActiveRecord::Base.configurations[RAILS_ENV]
#          MigrationNotifier.deliver_migrate_exception_notification(@direction, name, e.backtrace)
          
          raise e
        end

        case direction
          when :up   then announce "migrated (%.4fs)" % time.real; write
          when :down then announce "reverted (%.4fs)" % time.real; write
        end

        result
      end
  
      def new_connection
        config = ActiveRecord::Base.configurations[RAILS_ENV]
        adapter_method = "#{config['adapter'] || config[:adapter]}_connection"

        conn = ActiveRecord::Base.send(adapter_method, config)
        
        yield conn if block_given? 
        
        conn
      end
  
      def refresh_partition_view(partition_name, options={})
        defaults={
          :method => "CREATE",
          :field_list => "*",
          :from => "000",
          :to => "255",
        }

        options = defaults.merge(options)
        
        execute "
#{options[:method]} VIEW [#{partition_name}]
AS
#{(options[:from]..options[:to]).collect {|pk| "SELECT #{options[:field_list]} FROM [#{partition_name}_#{pk}]"}.join(" UNION ALL\n")}
        "
      end

      def set_check_point(conn, file_name, data, options={})
        version = get_version_from_file_name(file_name, options)
        
        if get_check_point(conn, file_name, options) then
          conn.update(sql_update_data(version, data))
        else
          conn.insert(sql_insert_new(version, data))
        end
      end
      
      def get_check_point(conn, file_name, options={})
        version = get_version_from_file_name(file_name, options)
        
        conn.select_value(sql_select(version))
      end
      
      def get_version_from_file_name(file_name, options={})
        defaults={
          :sub_version => ""
        }

        options = defaults.merge(options)
        
        version = File.basename(file_name).split('_')[0]
        version = "#{version}/#{options[:sub_version]}" unless options[:sub_version].to_s.empty?
        
        version
      end
      
      def sql_insert_new(version, data)
        "
INSERT INTO [schema_migration_check_points]
  ( [version], [data])
VALUES 
  ( '#{version}'
  , '#{data}')
        "
      end
      
      def sql_update_data(version, data)
        "
UPDATE [schema_migration_check_points]
SET [data] = '#{data}'
WHERE [version] = '#{version}'
        "
      end
      
      def sql_select(version)
        "
SELECT [data]
FROM [schema_migration_check_points]
WHERE [version] = '#{version}'
        "
      end
           
    end
  end
end
