class ChangeColumnOrderInTLineMst < ActiveRecord::Migration
  def self.up
    delete "DELETE FROM [T_Line_MST]"
    remove_column "T_Line_MST", :NodeAddress
    remove_column "T_Line_MST", :ReadReqAddress
    remove_column "T_Line_MST", :WriteProductionAddress
    remove_column "T_Line_MST", :WriteCarryOutAddress
    remove_column "T_Line_MST", :Part1
    remove_column "T_Line_MST", :Part2
    remove_column "T_Line_MST", :Part3
    remove_column "T_Line_MST", :Part4
    remove_column "T_Line_MST", :Part5
    remove_column "T_Line_MST", :NetAddress
    remove_column "T_Line_MST", :UnitAddress
    
    add_column "T_Line_MST", :NetAddress, :integer, :null => false, :default => 1
    add_column "T_Line_MST", :NodeAddress, :integer, :null => false
    add_column "T_Line_MST", :UnitAddress, :integer, :null => false, :default => 0
    add_column "T_Line_MST", :ReadReqAddress, :integer, :null => false
    add_column "T_Line_MST", :WriteProductionAddress, :integer, :null => false
    add_column "T_Line_MST", :WriteCarryOutAddress, :integer, :null => false
    add_column "T_Line_MST", :Part1, :boolean, :null => true
    add_column "T_Line_MST", :Part2, :boolean, :null => true
    add_column "T_Line_MST", :Part3, :boolean, :null => true
    add_column "T_Line_MST", :Part4, :boolean, :null => true
    add_column "T_Line_MST", :Part5, :boolean, :null => true
    
  end

  def self.down
    delete "DELETE FROM [T_Line_MST]"
    remove_column "T_Line_MST", :NodeAddress
    remove_column "T_Line_MST", :ReadReqAddress
    remove_column "T_Line_MST", :WriteProductionAddress
    remove_column "T_Line_MST", :WriteCarryOutAddress
    remove_column "T_Line_MST", :Part1
    remove_column "T_Line_MST", :Part2
    remove_column "T_Line_MST", :Part3
    remove_column "T_Line_MST", :Part4
    remove_column "T_Line_MST", :Part5
    remove_column "T_Line_MST", :NetAddress
    remove_column "T_Line_MST", :UnitAddress
    
    add_column "T_Line_MST", :NodeAddress, :integer, :null => false
    add_column "T_Line_MST", :ReadReqAddress, :string, :limit => 6, :null => false
    add_column "T_Line_MST", :WriteProductionAddress, :string, :limit => 6, :null => false
    add_column "T_Line_MST", :WriteCarryOutAddress, :string, :limit => 6, :null => false
    add_column "T_Line_MST", :Part1, :boolean, :null => true
    add_column "T_Line_MST", :Part2, :boolean, :null => true
    add_column "T_Line_MST", :Part3, :boolean, :null => true
    add_column "T_Line_MST", :Part4, :boolean, :null => true
    add_column "T_Line_MST", :Part5, :boolean, :null => true
    add_column "T_Line_MST", :NetAddress, :integer, :null => false, :default => 1
    add_column "T_Line_MST", :UnitAddress, :integer, :null => false, :default => 0
  end
end
