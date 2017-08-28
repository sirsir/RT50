class CreateTableTMessageMst < ActiveRecord::Migration
  def self.up
    create_table "T_MESSAGE_MST", :id =>false, :force => true do |t|
      t.string "LOG_CODE",  :limit => 15, :null => false
      t.string "LOG_MESSAGE", :limit => 255, :null => false
    end
    execute sql_create_message_pk
  end

  def self.down
    drop_table("T_MESSAGE_MST")
  end

  def self.sql_create_message_pk
    "ALTER TABLE T_MESSAGE_MST ADD CONSTRAINT
       PK_T_MESSAGE_MST PRIMARY KEY NONCLUSTERED
      (
        LOG_CODE ASC
      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
  end
end
