class ChangeFlagInTInstructionDatToBit < ActiveRecord::Migration
  def self.up
    change_column "T_Instruction_DAT", :InsPassFlag, :boolean, :null => true
    change_column "T_Instruction_DAT", :CarrPassFlag, :boolean, :null => true
  end

  def self.down
#    remove_column "T_Instruction_DAT", :InsPassFlag, :CarrPassFlag
#    add_column "T_Instruction_DAT", :InsPassFlag, :integer,  {:null => true}
#    add_column "T_Instruction_DAT", :CarrPassFlag, :integer,  {:null => true}
    change_column "T_Instruction_DAT", :InsPassFlag, :integer, :null => true
    change_column "T_Instruction_DAT", :CarrPassFlag, :integer, :null => true
  end
end
