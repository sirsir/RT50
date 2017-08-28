class CreateTableTSkitMst < ActiveRecord::Migration
  def self.up
    create_table "T_SKIT_MST", :id => false, :force => true do |t|
      t.integer "SKIT_NO", :null => false
      t.string  "MODEL_YEAR", :limit => 3, :null => true
      t.string  "SUFFIX_CODE", :limit => 5, :null => true
      t.string  "LOT_NO", :limit => 3, :null => true
      t.string  "UNIT", :limit => 3, :null => true
    end

    execute sql_create_t_skit_mst_pk
    execute sql_create_fk_t_skit_mst_model_year_suffix_code_lot_unit_with_delete_set_null
    execute sql_check_fk_t_skit_mst_model_year_suffix_code_lot_no_unit
  end

  def self.down
    drop_table "T_SKIT_MST"
  end
  
  def self.sql_create_t_skit_mst_pk
    "
      ALTER TABLE [T_SKIT_MST] ADD CONSTRAINT
      PK_T_SKIT_MST PRIMARY KEY CLUSTERED
      (
          SKIT_NO ASC
      ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    "
  end

  def self.sql_create_fk_t_skit_mst_model_year_suffix_code_lot_unit_with_delete_set_null
    "ALTER TABLE dbo.T_SKIT_MST ADD CONSTRAINT
      FK_T_SKIT_MST_MODEL_YEAR_SUFFIX_CODE_LOT_NO_UNIT FOREIGN KEY
      (
      MODEL_YEAR,
      SUFFIX_CODE,
      LOT_NO,
      UNIT
      ) REFERENCES dbo.T_PRODUCTION_DAT
      (
      MODEL_YEAR,
      SUFFIX_CODE,
      LOT_NO,
      UNIT
      ) ON UPDATE  NO ACTION
       ON DELETE  SET NULL
    "
  end

  def self.sql_check_fk_t_skit_mst_model_year_suffix_code_lot_no_unit
    "ALTER TABLE [T_SKIT_MST] CHECK CONSTRAINT [FK_T_SKIT_MST_MODEL_YEAR_SUFFIX_CODE_LOT_NO_UNIT]"
  end
end
