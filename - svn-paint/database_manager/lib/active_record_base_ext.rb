
module ActiveRecord
  class Base
    class << self # Class methods

      unless method_defined?(:sqlserver_connection_base)
        alias_method :sqlserver_connection_base, :sqlserver_connection
      end
    
      def sqlserver_connection(config) #:nodoc:
        conn = sqlserver_connection_base(config)
        
        switch_to_rails_env_database(conn, config)
        
        conn
      end

      def switch_to_rails_env_database(conn, config)
        config.symbolize_keys!

        # try to swith to the actual db, if it has been created
        begin
          conn.execute "USE #{config[:database]}"
        rescue
        end if config[:mode] == "ODBC"
      end

      def cache_instance=(value)
        @@cache ||= {}
        @@cache[name] = (value) ? {} : nil
      end

      unless method_defined?(:find_uncached)
        alias_method :find_uncached, :find
      end

      def find(*args)
        args_org = args.clone
        args.extract_options!

        case args.first
          when :first then find_uncached(*args_org)
          when :last  then find_uncached(*args_org)
          when :all   then find_uncached(*args_org)
          else
             find_uncached(*args_org)
        end
      end

     private
     
      def extract_id(ids)
        expects_array = ids.first.kind_of?(Array)
        return nil if expects_array && ids.first.empty?

        ids = ids.flatten.compact.uniq

        (ids.size == 1) ? ids.first : nil
      end
        
      def create_time_zone_conversion_attribute?(name, column)
        skip_time_zone_conversion_for_attributes ||= []
        time_zone_aware_attributes && !skip_time_zone_conversion_for_attributes.include?(name.to_sym) && [:datetime, :timestamp].include?(column.type)
      end

    end
  end
end


