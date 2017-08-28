class ChangeTXxxOptionCellIsUsedToDefaultFalseValue < ActiveRecord::Migration
  def self.up
    change_column("T_MODEL_OPTION_CELL", :IS_USED, :boolean, :default => false, :null=>false)
    change_column("T_PROCESS_OPTION_CELL", :IS_USED, :boolean, :default => false, :null=>false)
  end

  def self.down
    execute sql_drop_t_model_opion_cell_default
    execute sql_drop_t_process_opion_cell_default
  end

  def self.sql_drop_t_model_opion_cell_default
    "ALTER TABLE [dbo].[T_MODEL_OPTION_CELL] DROP CONSTRAINT [DF_T_MODEL_OPTION_CELL_IS_USED]"
  end

  def self.sql_drop_t_process_opion_cell_default
    "ALTER TABLE [dbo].[T_PROCESS_OPTION_CELL] DROP CONSTRAINT [DF_T_PROCESS_OPTION_CELL_IS_USED]"
  end
end
