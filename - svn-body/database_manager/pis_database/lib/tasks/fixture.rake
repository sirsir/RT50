require 'find'
require 'ftools'

namespace :db do
  namespace :fixtures do
    desc 'Dumps the specified models into db/fixtures.'
    task :dump => :environment do
      table_name = ENV['table_name'].to_s
      version = ENV['version'].to_s

      raise("
Usage:
rake db:fixtures:dump table_name={table name} version={version}
        ") if table_name.empty? || version.empty?

      conn = ActiveRecord::Base.connection

      columns = conn.columns(table_name)
      column_names = columns.collect{|c| c.name }.join(", ")

      rows = conn.select_rows(" SELECT #{column_names} FROM #{table_name}")

      formatted, increment, tab = '', 1, '  '
      yml = rows.collect { |r|
        "
#{table_name}_#{rows.index(r).to_s}:
#{columns.collect{|c| "#{tab}#{c.name}: #{r[columns.index(c)]}" }.join("\n") }
"
      }.join("")

      fixture_version = RAILS_ROOT + "/db/fixtures/#{version}"

      File.makedirs(fixture_version) unless File.exist?(fixture_version)
      
      fixture_file = "#{fixture_version}/#{table_name}.yml"

      File.exists?(fixture_file) ? File.delete(fixture_file) : nil
      File.open(fixture_file, 'w') {|f| f << yml}
    end
  end
end
