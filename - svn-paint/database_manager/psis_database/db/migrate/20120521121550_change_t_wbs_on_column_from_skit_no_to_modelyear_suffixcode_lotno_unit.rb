class ChangeTWbsOnColumnFromSkitNoToModelyearSuffixcodeLotnoUnit < ActiveRecord::Migration
  def self.up
    execute sql_drop_fk_t_wbs_on_skit_no
    execute sql_clear_t_wbs_on
    execute sql_drop_idx_skit_no

    remove_column("T_WBS_ON", :SKIT_NO)
    add_column "T_WBS_ON", :MODEL_YEAR, :string, :limit => 3, :null => false
    add_column "T_WBS_ON", :SUFFIX_CODE, :string, :limit => 5, :null => false
    add_column "T_WBS_ON", :LOT_NO, :string, :limit => 3, :null => false
    add_column "T_WBS_ON", :UNIT, :string, :limit => 3, :null => false

    execute sql_create_fk_t_wbs_on_model_year_suffix_code_lot_no_unit_with_delete_cascade
    execute sql_check_fk_t_wbs_on_model_year_suffix_code_lot_no_unit_with_delete_cascade

    execute sql_create_idx_model_year_suffix_code_lot_no_unit
  end

  def self.down
    execute sql_drop_fk_t_wbs_on_model_year_suffix_code_lot_no_unit_with_delete_cascade
    execute sql_clear_t_wbs_on
    execute sql_drop_idx_model_year_suffix_code_lot_no_unit

    remove_column("T_WBS_ON", :MODEL_YEAR)
    remove_column("T_WBS_ON", :SUFFIX_CODE)
    remove_column("T_WBS_ON", :LOT_NO)
    remove_column("T_WBS_ON", :UNIT)
    add_column "T_WBS_ON", :SKIT_NO, :integer, :null => false

    execute sql_create_fk_t_wbs_on_skit_no_with_delete_cascade
    execute sql_check_fk_t_wbs_on_skit_no

    execute sql_create_idx_skit_no
  end

  def self.sql_clear_t_wbs_on
    "DELETE FROM T_WBS_ON"
  end

  def self.sql_drop_fk_t_wbs_on_skit_no
    "ALTER TABLE dbo.T_WBS_ON
    	DROP CONSTRAINT FK_T_WBS_ON_SKIT_NO"
  end

  def self.sql_create_fk_t_wbs_on_model_year_suffix_code_lot_no_unit_with_delete_cascade
    "ALTER TABLE dbo.T_WBS_ON ADD CONSTRAINT
      FK_T_WBS_ON_MODEL_YEAR_SUFFIX_CODE_LOT_NO_UNIT FOREIGN KEY
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
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_fk_t_wbs_on_model_year_suffix_code_lot_no_unit_with_delete_cascade
    "ALTER TABLE [T_WBS_ON] CHECK CONSTRAINT [FK_T_WBS_ON_MODEL_YEAR_SUFFIX_CODE_LOT_NO_UNIT]"
  end

  def self.sql_drop_fk_t_wbs_on_model_year_suffix_code_lot_no_unit_with_delete_cascade
    "ALTER TABLE dbo.T_WBS_ON
    	DROP CONSTRAINT FK_T_WBS_ON_MODEL_YEAR_SUFFIX_CODE_LOT_NO_UNIT"
  end

  def self.sql_create_fk_t_wbs_on_skit_no_with_delete_cascade
    "ALTER TABLE dbo.T_WBS_ON ADD CONSTRAINT
      FK_T_WBS_ON_SKIT_NO FOREIGN KEY
      (
        SKIT_NO
      ) REFERENCES dbo.T_SKIT_MST
      (
      SKIT_NO
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_fk_t_wbs_on_skit_no
    "ALTER TABLE [T_WBS_ON] CHECK CONSTRAINT [FK_T_WBS_ON_SKIT_NO]"
  end

   def self.sql_create_idx_model_year_suffix_code_lot_no_unit
    "
      CREATE UNIQUE NONCLUSTERED INDEX [IDX_MODEL_YEAR_SUFFIX_CODE_LOT_NO_UNIT] ON [dbo].[T_WBS_ON]
      (
        [MODEL_YEAR] ASC,
        [SUFFIX_CODE] ASC,
        [LOT_NO] ASC,
        [UNIT] ASC
      ) ON [PRIMARY]
    "
  end

  def self.sql_drop_idx_model_year_suffix_code_lot_no_unit
    "
        DROP INDEX [IDX_MODEL_YEAR_SUFFIX_CODE_LOT_NO_UNIT] ON [dbo].[T_WBS_ON] WITH ( ONLINE = OFF )
    "
  end

  def self.sql_create_idx_skit_no
    "
CREATE UNIQUE NONCLUSTERED INDEX [IDX_SKIT_NO] ON [dbo].[T_WBS_ON]
(
  [SKIT_NO] ASC
) ON [PRIMARY]
    "
  end

  def self.sql_drop_idx_skit_no
    "
        DROP INDEX [IDX_SKIT_NO] ON [dbo].[T_WBS_ON] WITH ( ONLINE = OFF )
    "
  end
end
