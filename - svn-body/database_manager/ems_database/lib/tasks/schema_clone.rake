namespace :db do
  
  namespace :schema do
    desc "Clone the specified table's schema to the desired database"
    task :clone => :environment do
      require 'active_record/schema_dumper'

      database = ENV["D"] ? ENV["D"] : nil
      raise "\tD=database_name\t\t\tDatabase is required" unless database

      table = ENV["T"] ? ENV["T"] : nil
      raise "\tT=table_name\t\t\tTable is required" unless table

      options = {
        :dsn => ENV["S"] ? ENV["S"] : nil,
        :host => ENV["H"] ? ENV["H"] : nil,
        :username => ENV["U"] ? ENV["P"] : nil,
        :password => ENV["P"] ? ENV["P"] : nil
      }
      
      ActiveRecord::SchemaDumper.clone(database, table, options)
    end
  end
end
