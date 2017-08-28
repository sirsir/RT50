class AddPlcRelatedColumnToTProcessMst < ActiveRecord::Migration
  def self.up
    add_column "T_PROCESS_MST", :PROCESS_ONLINE_FLAG,  :boolean, :default => true, :null => false
    add_column "T_PROCESS_MST", :PROCESS_TYPE,         :integer, :default => 0, :null => false
    add_column "T_PROCESS_MST", :PLC_NET,              :integer, :default => 0, :null => false
    add_column "T_PROCESS_MST", :PLC_NODE,             :integer, :default => 0, :null => false
    add_column "T_PROCESS_MST", :PLC_UNIT,             :integer, :default => 0, :null => false
    add_column "T_PROCESS_MST", :READ_DM,              :integer, :default => 0, :null => false
    add_column "T_PROCESS_MST", :WRITE_DATA_DM,        :integer, :default => 0, :null => false
    add_column "T_PROCESS_MST", :WRITE_STATUS_DM,      :integer, :default => 0, :null => false

  end

  def self.down
    remove_column("T_PROCESS_MST", :PROCESS_ONLINE_FLAG,
      :PROCESS_TYPE, :PLC_NET, :PLC_NODE, :PLC_UNIT, :READ_DM, :WRITE_DATA_DM,:WRITE_STATUS_DM)
  end
end
