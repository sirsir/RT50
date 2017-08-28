class MoveProcessTProcessMstOnlineFlagToTPlcMstPlcOnlineFlag < ActiveRecord::Migration
  def self.up
    remove_column "T_PROCESS_MST", :PROCESS_ONLINE_FLAG
    add_column "T_PLC_MST", :PLC_ONLINE_FLAG, :boolean, :null => false, :default => true
  end

  def self.down
    remove_column "T_PLC_MST", :PLC_ONLINE_FLAG
    add_column "T_PROCESS_MST", :PROCESS_ONLINE_FLAG, :boolean, :null => false, :default => true
  end
end
