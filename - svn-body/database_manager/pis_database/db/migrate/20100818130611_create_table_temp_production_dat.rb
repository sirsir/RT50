class CreateTableTempProductionDat < ActiveRecord::Migration
  def self.up
     create_table "TEMP_Production_DAT", :id => false, :force => true do |t|
      t.string  "SeqNo",          :limit => 5,   :null => false
      t.string  "ModelYear",      :limit => 3,   :null => false
      t.string  "SuffixCode",     :limit => 5,   :null => false
      t.string  "LotID",          :limit => 3,   :null => false
      t.string  "LotNo",          :limit => 3,   :null => false
      t.string  "Unit",           :limit => 3,   :null => false
      t.string  "BlockModel",     :limit => 8
      t.string  "BlockSeq",       :limit => 3
      t.string  "MARK",           :limit => 3
      t.string  "ProductionDate", :limit => 8
      t.string  "ProductionTime", :limit => 4
      t.string  "ImportCode",     :limit => 10
      t.string  "YChassisFlag",   :limit => 1
      t.string  "GAShop",         :limit => 2
      t.string  "HanmmerYears",   :limit => 2

      models.each do |m|
        t.string   m[:name],      :limit => 10
      end

      t.string  "Reserve01",      :limit => 100
      t.string  "Reserve02",      :limit => 100
    end

  end

  def self.down
    drop_table(:TEMP_Production_DAT)
  end

  def self.models()
  models = []
  for i in (1...21)
    for j in (1...6)
      models << {:name => "MODEL#{i.to_s.rjust(2, '0')}ASM#{j.to_s.rjust(2, '0')}" }
    end
  end 
  models
  end
end
