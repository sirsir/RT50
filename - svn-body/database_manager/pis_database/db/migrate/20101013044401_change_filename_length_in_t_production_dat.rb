class ChangeFilenameLengthInTProductionDat < ActiveRecord::Migration
  def self.up
    change_column "T_Production_DAT", :FileName, :string, :limit => 255, :null => true
  end

  def self.down
    change_column "T_Production_DAT", :FileName, :string, :limit => 32, :null => true
  end
end
