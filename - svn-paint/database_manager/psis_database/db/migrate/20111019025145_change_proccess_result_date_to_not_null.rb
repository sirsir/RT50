class ChangeProccessResultDateToNotNull < ActiveRecord::Migration
  def self.up
    execute sql_drop_process_result_date_clustered_index
    change_column "T_PAINT_CELL", :PROCESS_RESULT_DATE, :datetime, :null => false
    execute sql_create_process_result_date_clustered_index
  end

  def self.down
    execute sql_drop_process_result_date_clustered_index
    change_column "T_PAINT_CELL", :PROCESS_RESULT_DATE, :datetime, :null => true
    execute sql_create_process_result_date_clustered_index
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
