class AddProcessNoIndexProcessResultDateIndexInTPaintCell < ActiveRecord::Migration
  def self.up
    execute sql_create_process_result_date_clustered_index
    add_index("T_PAINT_CELL", :PROCESS_NO, :name => "IDX_PROCESS_NO")
  end

  def self.down
    execute sql_drop_process_result_date_clustered_index
    remove_index "T_PAINT_CELL", :name => "IDX_PROCESS_NO"
  end

  def self.sql_create_process_result_date_clustered_index
    "
      CREATE CLUSTERED INDEX [IDX_PROCES_RESULT_DATE] ON [dbo].[T_PAINT_CELL]
      (
        [PROCESS_RESULT_DATE] ASC
      ) ON [PRIMARY]
    "
  end

  def self.sql_drop_process_result_date_clustered_index
    "
        DROP INDEX [IDX_PROCES_RESULT_DATE] ON [dbo].[T_PAINT_CELL] WITH ( ONLINE = OFF )
    "
  end
end
