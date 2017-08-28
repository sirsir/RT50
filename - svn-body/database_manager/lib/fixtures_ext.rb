require 'active_record/fixtures'
class Fixtures < (RUBY_VERSION < '1.9' ? YAML::Omap : Hash)
  def self.create_fixtures(fixtures_directory, table_names, class_names = {})
    table_names = [table_names].flatten.map { |n| n.to_s }
    connection  = block_given? ? yield : ActiveRecord::Base.connection

    table_names_to_fetch = table_names.reject { |table_name| fixture_is_cached?(connection, table_name) }

    unless table_names_to_fetch.empty?
      ActiveRecord::Base.silence do
        connection.disable_referential_integrity do
          fixtures_map = {}

          fixtures = table_names_to_fetch.map do |table_name|
            fixtures_map[table_name] = Fixtures.new(connection, File.split(table_name.to_s).last, class_names[table_name.to_sym], File.join(fixtures_directory, table_name.to_s))
          end

          all_loaded_fixtures.update(fixtures_map)

          connection.transaction(:requires_new => true) do
            fixtures.reverse.each { |fixture| fixture.delete_existing_fixtures } unless ENV['APPEND'].upcase == 'TRUE'
            fixtures.each { |fixture| fixture.insert_fixtures }

            # Cap primary key sequences to max(pk).
            if connection.respond_to?(:reset_pk_sequence!)
              table_names.each do |table_name|
                connection.reset_pk_sequence!(table_name)
              end
            end
          end

          cache_fixtures(connection, fixtures_map)
        end
      end
    end
    cached_fixtures(connection, table_names)
  end
  
  def Fixtures.load
    ActiveRecord::Base.establish_connection(Rails.env)
    base_dir = ENV['FIXTURES_PATH'] ? File.join(Rails.root, ENV['FIXTURES_PATH']) : File.join(Rails.root, 'test', 'fixtures')
    fixtures_dir = ENV['FIXTURES_DIR'] ? File.join(base_dir, ENV['FIXTURES_DIR']) : base_dir

    raise  Exception.new("Missing fixture at '#{fixtures_dir}'")  unless File.directory?(fixtures_dir)
    
    (ENV['FIXTURES'] ? ENV['FIXTURES'].split(/,/).map {|f| File.join(fixtures_dir, f) } : Dir.glob(File.join(fixtures_dir, '*.{yml,csv}'))).each do |fixture_file|
      Fixtures.create_fixtures(File.dirname(fixture_file), File.basename(fixture_file, '.*'))
    end
  end
end
