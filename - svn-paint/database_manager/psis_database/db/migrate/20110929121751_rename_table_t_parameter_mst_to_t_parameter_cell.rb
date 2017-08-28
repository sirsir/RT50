class RenameTableTParameterMstToTParameterCell < ActiveRecord::Migration
  def self.up
    rename_table("T_PARAMETER_MST", "T_PARAMETER_CELL")
    remove_column("T_PARAMETER_CELL", :MODEL_YEAR, :SUFFIX_CODE)
  end

  def self.down
    rename_table("T_PARAMETER_CELL", "T_PARAMETER_MST")
    add_column "T_PARAMETER_MST", :MODEL_YEAR, :string, :limit => 3, :null => false
    add_column "T_PARAMETER_MST", :SUFFIX_CODE, :string, :limit => 5, :null => false
  end
end
