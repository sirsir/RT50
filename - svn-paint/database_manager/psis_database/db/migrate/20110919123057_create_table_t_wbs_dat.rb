class CreateTableTWbsDat < ActiveRecord::Migration
  def self.up
    create_table "T_WBS_DAT", :id => false , :force => true do |t|
      t.integer  "SKIT_NO",         :null => false
      t.integer  "LANE_NO",         :null => false
      t.datetime "WBS_ON_DATE",     :null => false
      t.datetime "WBS_OFF_DATE",    :null => true
    end

    execute sql_create_wbs_pk

    add_index( "T_WBS_DAT", "SKIT_NO", :name => "IDX_SKIT_NO")
    add_index( "T_WBS_DAT", "LANE_NO", :name => "IDX_LANE_NO")
    add_index( "T_WBS_DAT", "WBS_ON_DATE", :name => "IDX_WBS_ON_DATE")
    #execute sql_create_wbs_sk

  end

  def self.down
    drop_table "T_WBS_DAT"
  end

  def self.sql_create_wbs_pk
    "ALTER TABLE T_WBS_DAT ADD CONSTRAINT PK_T_WBS_DAT PRIMARY KEY NONCLUSTERED
      (
        LANE_NO ASC,
        WBS_ON_DATE ASC,
        SKIT_NO ASC

      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]"

  end

  def self.sql_create_wbs_sk
    "
      CREATE UNIQUE CLUSTERED INDEX [SK_T_WBS_DAT] ON [dbo].[T_WBS_DAT]
      (
        LANE_NO ASC
      ) ON [PRIMARY]
    "
  end
end
