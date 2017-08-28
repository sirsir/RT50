class ChangePassFlagToNotNullInTInstructionDat < ActiveRecord::Migration
  def self.up
    update "UPDATE T_Instruction_DAT SET InsPassFlag = 'False'"
    change_column "T_Instruction_DAT", :InsPassFlag, :boolean, :null => false, :default => false

    update "UPDATE T_Instruction_DAT SET CarrPassFlag = 'False'"
    change_column "T_Instruction_DAT", :CarrPassFlag, :boolean, :null => false, :default => false
  end

  def self.down
    execute " ALTER TABLE [dbo].[T_Instruction_DAT] DROP CONSTRAINT [DF_T_Instruction_DAT_CarrPassFlag] "
    execute " ALTER TABLE [dbo].[T_Instruction_DAT] DROP CONSTRAINT [DF_T_Instruction_DAT_InsPassFlag] "

    change_column "T_Instruction_DAT", :InsPassFlag, :boolean, :null => true
    change_column "T_Instruction_DAT", :CarrPassFlag, :boolean, :null => true
  end
end
