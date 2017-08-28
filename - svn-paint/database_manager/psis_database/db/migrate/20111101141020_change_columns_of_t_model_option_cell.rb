class ChangeColumnsOfTModelOptionCell < ActiveRecord::Migration
  def self.up
    remove_column "T_MODEL_OPTION_CELL", :OPTION_ID
    rename_column "T_MODEL_OPTION_CELL", :OPTION_GROUP_ID, :OPTION_ID
    add_column "T_MODEL_OPTION_CELL", :IS_USED, :boolean, :null => false

    execute sql_create_fk_t_model_option_cell_option_id_with_delete_cascade
    execute sql_check_fk_t_model_option_cell_option_id
  end

  def self.down
    remove_column "T_MODEL_OPTION_CELL", :IS_USED
    rename_column "T_MODEL_OPTION_CELL", :OPTION_ID, :OPTION_GROUP_ID
    add_column "T_MODEL_OPTION_CELL", :OPTION_ID, :integer, :null => false

    execute sql_drop_fk_t_model_option_cell_option_id
  end

  def self.sql_create_fk_t_model_option_cell_option_id_with_delete_cascade
    "ALTER TABLE dbo.T_MODEL_OPTION_CELL ADD CONSTRAINT
      FK_T_MODEL_OPTION_CELL_OPTION_ID FOREIGN KEY
      (
        OPTION_ID
      ) REFERENCES dbo.T_OPTION_MST
      (
      OPTION_ID
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_fk_t_model_option_cell_option_id
    "ALTER TABLE [T_MODEL_OPTION_CELL] CHECK CONSTRAINT [FK_T_MODEL_OPTION_CELL_OPTION_ID]"
  end

  def self.sql_drop_fk_t_model_option_cell_option_id
    "ALTER TABLE dbo.T_MODEL_OPTION_CELL
    	DROP CONSTRAINT FK_T_MODEL_OPTION_CELL_OPTION_ID"
  end
end
