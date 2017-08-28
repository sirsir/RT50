class RemoveTableTempProductionDat < ActiveRecord::Migration
  def self.up
    drop_table(:TEMP_Production_DAT)
  end

  def self.down
    create_table "TEMP_Production_DAT", :id => false, :force => true do |t|
      t.string  "TempImport", :limit => 1200, :null => true
    end
  end
end
