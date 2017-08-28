class CreateTableTWbsOn < ActiveRecord::Migration
  def self.up
    create_table "T_WBS_ON", :id => false, :force => true do |t|
      t.integer "LANE_NO", :null => false
      t.integer "SEQUENCE", :null => false
      t.integer "SKIT_NO", :null => false
    end

    execute sql_create_t_wbs_on_pk
    execute sql_create_fk_t_wbs_on_lane_no_with_delete_cascade
    execute sql_check_fk_t_wbs_on_lane_no

    execute sql_create_fk_t_wbs_on_skit_no_with_delete_cascade
    execute sql_check_fk_t_wbs_on_skit_no
  end

  def self.down
    drop_table "T_WBS_ON"
  end

  def self.sql_create_t_wbs_on_pk
    "
      ALTER TABLE [T_WBS_ON] ADD CONSTRAINT
      PK_T_WBS_ON PRIMARY KEY CLUSTERED
      (
          LANE_NO ASC,
          SEQUENCE ASC
      ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    "
  end

  def self.sql_create_fk_t_wbs_on_lane_no_with_delete_cascade
    "ALTER TABLE dbo.T_WBS_ON ADD CONSTRAINT
      FK_T_WBS_ON_LANE_NO FOREIGN KEY
      (
        LANE_NO
      ) REFERENCES dbo.T_LANE_MST
      (
      LANE_NO
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_fk_t_wbs_on_lane_no
    "ALTER TABLE [T_WBS_ON] CHECK CONSTRAINT [FK_T_WBS_ON_LANE_NO]"
  end

  def self.sql_create_fk_t_wbs_on_skit_no_with_delete_cascade
    "ALTER TABLE dbo.T_WBS_ON ADD CONSTRAINT
      FK_T_WBS_ON_SKIT_NO FOREIGN KEY
      (
        SKIT_NO
      ) REFERENCES dbo.T_SKIT_MST
      (
      SKIT_NO
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_fk_t_wbs_on_skit_no
    "ALTER TABLE [T_WBS_ON] CHECK CONSTRAINT [FK_T_WBS_ON_SKIT_NO]"
  end
end
