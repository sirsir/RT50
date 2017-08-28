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

ActiveRecord::Schema.define(:version => 20111118035002) do

  create_table "T_LANE_MST", :id => false, :force => true do |t|
    t.integer "LANE_NO", :limit => 4, :null => false
  end

  create_table "T_LOG_DAT", :primary_key => "LOG_ID", :force => true do |t|
    t.integer  "LOG_TYPE",   :limit => 4,  :null => false
    t.integer  "LOG_LEVEL",  :limit => 4,  :null => false
    t.string   "PC_NAME"
    t.datetime "OCC_DATE",                 :null => false
    t.string   "LOG_CODE",   :limit => 15, :null => false
    t.string   "MESSAGE",                  :null => false
    t.integer  "PROCESS_NO", :limit => 4
  end

  create_table "T_MESSAGE_MST", :id => false, :force => true do |t|
    t.string "LOG_CODE",    :limit => 15, :null => false
    t.string "LOG_MESSAGE",               :null => false
  end

  create_table "T_MODEL_OPTION_CELL", :id => false, :force => true do |t|
    t.integer "MODEL_OPTION_ROW_ID", :limit => 4,                    :null => false
    t.integer "OPTION_ID",           :limit => 4,                    :null => false
    t.boolean "IS_USED",                          :default => false, :null => false
  end

  create_table "T_MODEL_OPTION_ROW", :primary_key => "MODEL_OPTION_ROW_ID", :force => true do |t|
    t.string "MODEL_YEAR_PATTERN",  :limit => 3, :null => false
    t.string "SUFFIX_CODE_PATTERN", :limit => 5, :null => false
  end

  create_table "T_OPTION_MST", :primary_key => "OPTION_ID", :force => true do |t|
    t.string  "OPTION_NAME",    :limit => 15, :null => false
    t.integer "OPTION_SEQ",     :limit => 4,  :null => false
    t.string  "OPTION_CODE",    :limit => 32
    t.string  "OPTION_DISPLAY", :limit => 15, :null => false
    t.integer "OPTION_TYPE",    :limit => 4,  :null => false
  end

  add_index "T_OPTION_MST", ["OPTION_SEQ"], :name => "IDX_T_OPTION_MST_OPTION_SEQ"
  add_index "T_OPTION_MST", ["OPTION_TYPE"], :name => "IDX_T_OPTION_MST_OPTION_TYPE"

  create_table "T_PAINT_CELL", :id => false, :force => true do |t|
    t.string   "MODEL_YEAR",          :limit => 3, :null => false
    t.string   "SUFFIX_CODE",         :limit => 5, :null => false
    t.string   "LOT_NO",              :limit => 3, :null => false
    t.string   "UNIT",                :limit => 3, :null => false
    t.integer  "PROCESS_NO",          :limit => 4, :null => false
    t.datetime "PROCESS_RESULT_DATE",              :null => false
  end

  add_index "T_PAINT_CELL", ["PROCESS_NO"], :name => "IDX_PROCESS_NO"
  add_index "T_PAINT_CELL", ["PROCESS_RESULT_DATE"], :name => "IDX_PROCES_RESULT_DATE"

  create_table "T_PLC_MST", :primary_key => "PLC_ID", :force => true do |t|
    t.integer "STAGE_CODE",      :limit => 4,                   :null => false
    t.integer "PLC_NET",         :limit => 4,                   :null => false
    t.integer "PLC_NODE",        :limit => 4,                   :null => false
    t.integer "PLC_UNIT",        :limit => 4,                   :null => false
    t.integer "READ_DM",         :limit => 4,                   :null => false
    t.integer "WRITE_DATA_DM",   :limit => 4,                   :null => false
    t.integer "WRITE_STATUS_DM", :limit => 4,                   :null => false
    t.integer "PROCESS_NO",      :limit => 4,                   :null => false
    t.boolean "PLC_ONLINE_FLAG",              :default => true, :null => false
  end

  add_index "T_PLC_MST", ["STAGE_CODE"], :name => "IDX_STAGE_CODE", :unique => true

  create_table "T_PROCESS_GROUP_MST", :primary_key => "PROCESS_GROUP_ID", :force => true do |t|
    t.integer "PROCESS_GROUP_SEQ",  :limit => 4,  :null => false
    t.string  "PROCESS_GROUP_NAME", :limit => 20, :null => false
  end

  add_index "T_PROCESS_GROUP_MST", ["PROCESS_GROUP_SEQ"], :name => "IDX_PROCESS_GROUP_SEQ", :unique => true

  create_table "T_PROCESS_LINKAGE", :id => false, :force => true do |t|
    t.integer "FROM_PROCESS_NO", :limit => 4, :null => false
    t.integer "TO_PROCESS_NO",   :limit => 4, :null => false
  end

  create_table "T_PROCESS_MST", :primary_key => "PROCESS_NO", :force => true do |t|
    t.string  "PROCESS_NAME",     :limit => 60,                    :null => false
    t.integer "PROCESS_TIME",     :limit => 4,                     :null => false
    t.integer "PROCESS_TYPE",     :limit => 4,  :default => 0,     :null => false
    t.boolean "ENTRANCE_FLAG",                  :default => false, :null => false
    t.integer "PROCESS_CODE",     :limit => 4,                     :null => false
    t.integer "PROCESS_GROUP_ID", :limit => 4,                     :null => false
  end

  add_index "T_PROCESS_MST", ["PROCESS_CODE"], :name => "IDX_PROCESS_CODE", :unique => true

  create_table "T_PROCESS_OPTION_CELL", :id => false, :force => true do |t|
    t.integer "PROCESS_NO", :limit => 4,                    :null => false
    t.integer "OPTION_ID",  :limit => 4,                    :null => false
    t.boolean "IS_USED",                 :default => false, :null => false
  end

  create_table "T_PRODUCTION_DAT", :id => false, :force => true do |t|
    t.string "SEQ_NO",              :limit => 5
    t.string "MODEL_YEAR",          :limit => 3,  :null => false
    t.string "SUFFIX_CODE",         :limit => 5,  :null => false
    t.string "LOT_ID",              :limit => 3
    t.string "LOT_NO",              :limit => 3,  :null => false
    t.string "UNIT",                :limit => 3,  :null => false
    t.string "BLOCK_MODEL",         :limit => 8
    t.string "BLOCK_SEQ",           :limit => 3
    t.string "MARK",                :limit => 3
    t.string "PRODUCTION_DATE",     :limit => 8
    t.string "SHIFT",               :limit => 1
    t.string "ON_TIME",             :limit => 4
    t.string "IMPORT_CODE",         :limit => 10
    t.string "Y_CHASSIS_FLAG",      :limit => 1
    t.string "GA_SHOP",             :limit => 2
    t.string "BODY_SHOP_CODE",      :limit => 2
    t.string "HANDLE_TYPE",         :limit => 2
    t.string "BODY_COLOR_TC_SW",    :limit => 3
    t.string "BODY_COLOR_SEQ",      :limit => 3
    t.string "BODY_COLOR_OPT",      :limit => 3
    t.string "BODY_COLOR_NAME",     :limit => 20
    t.string "SURFACE_COLOR_SF_SW", :limit => 3
    t.string "SURFACE_COLOR_XXX",   :limit => 3
    t.string "SURFACE_COLOR_NAME",  :limit => 20
    t.string "FILE_NAME"
  end

  add_index "T_PRODUCTION_DAT", ["BLOCK_MODEL", "BLOCK_SEQ"], :name => "IDX_BLOCK_MODEL_BLOCK_SEQ"
  add_index "T_PRODUCTION_DAT", ["BLOCK_MODEL"], :name => "IDX_BLOCK_MODEL"
  add_index "T_PRODUCTION_DAT", ["BLOCK_SEQ"], :name => "IDX_BLOCK_SEQ"
  add_index "T_PRODUCTION_DAT", ["LOT_NO"], :name => "IDX_LOT_NO"
  add_index "T_PRODUCTION_DAT", ["MODEL_YEAR"], :name => "IDX_MODEL_YEAR"
  add_index "T_PRODUCTION_DAT", ["PRODUCTION_DATE", "ON_TIME"], :name => "SK_T_PRODUCTION_DAT"
  add_index "T_PRODUCTION_DAT", ["SUFFIX_CODE"], :name => "IDX_SUFFIX_CODE"
  add_index "T_PRODUCTION_DAT", ["UNIT"], :name => "IDX_UNIT"

  create_table "T_SKIT_MST", :id => false, :force => true do |t|
    t.integer "SKIT_NO",     :limit => 4, :null => false
    t.string  "MODEL_YEAR",  :limit => 3
    t.string  "SUFFIX_CODE", :limit => 5
    t.string  "LOT_NO",      :limit => 3
    t.string  "UNIT",        :limit => 3
  end

  create_table "T_WBS_ON", :id => false, :force => true do |t|
    t.integer "LANE_NO",  :limit => 4, :null => false
    t.integer "SEQUENCE", :limit => 4, :null => false
    t.integer "SKIT_NO",  :limit => 4, :null => false
  end

  add_index "T_WBS_ON", ["SKIT_NO"], :name => "IDX_SKIT_NO", :unique => true

end
