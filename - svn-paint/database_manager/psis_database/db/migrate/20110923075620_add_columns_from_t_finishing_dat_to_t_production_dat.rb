class AddColumnsFromTFinishingDatToTProductionDat < ActiveRecord::Migration
  def self.up
    add_column "T_PRODUCTION_DAT", "SKIT_NO", :integer, :null => true
    add_column "T_PRODUCTION_DAT", "FIN_ON_DATE", :datetime, :null => true
    add_column "T_PRODUCTION_DAT", "FIN_OFF_DATE", :datetime, :null => true
    add_column "T_PRODUCTION_DAT", "IN_USE_FLAG", :boolean, :null => false

    add_index("T_PRODUCTION_DAT", "SKIT_NO", :name => "IDX_SKIT_NO")

    change_column "T_PRODUCTION_DAT", :SEQ_NO, :string, :limit => 5, :null => true
    change_column "T_PRODUCTION_DAT", :LOT_ID, :string, :limit => 3, :null => true

  end

  def self.down
    remove_index "T_PRODUCTION_DAT", :name => "IDX_SKIT_NO"
    remove_column("T_PRODUCTION_DAT", :SKIT_NO, :FIN_ON_DATE, :FIN_OFF_DATE, :IN_USE_FLAG)

    change_column "T_PRODUCTION_DAT", :SEQ_NO, :string, :limit => 5, :null => false
    change_column "T_PRODUCTION_DAT", :LOT_ID, :string, :limit => 3, :null => false
  end
end
