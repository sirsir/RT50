class CreateTableTOptionMst < ActiveRecord::Migration
  def self.up
    create_table "T_OPTION_MST", :primary_key => "OPTION_ID", :force => true do |t|
      t.integer "OPTION_GROUP_ID", :null => false
      t.string  "OPTION_DESCR", :limit => 15, :null => false
      t.integer "OPTION_SEQ",  :null => false
    end

    execute sql_create_fk_t_option_mst_group_id_with_delete_cascade
    execute sql_check_fk_t_option_mst_group_id
  end

  def self.down
    drop_table "T_OPTION_MST"
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
end
