class AddEntranceFlagToTProcessMst < ActiveRecord::Migration
  def self.up
    add_column "T_PROCESS_MST", :ENTRANCE_FLAG, :boolean, :null => false, :default => false
  end

  def self.down
    remove_column "T_PROCESS_MST", :ENTRANCE_FLAG
  end
end
