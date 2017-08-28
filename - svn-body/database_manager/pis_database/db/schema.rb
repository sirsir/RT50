# This file is auto-generated from the current state of the database. Instead of editing this file, 
# please use the migrations feature of Active Record to incrementally modify your database, and
# then regenerate this schema definition.
#
# Note that this schema.rb definition is the authoritative source for your database schema. If you need
# to create the application database on another system, you should be using db:schema:load, not running
# all the migrations from scratch. The latter is a flawed and unsustainable approach (the more migrations
# you'll amass, the slower it'll run and the greater likelihood for issues).
#
# It's strongly recommended to check this file into your version control system.

ActiveRecord::Schema.define(:version => 20110223104152) do

  create_table "T_Instruction_DAT", :id => false, :force => true do |t|
    t.string   "SeqNo",          :limit => 5,                     :null => false
    t.string   "ModelYear",      :limit => 3,                     :null => false
    t.string   "SuffixCode",     :limit => 5,                     :null => false
    t.string   "LotID",          :limit => 3,                     :null => false
    t.string   "LotNo",          :limit => 3,                     :null => false
    t.string   "Unit",           :limit => 3,                     :null => false
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
    t.boolean  "InsPassFlag",                  :default => false, :null => false
    t.integer  "Line_No",        :limit => 4,                     :null => false
    t.datetime "CarrResult"
    t.boolean  "CarrPassFlag",                 :default => false, :null => false
    t.integer  "SubSeq",         :limit => 4
    t.boolean  "BelowDelFlag"
  end

  add_index "T_Instruction_DAT", ["Line_No", "ProductionDate", "ProductionTime", "SeqNo", "SubSeq"], :name => "SK_T_Instruction_DAT", :unique => true
  add_index "T_Instruction_DAT", ["SeqNo", "ModelYear", "SuffixCode", "ProductionDate", "ProductionTime", "ASM01"], :name => "IX_IDX_Instruct"
  add_index "T_Instruction_DAT", ["XchgFlag"], :name => "IX_XchgFlag"

  create_table "T_LOG_DAT", :primary_key => "LogId", :force => true do |t|
    t.integer  "LogType",  :limit => 4,                 :null => false
    t.string   "PcName",   :limit => 60
    t.datetime "OccDate",                               :null => false
    t.string   "Message"
    t.string   "LineName", :limit => 60
    t.integer  "LogLevel", :limit => 4,  :default => 0, :null => false
  end

  create_table "T_Line_MST", :id => false, :force => true do |t|
    t.integer "LineCode",               :limit => 4,                 :null => false
    t.string  "LineName",               :limit => 60
    t.integer "LineType",               :limit => 4,                 :null => false
    t.boolean "MainLineFlag",                                        :null => false
    t.boolean "OnlineFlag",                                          :null => false
    t.string  "IpAddress",              :limit => 15,                :null => false
    t.integer "NetAddress",             :limit => 4,  :default => 1, :null => false
    t.integer "NodeAddress",            :limit => 4,                 :null => false
    t.integer "UnitAddress",            :limit => 4,  :default => 0, :null => false
    t.integer "ReadReqAddress",         :limit => 4,                 :null => false
    t.integer "WriteProductionAddress", :limit => 4,                 :null => false
    t.integer "WriteCarryOutAddress",   :limit => 4,                 :null => false
    t.boolean "Part1"
    t.boolean "Part2"
    t.boolean "Part3"
    t.boolean "Part4"
    t.boolean "Part5"
  end

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
    t.string  "MODEL01ASM01",   :limit => 10
    t.string  "MODEL01ASM02",   :limit => 10
    t.string  "MODEL01ASM03",   :limit => 10
    t.string  "MODEL01ASM04",   :limit => 10
    t.string  "MODEL01ASM05",   :limit => 10
    t.string  "MODEL02ASM01",   :limit => 10
    t.string  "MODEL02ASM02",   :limit => 10
    t.string  "MODEL02ASM03",   :limit => 10
    t.string  "MODEL02ASM04",   :limit => 10
    t.string  "MODEL02ASM05",   :limit => 10
    t.string  "MODEL03ASM01",   :limit => 10
    t.string  "MODEL03ASM02",   :limit => 10
    t.string  "MODEL03ASM03",   :limit => 10
    t.string  "MODEL03ASM04",   :limit => 10
    t.string  "MODEL03ASM05",   :limit => 10
    t.string  "MODEL04ASM01",   :limit => 10
    t.string  "MODEL04ASM02",   :limit => 10
    t.string  "MODEL04ASM03",   :limit => 10
    t.string  "MODEL04ASM04",   :limit => 10
    t.string  "MODEL04ASM05",   :limit => 10
    t.string  "MODEL05ASM01",   :limit => 10
    t.string  "MODEL05ASM02",   :limit => 10
    t.string  "MODEL05ASM03",   :limit => 10
    t.string  "MODEL05ASM04",   :limit => 10
    t.string  "MODEL05ASM05",   :limit => 10
    t.string  "MODEL06ASM01",   :limit => 10
    t.string  "MODEL06ASM02",   :limit => 10
    t.string  "MODEL06ASM03",   :limit => 10
    t.string  "MODEL06ASM04",   :limit => 10
    t.string  "MODEL06ASM05",   :limit => 10
    t.string  "MODEL07ASM01",   :limit => 10
    t.string  "MODEL07ASM02",   :limit => 10
    t.string  "MODEL07ASM03",   :limit => 10
    t.string  "MODEL07ASM04",   :limit => 10
    t.string  "MODEL07ASM05",   :limit => 10
    t.string  "MODEL08ASM01",   :limit => 10
    t.string  "MODEL08ASM02",   :limit => 10
    t.string  "MODEL08ASM03",   :limit => 10
    t.string  "MODEL08ASM04",   :limit => 10
    t.string  "MODEL08ASM05",   :limit => 10
    t.string  "MODEL09ASM01",   :limit => 10
    t.string  "MODEL09ASM02",   :limit => 10
    t.string  "MODEL09ASM03",   :limit => 10
    t.string  "MODEL09ASM04",   :limit => 10
    t.string  "MODEL09ASM05",   :limit => 10
    t.string  "MODEL10ASM01",   :limit => 10
    t.string  "MODEL10ASM02",   :limit => 10
    t.string  "MODEL10ASM03",   :limit => 10
    t.string  "MODEL10ASM04",   :limit => 10
    t.string  "MODEL10ASM05",   :limit => 10
    t.string  "MODEL11ASM01",   :limit => 10
    t.string  "MODEL11ASM02",   :limit => 10
    t.string  "MODEL11ASM03",   :limit => 10
    t.string  "MODEL11ASM04",   :limit => 10
    t.string  "MODEL11ASM05",   :limit => 10
    t.string  "MODEL12ASM01",   :limit => 10
    t.string  "MODEL12ASM02",   :limit => 10
    t.string  "MODEL12ASM03",   :limit => 10
    t.string  "MODEL12ASM04",   :limit => 10
    t.string  "MODEL12ASM05",   :limit => 10
    t.string  "MODEL13ASM01",   :limit => 10
    t.string  "MODEL13ASM02",   :limit => 10
    t.string  "MODEL13ASM03",   :limit => 10
    t.string  "MODEL13ASM04",   :limit => 10
    t.string  "MODEL13ASM05",   :limit => 10
    t.string  "MODEL14ASM01",   :limit => 10
    t.string  "MODEL14ASM02",   :limit => 10
    t.string  "MODEL14ASM03",   :limit => 10
    t.string  "MODEL14ASM04",   :limit => 10
    t.string  "MODEL14ASM05",   :limit => 10
    t.string  "MODEL15ASM01",   :limit => 10
    t.string  "MODEL15ASM02",   :limit => 10
    t.string  "MODEL15ASM03",   :limit => 10
    t.string  "MODEL15ASM04",   :limit => 10
    t.string  "MODEL15ASM05",   :limit => 10
    t.string  "MODEL16ASM01",   :limit => 10
    t.string  "MODEL16ASM02",   :limit => 10
    t.string  "MODEL16ASM03",   :limit => 10
    t.string  "MODEL16ASM04",   :limit => 10
    t.string  "MODEL16ASM05",   :limit => 10
    t.string  "MODEL17ASM01",   :limit => 10
    t.string  "MODEL17ASM02",   :limit => 10
    t.string  "MODEL17ASM03",   :limit => 10
    t.string  "MODEL17ASM04",   :limit => 10
    t.string  "MODEL17ASM05",   :limit => 10
    t.string  "MODEL18ASM01",   :limit => 10
    t.string  "MODEL18ASM02",   :limit => 10
    t.string  "MODEL18ASM03",   :limit => 10
    t.string  "MODEL18ASM04",   :limit => 10
    t.string  "MODEL18ASM05",   :limit => 10
    t.string  "MODEL19ASM01",   :limit => 10
    t.string  "MODEL19ASM02",   :limit => 10
    t.string  "MODEL19ASM03",   :limit => 10
    t.string  "MODEL19ASM04",   :limit => 10
    t.string  "MODEL19ASM05",   :limit => 10
    t.string  "MODEL20ASM01",   :limit => 10
    t.string  "MODEL20ASM02",   :limit => 10
    t.string  "MODEL20ASM03",   :limit => 10
    t.string  "MODEL20ASM04",   :limit => 10
    t.string  "MODEL20ASM05",   :limit => 10
    t.string  "Reserve01",      :limit => 100
    t.string  "Reserve02",      :limit => 100
    t.integer "SubSeq",         :limit => 4
    t.string  "XchgFlag",       :limit => 4
    t.integer "InstructFlag",   :limit => 4
    t.string  "FileName"
  end

  add_index "T_Production_DAT", ["ProductionDate", "ProductionTime", "SeqNo", "SubSeq"], :name => "SK_T_Production_DAT", :unique => true
  add_index "T_Production_DAT", ["SeqNo", "ModelYear", "SuffixCode", "MODEL01ASM01", "ProductionDate", "ProductionTime"], :name => "IX_IDX_Production"
  add_index "T_Production_DAT", ["XchgFlag"], :name => "IX_XchgFlag"

end
