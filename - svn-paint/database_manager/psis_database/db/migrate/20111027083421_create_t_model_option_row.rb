class CreateTModelOptionRow < ActiveRecord::Migration
  def self.up
    create_table "T_MODEL_OPTION_ROW", :primary_key => "MODEL_OPTION_ROW_ID", :force => true do |t|
      t.string  "MODEL_YEAR_PATTERN", :limit => 3, :null => false
      t.string  "SUFFIX_CODE_PATTERN", :limit => 5, :null => false
    end
  end

  def self.down
    drop_table "T_MODEL_OPTION_ROW"
  end
end
