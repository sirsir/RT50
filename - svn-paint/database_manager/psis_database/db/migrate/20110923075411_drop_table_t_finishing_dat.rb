class DropTableTFinishingDat < ActiveRecord::Migration
  def self.up
    drop_table(:T_FINISHING_DAT)
  end

  def self.down
    create_table "T_FINISHING_DAT", :id => false, :force => true do |t|
      t.string   "MODEL_YEAR",      :limit => 3,  :null => false
      t.string   "SUFFIX_CODE",     :limit => 5,  :null => false
      t.string   "LOT_NO",          :limit => 3,  :null => false
      t.string   "UNIT",            :limit => 3,  :null => false
      t.integer  "SKIT_NO",         :null => false
      t.datetime "FIN_ON_DATE",     :null => false
      t.datetime "FIN_OFF_DATE",    :null => true
      t.boolean  "IN_USE_FLAG",     :null => false
    end

    execute sql_create_finishing_pk
    execute sql_create_finishing_sk

  end

  def self.sql_create_finishing_pk
    "ALTER TABLE T_FINISHING_DAT ADD CONSTRAINT PK_T_FINISHING_DAT PRIMARY KEY NONCLUSTERED
      (
        MODEL_YEAR ASC,
        SUFFIX_CODE ASC,
        LOT_NO	ASC,
        UNIT ASC

      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]"

  end

  def self.sql_create_finishing_sk
    "
      CREATE UNIQUE CLUSTERED INDEX [SK_T_FINISHING_DAT] ON [dbo].[T_FINISHING_DAT]
      (
        SKIT_NO ASC
      ) ON [PRIMARY]
    "
  end
end
