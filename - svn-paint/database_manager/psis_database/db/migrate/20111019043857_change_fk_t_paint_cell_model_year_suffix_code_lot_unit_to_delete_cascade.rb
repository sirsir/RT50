class ChangeFkTPaintCellModelYearSuffixCodeLotUnitToDeleteCascade < ActiveRecord::Migration
  def self.up
    execute sql_drop_fk_t_paint_cell_model_year_suffix_code_lot_unit
    execute sql_create_fk_t_paint_cell_model_year_suffix_code_lot_unit_with_delete_cascade
    execute sql_check_fk_t_paint_cell_model_year_suffix_code_lot_unit
  end

  def self.down
    execute sql_drop_fk_t_paint_cell_model_year_suffix_code_lot_unit
    execute sql_create_fk_t_paint_cell_model_year_suffix_code_lot_unit_no_delete_cascade
    execute sql_check_fk_t_paint_cell_model_year_suffix_code_lot_unit
  end

  def self.sql_drop_fk_t_paint_cell_model_year_suffix_code_lot_unit
    "
      ALTER TABLE dbo.T_PAINT_CELL
    	DROP CONSTRAINT FK_T_PAINT_CELL_MODEL_YEAR_SUFFIX_CODE_LOT_UNIT
    "
  end

  def self.sql_create_fk_t_paint_cell_model_year_suffix_code_lot_unit_with_delete_cascade
    "ALTER TABLE dbo.T_PAINT_CELL ADD CONSTRAINT
      FK_T_PAINT_CELL_MODEL_YEAR_SUFFIX_CODE_LOT_UNIT FOREIGN KEY
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

  def self.sql_create_fk_t_paint_cell_model_year_suffix_code_lot_unit_no_delete_cascade
    "
      ALTER TABLE [T_PAINT_CELL] WITH CHECK ADD CONSTRAINT [FK_T_PAINT_CELL_MODEL_YEAR_SUFFIX_CODE_LOT_UNIT]
      FOREIGN KEY ([MODEL_YEAR],[SUFFIX_CODE],[LOT_NO],[UNIT])
      REFERENCES [T_PRODUCTION_DAT] ([MODEL_YEAR],[SUFFIX_CODE],[LOT_NO],[UNIT])
    "
  end

  def self.sql_check_fk_t_paint_cell_model_year_suffix_code_lot_unit
    "ALTER TABLE [T_PAINT_CELL] CHECK CONSTRAINT [FK_T_PAINT_CELL_MODEL_YEAR_SUFFIX_CODE_LOT_UNIT]"
  end
end
