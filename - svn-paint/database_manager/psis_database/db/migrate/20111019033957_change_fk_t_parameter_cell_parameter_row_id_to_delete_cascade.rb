class ChangeFkTParameterCellParameterRowIdToDeleteCascade < ActiveRecord::Migration
  def self.up
    execute sql_drop_fk_t_parameter_cell_parameter_row_id
    execute sql_create_fk_t_parameter_cell_parameter_row_id_with_delete_cascade
    execute sql_check_fk_t_parameter_cell_parameter_row_id
  end

  def self.down
    execute sql_drop_fk_t_parameter_cell_parameter_row_id
    execute sql_create_fk_t_parameter_cell_parameter_row_id_no_delete_cascade
    execute sql_check_fk_t_parameter_cell_parameter_row_id
  end

  def self.sql_drop_fk_t_parameter_cell_parameter_row_id
    "
      ALTER TABLE dbo.T_PARAMETER_CELL
    	DROP CONSTRAINT FK_T_PARAMETER_CELL_PARAMETER_ROW_ID
    "
  end

  def self.sql_create_fk_t_parameter_cell_parameter_row_id_with_delete_cascade
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

  def self.sql_create_fk_t_parameter_cell_parameter_row_id_no_delete_cascade
    "
    ALTER TABLE [T_PARAMETER_CELL]  WITH CHECK ADD  CONSTRAINT [FK_T_PARAMETER_CELL_PARAMETER_ROW_ID] FOREIGN KEY([PARAMETER_ROW_ID])
      REFERENCES [T_PARAMETER_ROW] ([PARAMETER_ROW_ID])
    "
  end

  def self.sql_check_fk_t_parameter_cell_parameter_row_id
    "ALTER TABLE [T_PARAMETER_CELL] CHECK CONSTRAINT [FK_T_PARAMETER_CELL_PARAMETER_ROW_ID]"
  end
end
