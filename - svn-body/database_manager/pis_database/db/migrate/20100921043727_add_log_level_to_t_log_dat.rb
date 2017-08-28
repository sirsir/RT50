class AddLogLevelToTLogDat < ActiveRecord::Migration
  def self.up
    add_column "T_LOG_DAT", :LogLevel, :integer, :null => false, :default => 0
  end

  def self.down
    remove_column "T_LOG_DAT", :LogLevel
  end
end
