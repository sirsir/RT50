class ChangePkOfTWbsDatToModelYearSuffixCodeLotNoUnitAndLane < ActiveRecord::Migration
  def self.up
    drop_table("T_WBS_DAT")

    create_table "T_WBS_DAT", :id => false, :force => true do |t|
      t.string    "MODEL_YEAR",     :limit => 3,  :null => false
      t.string    "SUFFIX_CODE",    :limit => 5,  :null => false
      t.string    "LOT_NO",         :limit => 3,  :null => false
      t.string    "UNIT",           :limit => 3,  :null => false
      t.integer   "LANE_NO",        :null => false
      t.datetime  "WBS_ON_DATE",    :null => true
    end

    execute sql_create_wbs_pk_up
    execute sql_create_wbs_fk_to_production_up
    execute sql_check_wbs_fk_to_production
    execute sql_create_wbs_fk_to_lane_up
    execute sql_check_wbs_fk_to_lane
  end

  def self.down
    drop_table("T_WBS_DAT")

    create_table "T_WBS_DAT", :id => false , :force => true do |t|
      t.integer  "SKIT_NO",         :null => false
      t.integer  "LANE_NO",         :null => false
      t.datetime "WBS_ON_DATE",     :null => false
      t.datetime "WBS_OFF_DATE",    :null => true
    end

    execute sql_create_wbs_pk_down

    add_index( "T_WBS_DAT", "SKIT_NO", :name => "IDX_SKIT_NO")
    add_index( "T_WBS_DAT", "LANE_NO", :name => "IDX_LANE_NO")
    add_index( "T_WBS_DAT", "WBS_ON_DATE", :name => "IDX_WBS_ON_DATE")
  end

  def self.sql_create_wbs_pk_up
      "ALTER TABLE [T_WBS_DAT] ADD CONSTRAINT
       PK_T_WBS_DAT PRIMARY KEY NONCLUSTERED
       (
          LANE_NO ASC,
          MODEL_YEAR ASC,
          SUFFIX_CODE ASC,
          LOT_NO  ASC,
          UNIT  ASC
       ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
  end

  def self.sql_create_wbs_fk_to_production_up
    "
     ALTER TABLE [T_WBS_DAT] WITH CHECK ADD CONSTRAINT [FK_T_WBS_DAT_MODEL_YEAR_SUFFIX_CODE_LOT_NO_UNIT]
     FOREIGN KEY ([MODEL_YEAR], [SUFFIX_CODE], [LOT_NO], [UNIT])
     REFERENCES [T_PRODUCTION_DAT] ([MODEL_YEAR], [SUFFIX_CODE], [LOT_NO], [UNIT])"
  end

  def self.sql_check_wbs_fk_to_production
    "ALTER TABLE [T_WBS_DAT] CHECK CONSTRAINT [FK_T_WBS_DAT_MODEL_YEAR_SUFFIX_CODE_LOT_NO_UNIT]"
  end

  def self.sql_create_wbs_fk_to_lane_up
    "ALTER TABLE [T_WBS_DAT] WITH CHECK ADD CONSTRAINT [FK_T_WBS_DAT_LANE_NO]
     FOREIGN KEY ([LANE_NO])
     REFERENCES [T_LANE_MST] ([LANE_NO])
    "
  end

  def self.sql_check_wbs_fk_to_lane
    "ALTER TABLE [T_WBS_DAT] CHECK CONSTRAINT [FK_T_WBS_DAT_LANE_NO]"
  end

  def self.sql_create_wbs_pk_down
    "ALTER TABLE T_WBS_DAT ADD CONSTRAINT PK_T_WBS_DAT PRIMARY KEY NONCLUSTERED
      (
        LANE_NO ASC,
        WBS_ON_DATE ASC,
        SKIT_NO ASC

      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]"

  end
end
