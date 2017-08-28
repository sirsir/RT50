class ChangeColumnsOfTOptionMst < ActiveRecord::Migration
  def self.up
    execute sql_drop_fk_t_option_mst_group_id
    execute sql_drop_fk_t_model_option_cell_group_id
    remove_column "T_OPTION_MST", :OPTION_GROUP_ID
    rename_column "T_OPTION_MST", :OPTION_DESCR, :OPTION_NAME
    add_column "T_OPTION_MST", :OPTION_CODE, :string, :limit => 32, :null => true
    add_column "T_OPTION_MST", :OPTION_DISPLAY, :string, :limit => 15, :null => true
    add_column "T_OPTION_MST", :OPTION_TYPE, :integer, :null => false
    
    add_index("T_OPTION_MST", :OPTION_TYPE, :name => 'IDX_T_OPTION_MST_OPTION_TYPE')
    add_index("T_OPTION_MST", :OPTION_SEQ, :name => 'IDX_T_OPTION_MST_OPTION_SEQ')
    drop_table "T_OPTION_GROUP_MST"
    
  end

  def self.down
    create_table "T_OPTION_GROUP_MST", :primary_key => "OPTION_GROUP_ID", :force => true do |t|
      t.integer "OPTION_GROUP_TYPE", :null => false
      t.string  "OPTION_GROUP_DESCR", :limit => 15, :null => false
      t.integer "OPTION_GROUP_SEQ",  :null => false
    end

    add_column "T_OPTION_MST", :OPTION_GROUP_ID, :integer, :null => false
    rename_column "T_OPTION_MST", :OPTION_NAME, :OPTION_DESCR
    remove_column "T_OPTION_MST", :OPTION_CODE
    remove_column "T_OPTION_MST", :OPTION_DISPLAY
    remove_column "T_OPTION_MST", :OPTION_TYPE
    remove_index "T_OPTION_MST", :name => 'IDX_T_OPTION_MST_OPTION_SEQ' 

    execute sql_create_fk_t_option_mst_group_id_with_delete_cascade
    execute sql_check_fk_t_option_mst_group_id

    execute sql_create_fk_t_model_option_cell_group_id_with_delete_cascade
    execute sql_check_fk_t_model_option_cell_group_id
  end
  
  def self.sql_create_fk_t_option_mst_group_id_with_delete_cascade
    "ALTER TABLE dbo.T_OPTION_MST ADD CONSTRAINT
      FK_T_OPTION_MST_OPTION_GROUP_ID FOREIGN KEY
      (
        OPTION_GROUP_ID
      ) REFERENCES dbo.T_OPTION_GROUP_MST
      (
      OPTION_GROUP_ID
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_fk_t_option_mst_group_id
    "ALTER TABLE [T_OPTION_MST] CHECK CONSTRAINT [FK_T_OPTION_MST_OPTION_GROUP_ID]"
  end

  def self.sql_drop_fk_t_option_mst_group_id
    "ALTER TABLE dbo.T_OPTION_MST
    	DROP CONSTRAINT FK_T_OPTION_MST_OPTION_GROUP_ID"
  end

  def self.sql_create_fk_t_model_option_cell_group_id_with_delete_cascade
    "ALTER TABLE dbo.T_MODEL_OPTION_CELL ADD CONSTRAINT
      FK_T_MODEL_OPTION_CELL_OPTION_GROUP_ID FOREIGN KEY
      (
        OPTION_GROUP_ID
      ) REFERENCES dbo.T_OPTION_GROUP_MST
      (
      OPTION_GROUP_ID
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_fk_t_model_option_cell_group_id
    "ALTER TABLE [T_MODEL_OPTION_CELL] CHECK CONSTRAINT [FK_T_MODEL_OPTION_CELL_OPTION_GROUP_ID]"
  end

  def self.sql_drop_fk_t_model_option_cell_group_id
    "ALTER TABLE dbo.T_MODEL_OPTION_CELL
    	DROP CONSTRAINT FK_T_MODEL_OPTION_CELL_OPTION_GROUP_ID"
  end
end
