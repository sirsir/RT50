class RemoveSkitNoLaneNoInUseFlagFromTProductionDat < ActiveRecord::Migration
  def self.up
    execute sql_drop_fk_t_production_dat_lane_no
    remove_column "T_PRODUCTION_DAT", :LANE_NO
    remove_column "T_PRODUCTION_DAT", :SKIT_NO
    remove_column "T_PRODUCTION_DAT", :IN_USE_FLAG
  end

  def self.down
    add_column "T_PRODUCTION_DAT", :SKIT_NO, :integer, :null => true
    add_column "T_PRODUCTION_DAT", :IN_USE_FLAG, :boolean, :null => false, :default => false
    add_column "T_PRODUCTION_DAT", :LANE_NO, :integer, :null => true

    execute sql_create_fk_t_production_dat_lane_no_with_delete_set_null_update_cascade
    execute sql_check_fk_t_production_dat_lane_no
    add_index("T_PRODUCTION_DAT", :IN_USE_FLAG, :name => 'IDX_IN_USE_FLAG')
    add_index("T_PRODUCTION_DAT", :SKIT_NO, :name => 'IDX_SKIT_NO')
  end
  
  def self.sql_drop_fk_t_production_dat_lane_no
    "
      ALTER TABLE dbo.T_PRODUCTION_DAT
    	DROP CONSTRAINT FK_T_PRODUCTION_DAT_LANE_NO
    "
  end
  
  def self.sql_create_fk_t_production_dat_lane_no_with_delete_set_null_update_cascade
    "ALTER TABLE dbo.T_PRODUCTION_DAT ADD CONSTRAINT
      FK_T_PRODUCTION_DAT_LANE_NO FOREIGN KEY
      (
      LANE_NO
      ) REFERENCES dbo.T_LANE_MST
      (
      LANE_NO
      ) ON UPDATE  CASCADE
       ON DELETE  SET NULL
    "
  end

  def self.sql_check_fk_t_production_dat_lane_no
    "ALTER TABLE [T_PRODUCTION_DAT] CHECK CONSTRAINT [FK_T_PRODUCTION_DAT_LANE_NO]"
  end
end
