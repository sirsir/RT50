class AddColumnLabelNameToTProcessMst < ActiveRecord::Migration
  def self.up
    add_column "T_PROCESS_MST", :LABEL_NAME, :string, :limit => 20, :null => true
    add_index("T_PROCESS_MST", :LABEL_NAME, :unique => false, :name => 'IDX_LABEL_NAME')

  end

  def self.down
    remove_column("T_PROCESS_MST", :LABEL_NAME)
  end
end
