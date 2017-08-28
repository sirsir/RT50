class CreateTableTPlcMst < ActiveRecord::Migration
  def self.up
    create_table "T_PLC_MST", :primary_key => 'PLC_ID', :force => true do |t|
      t.integer "STAGE_CODE", :null => false
      t.integer "PLC_NET", :null => false
      t.integer "PLC_NODE", :null => false
      t.integer "PLC_UNIT", :null => false
      t.integer "READ_DM", :null => false
      t.integer "WRITE_DATA_DM", :null => false
      t.integer "WRITE_STATUS_DM", :null => false
      t.integer "PROCESS_NO", :null => false
    end
    
    execute sql_create_fk_t_plc_mst_process_no_with_delete_cascade
    execute sql_check_fk_t_plc_mst_process_no
  end

  def self.down
    drop_table("T_PLC_MST")
  end

  def self.sql_create_fk_t_plc_mst_process_no_with_delete_cascade
    "ALTER TABLE dbo.T_PLC_MST WITH CHECK ADD CONSTRAINT
      FK_T_PLC_MST_PROCESS_NO FOREIGN KEY
      (
      PROCESS_NO
      ) REFERENCES dbo.T_PROCESS_MST
      (
      PROCESS_NO
      ) ON UPDATE  NO ACTION
       ON DELETE  CASCADE
    "
  end

  def self.sql_check_fk_t_plc_mst_process_no
    "ALTER TABLE [T_PARAMETER_CELL] CHECK CONSTRAINT [FK_T_PARAMETER_CELL_PROCESS_NO]"
  end
end
