class AddBelowDelFlagToTInstructionDat < ActiveRecord::Migration
  def self.up
    add_column "T_Instruction_DAT", :BelowDelFlag, :boolean, :null => true
  end

  def self.down
    remove_column "T_Instruction_DAT", :BelowDelFlag
  end
end
