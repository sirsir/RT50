class DropColumnFinOffDateFromTProductionDat < ActiveRecord::Migration
  def self.up
    remove_column("T_PRODUCTION_DAT", "FIN_OFF_DATE")
  end

  def self.down
    add_column("T_PRODUCTION_DAT", "FIN_OFF_DATE", :datetime, :null => true)
  end
end
