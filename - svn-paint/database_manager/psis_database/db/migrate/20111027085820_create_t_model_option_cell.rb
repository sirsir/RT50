class CreateTModelOptionCell < ActiveRecord::Migration
  def self.up
    create_table "T_MODEL_OPTION_CELL", :id => false, :force => true do |t|
      t.integer "MODEL_OPTION_ROW_ID", :null => false
      t.integer "OPTION_GROUP_ID", :null => false
      t.integer "OPTION_ID",  :null => false
    end

    execute sql_create_pk_t_model_option_cell

    execute sql_create_fk_t_model_option_cell_group_id_with_delete_cascade
    execute sql_check_fk_t_model_option_cell_group_id

    execute sql_create_fk_t_model_option_cell_model_option_row_id_with_delete_cascade
    execute sql_check_fk_t_model_option_cell_model_option_row_id
  end

  def self.down
    drop_table "T_MODEL_OPTION_CELL"
  end

  def self.sql_create_pk_t_model_option_cell
      "ALTER TABLE [T_MODEL_OPTION_CELL] ADD CONSTRAINT
       PK_T_MODEL_OPTION_CELL PRIMARY KEY CLUSTERED
       (
          MODEL_OPTION_ROW_ID ASC,
          OPTION_GROUP_ID ASC
       ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
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

  def self.sql_create_fk_t_model_option_cell_model_option_row_id_with_delete_cascade
    "ALTER TABLE dbo.T_MODEL_OPTION_CELL ADD CONSTRAINT
      FK_T_MODEL_OPTION_CELL_MODEL_OPTION_ROW_ID FOREIGN KEY
      (
        MODEL_OPTION_ROW_ID
      ) REFERENCES dbo.T_MODEL_OPTION_ROW
      (
      MODEL_OPTION_ROW_ID
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_fk_t_model_option_cell_model_option_row_id
    "ALTER TABLE [T_MODEL_OPTION_CELL] CHECK CONSTRAINT [FK_T_MODEL_OPTION_CELL_MODEL_OPTION_ROW_ID]"
  end
end
