class ChangeVarcharLengthInTLogDat < ActiveRecord::Migration
  def self.up
    change_column "T_LOG_DAT", :PcName, :string, :limit => 60, :null => true
    change_column "T_LOG_DAT", :LineName, :string, :limit => 60, :null => true
    change_column "T_LOG_DAT", :Message, :string, :limit => 255, :null => true
  end

  def self.down
    
    change_column "T_LOG_DAT", :PcName, :string, :limit => 20, :null => true
    change_column "T_LOG_DAT", :LineName, :string, :limit => 20, :null => true
    change_column "T_LOG_DAT", :Message, :string, :limit => 100, :null => true
  end
end
