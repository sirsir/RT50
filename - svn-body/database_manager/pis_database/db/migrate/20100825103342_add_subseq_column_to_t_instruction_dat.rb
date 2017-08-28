class AddSubseqColumnToTInstructionDat < ActiveRecord::Migration
  def self.up
    add_column "T_Instruction_DAT", :SubSeq, :integer, :null => true, :limit => 4
  end

  def self.down
    remove_column "T_Instruction_DAT", :SubSeq
  end
end
