class ChangeColumnTOptionMstOptionDisplayToNotNull < ActiveRecord::Migration
  def self.up
    change_column "T_OPTION_MST", :OPTION_DISPLAY, :string, :limit => 15, :null => false
  end

  def self.down
    change_column "T_OPTION_MST", :OPTION_DISPLAY, :string, :limit => 15, :null => true
  end
end
