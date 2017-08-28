class AddFkOfTParameterCellToTParameterRow < ActiveRecord::Migration
  def self.up
    execute sql_create_parameter_row_fk
    execute sql_check_parameter_row_fk
  end

  def self.down
    execute sql_drop_parameter_row_fk
  end

  def self.sql_create_parameter_row_fk
    "
    ALTER TABLE [T_PARAMETER_CELL]  WITH CHECK ADD  CONSTRAINT [PROCESS_FKEY_T_PARAMETER_ROW] FOREIGN KEY([MODEL_CODE])
      REFERENCES [T_PARAMETER_ROW] ([MODEL_CODE])
    "
  end

  def self.sql_check_parameter_row_fk
    "ALTER TABLE [T_PARAMETER_CELL] CHECK CONSTRAINT [PROCESS_FKEY_T_PARAMETER_ROW]"
  end

  def self.sql_drop_parameter_row_fk
     "ALTER TABLE T_PARAMETER_CELL DROP CONSTRAINT PROCESS_FKEY_T_PARAMETER_ROW"
  end
end
