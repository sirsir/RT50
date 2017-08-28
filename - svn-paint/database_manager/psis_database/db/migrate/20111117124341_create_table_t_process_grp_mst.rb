class CreateTableTProcessGrpMst < ActiveRecord::Migration
  def self.up
    create_table "T_PROCESS_GROUP_MST", :primary_key => "PROCESS_GROUP_ID", :force => true do |t|
      t.integer  "PROCESS_GROUP_SEQ", :null => false
      t.string  "PROCESS_GROUP_NAME", :limit => 20, :null => false
    end

    add_index("T_PROCESS_GROUP_MST", :PROCESS_GROUP_SEQ, :unique => true, :name => 'IDX_PROCESS_GROUP_SEQ')
    execute sql_add_group_records
  end

  def self.down
    drop_table "T_PROCESS_GROUP_MST"
  end

  def self.sql_add_group_records
    "insert into T_PROCESS_GROUP_MST
(PROCESS_GROUP_SEQ, PROCESS_GROUP_NAME) values(1,'ED')
insert into T_PROCESS_GROUP_MST
(PROCESS_GROUP_SEQ, PROCESS_GROUP_NAME) values(2,'PRIMER')
insert into T_PROCESS_GROUP_MST
(PROCESS_GROUP_SEQ, PROCESS_GROUP_NAME) values(3,'TOP COAT')
insert into T_PROCESS_GROUP_MST
(PROCESS_GROUP_SEQ, PROCESS_GROUP_NAME) values(4,'UA PBR')
insert into T_PROCESS_GROUP_MST
(PROCESS_GROUP_SEQ, PROCESS_GROUP_NAME) values(99,'OTHERS')"
  end
end
