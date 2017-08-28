class ChangePkOfTPaintCellToModelYearSuffixCodeLotNoUnitAndProcess < ActiveRecord::Migration
  def self.up
    drop_table("T_PAINT_CELL")

    create_table  "T_PAINT_CELL", :id => false, :force => true do |t|
      t.string    "MODEL_YEAR",     :limit => 3,  :null => false
      t.string    "SUFFIX_CODE",    :limit => 5,  :null => false
      t.string    "LOT_NO",         :limit => 3,  :null => false
      t.string    "UNIT",           :limit => 3,  :null => false
      t.integer   "PROCESS_NO",                   :null => false
      t.datetime  "PROCESS_RESULT_DATE",          :null => true
    end

    execute sql_create_paint_pk_up
    execute sql_create_production_fk_up
    execute sql_check_production_fk
    execute sql_create_process_fk
    execute sql_check_process_fk
  end

  def self.down
    create_table "T_PAINT_CELL", :id => false, :force => true do |t|
      t.integer "SKIT_NO",   :null => false
      t.integer  "PROCESS_NO",      :null => false
      t.datetime "PROCESS_ON_DATE",     :null => false
      t.datetime "PROCESS_OFF_DATE",    :null => true
    end

    execute sql_create_paint_pk_down

    add_index("T_PAINT_CELL", "PROCESS_NO", :name => "IDX_PROCESS_NO")
    add_index("T_PAINT_CELL", "PROCESS_ON_DATE", :name => "IDX_PROCESS_NO")
    add_index("T_PAINT_CELL", "SKIT_NO", :name => "IDX_PROCESS_NO")

    execute sql_create_process_fk
    execute sql_check_process_fk
  end

  def self.sql_create_paint_pk_up
    "ALTER TABLE T_PAINT_CELL ADD CONSTRAINT PK_T_PAINT_CELL PRIMARY KEY NONCLUSTERED
      (
        MODEL_YEAR ASC,
        SUFFIX_CODE ASC,
        LOT_NO ASC,
        UNIT ASC,
        PROCESS_NO ASC

      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]"
  end



  def self.sql_create_paint_pk_down
    "ALTER TABLE T_PAINT_CELL ADD CONSTRAINT PK_T_PAINT_CELL PRIMARY KEY NONCLUSTERED
      (
        PROCESS_NO ASC,
        PROCESS_ON_DATE ASC,
        SKIT_NO ASC

      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]"
  end

  def self.sql_create_production_fk_up
    "
      ALTER TABLE [T_PAINT_CELL] WITH CHECK ADD CONSTRAINT [FK_T_PAINT_CELL_MODEL_YEAR_SUFFIX_CODE_LOT_UNIT]
      FOREIGN KEY ([MODEL_YEAR],[SUFFIX_CODE],[LOT_NO],[UNIT])
      REFERENCES [T_PRODUCTION_DAT] ([MODEL_YEAR],[SUFFIX_CODE],[LOT_NO],[UNIT])
    "
  end

  def self.sql_check_production_fk
    "
      ALTER TABLE [T_PAINT_CELL] CHECK CONSTRAINT [FK_T_PAINT_CELL_MODEL_YEAR_SUFFIX_CODE_LOT_UNIT]
    "
  end

  def self.sql_create_process_fk
    "
    ALTER TABLE [T_PAINT_CELL]  WITH CHECK ADD  CONSTRAINT [FK_T_PAINT_CELL_PROCESS_NO] FOREIGN KEY([PROCESS_NO])
      REFERENCES [T_PROCESS_MST] ([PROCESS_NO])
    "
  end

  def self.sql_check_process_fk
    "ALTER TABLE [T_PAINT_CELL] CHECK CONSTRAINT [FK_T_PAINT_CELL_PROCESS_NO]"
  end
end
