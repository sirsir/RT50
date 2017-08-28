class AddUniqueIndexToTParameterRow < ActiveRecord::Migration
  def self.up
    execute sql_create_parameter_row_sk
  end

  def self.down
    execute sql_drop_parameter_row_sk
  end

  def self.sql_create_parameter_row_sk
    "
CREATE UNIQUE NONCLUSTERED INDEX [SK_T_PARAMETER_ROW] ON [dbo].[T_PARAMETER_ROW]
(
  [MODEL_YEAR_PATTERN] ASC,
  [SUFFIX_CODE_PATTERN] ASC
) ON [PRIMARY]
    "
  end

  def self.sql_drop_parameter_row_sk
    "
        DROP INDEX [SK_T_PARAMETER_ROW] ON [dbo].[T_PARAMETER_ROW] WITH ( ONLINE = OFF )
    "
  end
end
