class CreateTableTLogDat < ActiveRecord::Migration
  def self.up
    create_table "T_LOG_DAT", :primary_key => "LOG_ID", :force => true do |t|
      t.integer "LOG_TYPE",   :null => false
      t.integer "LOG_LEVEL",  :null => false
      t.string  "PC_NAME",    :null => true
      t.date    "OCC_DATE",   :null => false
      t.string  "LOG_CODE",   :limit => 15,   :null => false
      t.string  "MESSAGE",    :limit => 255,  :null => false
      t.integer "PROCESS_NO", :null => true
    end
  end

  def self.down
    drop_table "T_LOG_DAT"
  end
end
