class AddColumnLineNameToTLogDat < ActiveRecord::Migration
  def self.up
    add_column "T_LOG_DAT", :LineName, :string, :limit => 20, :null => true
  end

  def self.down
    remove_column "T_LOG_DAT", :LineName
  end
end
