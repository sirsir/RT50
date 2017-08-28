class ChangeLineTypeInTLineMstToInt < ActiveRecord::Migration
  def self.up
    change_column "T_Line_MST", :LineType, :integer, :null => false
  end

  def self.down
    change_column "T_Line_MST", :LineType, :string, :limit => 4, :null => false
  end
end
