class RemovePlcRelatedColumnsFromTProcessMst < ActiveRecord::Migration
  def self.up
    remove_column("T_PROCESS_MST", :STAGE_CODE)
    remove_column("T_PROCESS_MST", :PLC_NET)
    remove_column("T_PROCESS_MST", :PLC_NODE)
    remove_column("T_PROCESS_MST", :PLC_UNIT)
    remove_column("T_PROCESS_MST", :READ_DM)
    remove_column("T_PROCESS_MST", :WRITE_DATA_DM)
    remove_column("T_PROCESS_MST", :WRITE_STATUS_DM)
  end

  def self.down
    add_column("T_PROCESS_MST", :STAGE_CODE, :integer, :default => 0, :null => false)
    add_column("T_PROCESS_MST", :PLC_NET, :integer, :default => 0, :null => false)
    add_column("T_PROCESS_MST", :PLC_NODE, :integer, :default => 0, :null => false)
    add_column("T_PROCESS_MST", :PLC_UNIT, :integer, :default => 0, :null => false)
    add_column("T_PROCESS_MST", :READ_DM, :integer, :default => 0, :null => false)
    add_column("T_PROCESS_MST", :WRITE_DATA_DM, :integer, :default => 0, :null => false)
    add_column("T_PROCESS_MST", :WRITE_STATUS_DM, :integer, :default => 0, :null => false)

    change_column("T_PROCESS_MST", :STAGE_CODE, :integer, :null => false)
    change_column("T_PROCESS_MST", :PLC_NET, :integer, :null => false)
    change_column("T_PROCESS_MST", :PLC_NODE, :integer, :null => false)
    change_column("T_PROCESS_MST", :PLC_UNIT, :integer, :null => false)
    change_column("T_PROCESS_MST", :READ_DM, :integer, :null => false)
    change_column("T_PROCESS_MST", :WRITE_DATA_DM, :integer, :null => false)
    change_column("T_PROCESS_MST", :WRITE_STATUS_DM, :integer, :null => false)
  end
end
