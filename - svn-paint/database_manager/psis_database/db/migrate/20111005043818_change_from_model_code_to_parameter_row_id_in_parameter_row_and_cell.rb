class ChangeFromModelCodeToParameterRowIdInParameterRowAndCell < ActiveRecord::Migration
  def self.up
    drop_table("T_PARAMETER_CELL")
    create_table "T_PARAMETER_CELL", :id => false, :force => true do |t|
      t.integer "PARAMETER_ROW_ID",   :null => false
      t.integer "PROCESS_NO",         :null => false
      t.string  "PARAMETER",          :null => false, :limit => 10
    end
    execute sql_create_parameter_cell_pk_up

    drop_table("T_PARAMETER_ROW")
    create_table "T_PARAMETER_ROW", :primary_key => "PARAMETER_ROW_ID", :force => true do |t|
      t.string  "MODEL_YEAR_PATTERN",   :null => false, :limit => 3
      t.string  "SUFFIX_CODE_PATTERN",  :null => false, :limit => 5
    end 

    execute sql_create_parameter_cell_fk_to_row_up
    execute sql_check_parameter_cell_fk_to_row
    execute sql_create_parameter_cell_fk_to_process
    execute sql_check_parameter_cell_fk_to_process
  end

  def self.down
    drop_table("T_PARAMETER_CELL")
    create_table "T_PARAMETER_CELL", :id => false, :force => true do |t|
      t.string  "MODEL_CODE",     :limit => 8, :null => false
      t.integer "PROCESS_NO",     :null => false
      t.string  "PARAMETER",      :limit => 10, :null =>false
    end
    execute sql_create_parameter_cell_pk_down

    drop_table("T_PARAMETER_ROW")
    create_table "T_PARAMETER_ROW", :id => false, :force => true do |t|
      t.string "MODEL_CODE",  :limit => 8, :null => false
      t.string "MODEL_YEAR",  :limit => 3, :null => false
      t.string "SUFFIX_CODE", :limit => 5, :null => false
    end
    execute sql_create_parameter_row_pk_down

    execute sql_create_parameter_cell_fk_to_row_down
    execute sql_check_parameter_cell_fk_to_row_down
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
    "
    ALTER TABLE [T_PARAMETER_CELL]  WITH CHECK ADD  CONSTRAINT [FK_T_PARAMETER_CELL_PARAMETER_ROW_ID] FOREIGN KEY([PARAMETER_ROW_ID])
      REFERENCES [T_PARAMETER_ROW] ([PARAMETER_ROW_ID])
    "
  end

  def self.sql_check_parameter_cell_fk_to_row
    "ALTER TABLE [T_PARAMETER_CELL] CHECK CONSTRAINT [FK_T_PARAMETER_CELL_PARAMETER_ROW_ID]"
  end

  def self.sql_create_parameter_cell_fk_to_process
    "
    ALTER TABLE [T_PARAMETER_CELL]  WITH CHECK ADD  CONSTRAINT [FK_T_PARAMETER_CELL_PROCESS_NO] FOREIGN KEY([PROCESS_NO])
      REFERENCES [T_PROCESS_MST] ([PROCESS_NO])
    "
  end

  def self.sql_check_parameter_cell_fk_to_process
    "ALTER TABLE [T_PARAMETER_CELL] CHECK CONSTRAINT [FK_T_PARAMETER_CELL_PROCESS_NO]"
  end

  def self.sql_create_parameter_cell_pk_down
    "ALTER TABLE [T_PARAMETER_CELL] ADD CONSTRAINT
     PK_T_PARAMETER_CELL PRIMARY KEY CLUSTERED
      (
        MODEL_CODE ASC,
        PROCESS_NO ASC
      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
  end

  def self.sql_create_parameter_row_pk_down
    "ALTER TABLE [T_PARAMETER_ROW] ADD CONSTRAINT
    PK_T_PARAMETER_ROW PRIMARY KEY CLUSTERED
    (
      MODEL_CODE ASC
    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
  end

  def self.sql_create_parameter_cell_fk_to_row_down
    "
    ALTER TABLE [T_PARAMETER_CELL]  WITH CHECK ADD  CONSTRAINT [FK_T_PARAMETER_CELL_MODEL_CODE] FOREIGN KEY([MODEL_CODE])
      REFERENCES [T_PARAMETER_ROW] ([MODEL_CODE])
    "
  end

  def self.sql_check_parameter_cell_fk_to_row_down
    "ALTER TABLE [T_PARAMETER_CELL] CHECK CONSTRAINT [FK_T_PARAMETER_CELL_MODEL_CODE]"
  end
end
