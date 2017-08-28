require File.join(File.dirname(__FILE__), '..\..\..\lib\fixtures_ext')
migration_version = File.basename(__FILE__).split('_')[0]
ENV['APPEND'] = 'false'
ENV['FIXTURES_PATH'] = File.join('db/fixtures', migration_version)

class LoadDataToTLineMst < ActiveRecord::Migration
  def self.up
    Fixtures.load
  end

  def self.down
    delete "DELETE FROM [T_Line_MST]"
  end
end
