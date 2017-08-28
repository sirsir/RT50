class CreateTableTProductionDat < ActiveRecord::Migration
  def self.up
    create_table "T_PRODUCTION_DAT", :id => false, :force => true do |t|
      t.string  "SEQ_NO",          :limit => 5,   :null => false
      t.string  "MODEL_YEAR",      :limit => 3,   :null => false
      t.string  "SUFFIX_CODE",     :limit => 5,   :null => false
      t.string  "LOT_ID",          :limit => 3,   :null => false
      t.string  "LOT_NO",          :limit => 3,   :null => false
      t.string  "UNIT",           :limit => 3,   :null => false
      t.string  "BLOCK_MODEL",     :limit => 8
      t.string  "BLOCK_SEQ",       :limit => 3
      t.string  "MARK",           :limit => 3
      t.string  "PRODUCTION_DATE", :limit => 8
      t.string  "SHIFT",          :limit => 1
      t.string  "ON_TIME",         :limit => 4
      t.string  "IMPORT_CODE",     :limit => 10
      t.string  "Y_CHASSIS_FLAG",   :limit => 1
      t.string  "GA_SHOP",         :limit => 2
      t.string  "BODY_SHOP_CODE",   :limit => 2
      t.string  "HANDLE_TYPE",     :limit => 2
      t.string  "BODY_COLOR_TC_SW",  :limit => 3
      t.string  "BODY_COLOR_SEQ",   :limit => 3
      t.string  "BODY_COLOR_OPT",   :limit => 3
      t.string  "BODY_COLOR_NAME",  :limit => 20
      t.string  "SURFACE_COLOR_SF_SW",  :limit => 3
      t.string  "SURFACE_COLOR_XXX",   :limit => 3
      t.string  "SURFACE_COLOR_NAME",  :limit => 20
      t.string  "FILE_NAME",       :limit => 255
    end

    execute sql_create_parameter_pk
    add_index("T_PRODUCTION_DAT", "MODEL_YEAR", :name => "IDX_MODEL_YEAR")
    add_index("T_PRODUCTION_DAT", "SUFFIX_CODE", :name => "IDX_SUFFIX_CODE")
    add_index("T_PRODUCTION_DAT", "LOT_NO", :name => "IDX_LOT_NO")
    add_index("T_PRODUCTION_DAT", "UNIT", :name => "IDX_UNIT")
  end

  def self.down
    drop_table "T_PRODUCTION_DAT"
  end

  def self.sql_create_parameter_pk
    "
      ALTER TABLE T_PRODUCTION_DAT ADD CONSTRAINT
       PK_T_PRODUCTION_DAT PRIMARY KEY CLUSTERED
      (
        MODEL_YEAR ASC,
        SUFFIX_CODE ASC,
        LOT_NO ASC,
        UNIT ASC
      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    "
  end
end
