class RemoveParameterTables < ActiveRecord::Migration
  def self.up
    drop_table("T_PARAMETER_CELL")
    drop_table("T_PARAMETER_ROW")
  end

  def self.down
    create_table "T_PARAMETER_CELL", :id => false, :force => true do |t|
      t.integer "PARAMETER_ROW_ID",   :null => false
      t.integer "PROCESS_NO",         :null => false
      t.string  "PARAMETER",          :null => false, :limit => 10
    end
    execute sql_create_parameter_cell_pk_up

    create_table "T_PARAMETER_ROW", :primary_key => "PARAMETER_ROW_ID", :force => true do |t|
      t.string  "MODEL_YEAR_PATTERN",   :null => false, :limit => 3
      t.string  "SUFFIX_CODE_PATTERN",  :null => false, :limit => 5
    end

    execute sql_create_parameter_cell_fk_to_row_up
    execute sql_check_parameter_cell_fk_to_row
    execute sql_create_parameter_cell_fk_to_process
    execute sql_check_parameter_cell_fk_to_process
  end

  def self.sql_create_parameter_cell_pk_up
    "ALTER TABLE T_PARAMETER_CELL ADD CONSTRAINT
       PK_T_PARAMETER_CELL PRIMARY KEY CLUSTERED
      (
        PARAMETER_ROW_ID ASC,
        PROCESS_NO ASC
      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
  end

  def self.sql_create_parameter_cell_fk_to_row_up
    "ALTER TABLE dbo.T_PARAMETER_CELL WITH CHECK ADD CONSTRAINT
      FK_T_PARAMETER_CELL_PARAMETER_ROW_ID FOREIGN KEY
      (
      PARAMETER_ROW_ID
      ) REFERENCES dbo.T_PARAMETER_ROW
      (
      PARAMETER_ROW_ID
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_parameter_cell_fk_to_row
    "ALTER TABLE [T_PARAMETER_CELL] CHECK CONSTRAINT [FK_T_PARAMETER_CELL_PARAMETER_ROW_ID]"
  end

  def self.sql_create_parameter_cell_fk_to_process
    "ALTER TABLE dbo.T_PARAMETER_CELL WITH CHECK ADD CONSTRAINT
      FK_T_PARAMETER_CELL_PROCESS_NO FOREIGN KEY
      (
      PROCESS_NO
      ) REFERENCES dbo.T_PROCESS_MST
      (
      PROCESS_NO
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_parameter_cell_fk_to_process
    "ALTER TABLE [T_PARAMETER_CELL] CHECK CONSTRAINT [FK_T_PARAMETER_CELL_PROCESS_NO]"
  end
end
