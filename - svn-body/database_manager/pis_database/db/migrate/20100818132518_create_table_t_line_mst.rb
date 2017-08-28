class CreateTableTLineMst < ActiveRecord::Migration
  def self.up
    create_table "T_Line_MST", :id=>false, :force=>true do |t|
      t.integer "LineCode", :limit => 4,  :null => false
      t.string  "LineName", :limit => 60
    end
  end

  def self.down
    drop_table(:T_Line_MST)
  end
end
