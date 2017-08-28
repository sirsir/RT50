class CreateTableTProductionDat < ActiveRecord::Migration
  def self.up
     create_table "T_Production_DAT", :id => false, :force => true do |t|
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
      t.integer "SubSeq",         :limit => 4
      t.string  "XchgFlag",       :limit => 4
      t.integer "InstructFlag",   :limit => 4
      t.string  "FileName",       :limit => 32
    end

    add_index "T_Production_DAT", ["SeqNo", "ModelYear", "SuffixCode", "MODEL01ASM01", "ProductionDate", "ProductionTime"], :name => "IX_IDX_Production"

    execute "
ALTER TABLE T_Production_DAT ADD CONSTRAINT
  PK_T_Production_DAT PRIMARY KEY NONCLUSTERED
  ( SeqNo,
    ModelYear,
    SuffixCode,
    LotID,
    LotNo,
    Unit
  ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
      "

  end

  def self.down
    drop_table(:T_Production_DAT)
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