class RenameTPaintDatTableToTPaintCell < ActiveRecord::Migration
  def self.up
    rename_table("T_PAINT_DAT", "T_PAINT_CELL")
    rename_column("T_PAINT_CELL", "PROCESS_ON_DATE", "PROCESS_RESULT_DATE")
    remove_column("T_PAINT_CELL", :PROCESS_OFF_DATE)
  end

  def self.down
    rename_column("T_PAINT_CELL", "PROCESS_RESULT_DATE", "PROCESS_ON_DATE")
    add_column("T_PAINT_CELL", :PROCESS_OFF_DATE, :datetime, :null => true)
    rename_table("T_PAINT_CELL", "T_PAINT_DAT")
  end
end
