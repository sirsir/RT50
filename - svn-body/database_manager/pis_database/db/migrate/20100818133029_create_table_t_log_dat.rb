class CreateTableTLogDat < ActiveRecord::Migration
  def self.up
    create_table "T_LOG_DAT", :id => false, :force => true do |t|
      t.integer  "LogType", :limit => 4,   :null => false
      t.string   "PcName",  :limit => 20
      t.datetime "OccDate",                :null => false
      t.string   "Message", :limit => 100
    end
  end

  def self.down
    drop_table(:T_LOG_DAT)
  end
end
