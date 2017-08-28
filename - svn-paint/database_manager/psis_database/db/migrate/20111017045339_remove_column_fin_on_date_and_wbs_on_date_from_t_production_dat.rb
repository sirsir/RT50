class RemoveColumnFinOnDateAndWbsOnDateFromTProductionDat < ActiveRecord::Migration
  def self.up
    remove_column("T_PRODUCTION_DAT", :FIN_ON_DATE)
    remove_column("T_PRODUCTION_DAT", :WBS_ON_DATE)
  end

  def self.down
    add_column "T_PRODUCTION_DAT", :FIN_ON_DATE, :datetime, :null=> true
    add_column "T_PRODUCTION_DAT", :WBS_ON_DATE, :datetime, :null=> true
  end
end
