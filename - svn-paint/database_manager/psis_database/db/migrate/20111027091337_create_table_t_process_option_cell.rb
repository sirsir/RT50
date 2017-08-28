class CreateTableTProcessOptionCell < ActiveRecord::Migration
  def self.up
    create_table "T_PROCESS_OPTION_CELL", :id => false, :force => true do |t|
      t.integer "PROCESS_NO", :null => false
      t.integer "OPTION_ID", :null => false
      t.boolean "IS_USED",  :null => false
    end

    execute sql_create_pk_t_process_option_cell

    execute sql_create_fk_t_process_option_cell_process_no_with_delete_cascade
    execute sql_check_fk_t_process_option_cell_process_no

    execute sql_create_fk_t_process_option_cell_option_id_with_delete_cascade
    execute sql_check_fk_t_process_option_cell_option_id
  end

  def self.down
    drop_table "T_PROCESS_OPTION_CELL"
  end

  def self.sql_create_pk_t_process_option_cell
      "ALTER TABLE [T_PROCESS_OPTION_CELL] ADD CONSTRAINT
       PK_T_PROCESS_OPTION_CELL PRIMARY KEY CLUSTERED
       (
          PROCESS_NO ASC,
          OPTION_ID ASC
       ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
  end

  def self.sql_create_fk_t_process_option_cell_process_no_with_delete_cascade
    "ALTER TABLE dbo.T_PROCESS_OPTION_CELL ADD CONSTRAINT
      FK_T_PROCESS_OPTION_CELL_PROCESS_NO FOREIGN KEY
      (
        PROCESS_NO
      ) REFERENCES dbo.T_PROCESS_MST
      (
      PROCESS_NO
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_fk_t_process_option_cell_process_no
    "ALTER TABLE [T_PROCESS_OPTION_CELL] CHECK CONSTRAINT [FK_T_PROCESS_OPTION_CELL_PROCESS_NO]"
  end

  def self.sql_create_fk_t_process_option_cell_option_id_with_delete_cascade
    "ALTER TABLE dbo.T_PROCESS_OPTION_CELL ADD CONSTRAINT
      FK_T_PROCESS_OPTION_CELL_OPTION_ID FOREIGN KEY
      (
        OPTION_ID
      ) REFERENCES dbo.T_OPTION_MST
      (
      OPTION_ID
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_fk_t_process_option_cell_option_id
    "ALTER TABLE [T_PROCESS_OPTION_CELL] CHECK CONSTRAINT [FK_T_PROCESS_OPTION_CELL_OPTION_ID]"
  end
end
