class CreateTableTProcessMst < ActiveRecord::Migration
  def self.up
    create_table "T_PROCESS_MST", :id => false, :force => true do |t|
      t.integer "PROCESS_NO", :null => false
      t.string  "PROCESS_NAME",  :limit => 60, :null => false
      t.integer "PROCESS_TIME",  :null => false
    end
    execute sql_create_process_pk
  end

  def self.down
    drop_table "T_PROCESS_MST"
  end

  def self.sql_create_process_pk
    "ALTER TABLE T_PROCESS_MST ADD CONSTRAINT
     PK_T_PROCESS_MST PRIMARY KEY CLUSTERED
      (
        PROCESS_NO ASC
      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]      "
  end
end
