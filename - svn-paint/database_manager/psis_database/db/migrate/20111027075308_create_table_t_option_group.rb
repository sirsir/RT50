class CreateTableTOptionGroup < ActiveRecord::Migration
  def self.up
    create_table "T_OPTION_GROUP_MST", :primary_key => "OPTION_GROUP_ID", :force => true do |t|
      t.integer "OPTION_GROUP_TYPE", :null => false
      t.string  "OPTION_GROUP_DESCR", :limit => 15, :null => false
      t.integer "OPTION_GROUP_SEQ",  :null => false
    end
  end

  def self.down
    drop_table "T_OPTION_GROUP_MST"
  end
end
