class CreateTableTInstructionDat < ActiveRecord::Migration
  def self.up
    create_table "T_Instruction_DAT", :id => false, :force => true do |t|
      t.string   "SeqNo",          :limit => 5,  :null => false
      t.string   "ModelYear",      :limit => 3,  :null => false
      t.string   "SuffixCode",     :limit => 5,  :null => false
      t.string   "LotID",          :limit => 3,  :null => false
      t.string   "LotNo",          :limit => 3,  :null => false
      t.string   "Unit",           :limit => 3,  :null => false
      t.string   "BlockModel",     :limit => 8
      t.string   "BlockSeq",       :limit => 3
      t.string   "MARK",           :limit => 3
      t.string   "ProductionDate", :limit => 8
      t.string   "ProductionTime", :limit => 4
      t.string   "ImportCode",     :limit => 10
      t.string   "YChassisFlag",   :limit => 1
      t.string   "GAShop",         :limit => 2
      t.string   "HanmmerYears",   :limit => 2
      t.string   "ASM01",          :limit => 10
      t.string   "ASM02",          :limit => 10
      t.string   "ASM03",          :limit => 10
      t.string   "ASM04",          :limit => 10
      t.string   "ASM05",          :limit => 10
      t.string   "XchgFlag",       :limit => 4
      t.datetime "InsResult"
      t.integer  "InsPassFlag",    :limit => 1
      t.integer  "Line_No",        :limit => 4,  :null => false
      t.datetime "CarrResult"
      t.integer  "CarrPassFlag",   :limit => 1
    end

  add_index "T_Instruction_DAT", ["SeqNo", "ModelYear", "SuffixCode", "ProductionDate", "ProductionTime", "ASM01"], :name => "IX_IDX_Instruct"

  end

  def self.down
    drop_table(:T_Instruction_DAT)
  end
end
