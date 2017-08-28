class ChangeTProcessMstAddGroupIdAddProcessCodeRemoveLabelName < ActiveRecord::Migration
  def self.up
    remove_column "T_PROCESS_MST", :LABEL_NAME
    
    add_column  "T_PROCESS_MST", :PROCESS_CODE, :integer, :null => true
    execute sql_update_process_code_value
    change_column  "T_PROCESS_MST", :PROCESS_CODE, :integer, :null => false
    add_index("T_PROCESS_MST", :PROCESS_CODE, :unique => true, :name => 'IDX_PROCESS_CODE')
    
    add_column  "T_PROCESS_MST", :PROCESS_GROUP_ID, :integer, :null => true
    execute sql_update_group_id_value
    change_column  "T_PROCESS_MST", :PROCESS_GROUP_ID, :integer, :null => false
    execute sql_create_fk_t_process_mst_process_group_id_with_delete_cascade
    execute sql_check_fk_t_process_mst_process_group_id
    
  end

  def self.down
    add_column "T_PROCESS_MST", :LABEL_NAME, :string, :limit => 20, :null => true
    add_index("T_PROCESS_MST", :LABEL_NAME, :unique => false, :name => 'IDX_LABEL_NAME')

    execute sql_drop_fk_t_process_mst_process_group_id
    remove_column "T_PROCESS_MST", :PROCESS_CODE
    remove_column "T_PROCESS_MST", :PROCESS_GROUP_ID
  end

  def self.sql_create_fk_t_process_mst_process_group_id_with_delete_cascade
    "ALTER TABLE dbo.T_PROCESS_MST ADD CONSTRAINT
      FK_T_PROCESS_MST_PROCESS_GROUP_ID FOREIGN KEY
      (
        PROCESS_GROUP_ID
      ) REFERENCES dbo.T_PROCESS_GROUP_MST
      (
      PROCESS_GROUP_ID
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_fk_t_process_mst_process_group_id
    "ALTER TABLE [T_PROCESS_MST] CHECK CONSTRAINT [FK_T_PROCESS_MST_PROCESS_GROUP_ID]"
  end

  def self.sql_drop_fk_t_process_mst_process_group_id
    "ALTER TABLE [T_PROCESS_MST] DROP CONSTRAINT [FK_T_PROCESS_MST_PROCESS_GROUP_ID]"
  end
  
  def self.get_min_group_id
    return select_value("select min(PROCESS_GROUP_ID) from T_PROCESS_GROUP_MST")
  end

  def self.sql_update_process_code_value
    "UPDATE T_PROCESS_MST
SET PROCESS_CODE = -PROCESS_NO"
  end

  def self.sql_update_group_id_value
    "UPDATE T_PROCESS_MST
SET PROCESS_GROUP_ID = (select max(PROCESS_GROUP_ID) from T_PROCESS_GROUP_MST)"
  end
end
