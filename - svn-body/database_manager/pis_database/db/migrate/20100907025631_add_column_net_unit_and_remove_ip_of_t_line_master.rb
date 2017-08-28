class AddColumnNetUnitAndRemoveIpOfTLineMaster < ActiveRecord::Migration
  def self.up
    add_column "T_Line_MST", :NetAddress, :integer, :null => false, :default => 1
    add_column "T_Line_MST", :UnitAddress, :integer, :null => false, :default => 0
    change_column "T_Line_MST", :NodeAddress, :integer, :null => false
  end

  def self.down
    remove_column "T_Line_MST", :NetAddress
    remove_column "T_Line_MST", :UnitAddress
    change_column "T_Line_MST", :NodeAddress, :string, :limit => 3, :null => false
  end
end
