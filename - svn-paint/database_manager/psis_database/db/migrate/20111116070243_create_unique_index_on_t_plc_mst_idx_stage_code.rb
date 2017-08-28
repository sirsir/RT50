class CreateUniqueIndexOnTPlcMstIdxStageCode < ActiveRecord::Migration
  def self.up
    add_index("T_PLC_MST", :STAGE_CODE, :unique => true, :name => "IDX_STAGE_CODE")
  end

  def self.down
    remove_index "T_PLC_MST", :name => "IDX_STAGE_CODE"
  end
end
