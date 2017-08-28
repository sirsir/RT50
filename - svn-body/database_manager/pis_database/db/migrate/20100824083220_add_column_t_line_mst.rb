class AddColumnTLineMst < ActiveRecord::Migration
  def self.up
    add_column "T_Line_MST", :LineType, :string, :limit => 4, :null => false
    add_column "T_Line_MST", :MainLineFlag, :boolean, :null => false
    add_column "T_Line_MST", :OnlineFlag, :boolean, :null => false
    add_column "T_Line_MST", :IpAddress, :string, :limit => 15, :null => false
    add_column "T_Line_MST", :NodeAddress, :string, :limit => 3, :null => false
    add_column "T_Line_MST", :ReadReqAddress, :string, :limit => 6, :null => false
    add_column "T_Line_MST", :WriteProductionAddress, :string, :limit => 6, :null => false
    add_column "T_Line_MST", :WriteCarryOutAddress, :string, :limit => 6, :null => false
    add_column "T_Line_MST", :Part1, :boolean, :null => true
    add_column "T_Line_MST", :Part2, :boolean, :null => true
    add_column "T_Line_MST", :Part3, :boolean, :null => true
    add_column "T_Line_MST", :Part4, :boolean, :null => true
    add_column "T_Line_MST", :Part5, :boolean, :null => true
    
  end

  def self.down
    remove_column "T_Line_MST", :LineType, :MainLineFlag, :OnlineFlag, :IpAddress,
             :NodeAddress, :ReadReqAddress, :WriteProductionAddress, :WriteCarryOutAddress,
             :Part1, :Part2, :Part3, :Part4, :Part5
  end
end
