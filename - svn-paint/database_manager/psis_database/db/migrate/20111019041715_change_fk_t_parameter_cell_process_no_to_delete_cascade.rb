class ChangeFkTParameterCellProcessNoToDeleteCascade < ActiveRecord::Migration
  def self.up
    execute sql_drop_fk_t_parameter_cell_process_no
    execute sql_create_fk_t_parameter_cell_process_no_with_delete_cascade
    execute sql_check_fk_t_parameter_cell_process_no
  end

  def self.down
    execute sql_drop_fk_t_parameter_cell_process_no
    execute sql_create_fk_t_parameter_cell_process_no_no_delete_cascade
    execute sql_check_fk_t_parameter_cell_process_no
  end

  def self.sql_drop_fk_t_parameter_cell_process_no
    "
      ALTER TABLE dbo.T_PARAMETER_CELL
    	DROP CONSTRAINT FK_T_PARAMETER_CELL_PROCESS_NO
    "
  end

  def self.sql_create_fk_t_parameter_cell_process_no_with_delete_cascade
    "ALTER TABLE dbo.T_PARAMETER_CELL WITH CHECK ADD CONSTRAINT
      FK_T_PARAMETER_CELL_PROCESS_NO FOREIGN KEY
      (
      PROCESS_NO
      ) REFERENCES dbo.T_PROCESS_MST
      (
      PROCESS_NO
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_create_fk_t_parameter_cell_process_no_no_delete_cascade
    "
    ALTER TABLE [T_PARAMETER_CELL]  WITH CHECK ADD  CONSTRAINT [FK_T_PARAMETER_CELL_PROCESS_NO] FOREIGN KEY([PROCESS_NO])
      REFERENCES [T_PROCESS_MST] ([PROCESS_NO])
    "
  end

  def self.sql_check_fk_t_parameter_cell_process_no
    "ALTER TABLE [T_PARAMETER_CELL] CHECK CONSTRAINT [FK_T_PARAMETER_CELL_PROCESS_NO]"
  end
end
