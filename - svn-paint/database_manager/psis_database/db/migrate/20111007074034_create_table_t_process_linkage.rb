class CreateTableTProcessLinkage < ActiveRecord::Migration
  def self.up
    create_table "T_PROCESS_LINKAGE", :id => false, :force => true do |t|
      t.integer "FROM_PROCESS_NO",  :null => false
      t.integer "TO_PROCESS_NO",    :null => false
    end

    execute sql_create_process_linkage_pk
  end

  def self.down
    drop_table("T_PROCESS_LINKAGE")
  end

  def self.sql_create_process_linkage_pk
    "
      ALTER TABLE [T_PROCESS_LINKAGE] ADD CONSTRAINT
      PK_T_PROCESS_LINKAGE PRIMARY KEY CLUSTERED
      (
          FROM_PROCESS_NO ASC,
          TO_PROCESS_NO ASC
      ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    "
  end
end
