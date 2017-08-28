class ChangeFkTProcessMstProcessGroupIdToNotDeleteCascade < ActiveRecord::Migration
  def self.up
    execute sql_drop_fk_t_process_mst_process_group_id
    execute sql_create_fk_t_process_mst_process_group_id_no_delete_cascade
    execute sql_check_fk_t_process_mst_process_group_id
  end

  def self.down
    execute sql_drop_fk_t_process_mst_process_group_id
    execute sql_create_fk_t_process_mst_process_group_id_with_delete_cascade
    execute sql_check_fk_t_process_mst_process_group_id
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

  def self.sql_create_fk_t_process_mst_process_group_id_no_delete_cascade
    "ALTER TABLE dbo.T_PROCESS_MST ADD CONSTRAINT
      FK_T_PROCESS_MST_PROCESS_GROUP_ID FOREIGN KEY
      (
        PROCESS_GROUP_ID
      ) REFERENCES dbo.T_PROCESS_GROUP_MST
      (
      PROCESS_GROUP_ID
      ) ON UPDATE  NO ACTION
       ON DELETE  NO ACTION
    "
  end
end
