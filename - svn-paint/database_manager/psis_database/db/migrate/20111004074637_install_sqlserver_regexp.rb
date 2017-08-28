migration_version = File.basename(__FILE__).split('_')[0]
ENV['ASSEMBLIES_PATH'] = File.join('db/assemblies', migration_version)

class InstallSqlserverRegexp < ActiveRecord::Migration
  def self.up
    ActiveRecord::Base.connection.rollback_db_transaction if ActiveRecord::Base.connection.supports_ddl_transactions?
      # Enable CLR Integration
    execute "
exec sp_configure 'clr enabled', 1
    "
    execute "
RECONFIGURE
    "

    # Create the Assembly
    assemblies_path = File.join(ENV['ASSEMBLIES_PATH'], 'sqlserver_regexp.dll')
    assemblies_path = File.expand_path(assemblies_path).gsub("/","\\")
    execute "
CREATE ASSEMBLY [sqlserver_regexp] FROM '#{assemblies_path}' WITH PERMISSION_SET = SAFE
    "

    # Create the Functions
    execute "
CREATE FUNCTION [dbo].[RegexMatch](@input [nvarchar](max), @pattern [nvarchar](4000))
RETURNS [bit] WITH EXECUTE AS CALLER
AS
EXTERNAL NAME [sqlserver_regexp].[sqlserver_regexp.UserDefinedFunctions].[RegexMatch]
    "
    execute "
CREATE FUNCTION [dbo].[RegexReplace](@expression [nvarchar](4000), @pattern [nvarchar](4000), @replace [nvarchar](4000))
RETURNS [nvarchar](4000) WITH EXECUTE AS CALLER
AS
EXTERNAL NAME [sqlserver_regexp].[sqlserver_regexp.UserDefinedFunctions].[RegexReplace]
    "
    execute "
CREATE FUNCTION [dbo].[RegexSelectAll](@input [nvarchar](max), @pattern [nvarchar](4000), @matchDelimiter [nvarchar](4000))
RETURNS [nvarchar](4000) WITH EXECUTE AS CALLER
AS
EXTERNAL NAME [sqlserver_regexp].[sqlserver_regexp.UserDefinedFunctions].[RegexSelectAll]
    "
    execute "
CREATE FUNCTION [dbo].[RegexSelectOne](@input [nvarchar](max), @pattern [nvarchar](4000), @matchIndex [int])
RETURNS [nvarchar](4000) WITH EXECUTE AS CALLER
AS
EXTERNAL NAME [sqlserver_regexp].[sqlserver_regexp.UserDefinedFunctions].[RegexSelectOne]
    "

    execute "
    CREATE FUNCTION [dbo].[fnc_compare_model_pattern]
(@model_year varchar(3), @suffix_code varchar(5), @pattern_year varchar(3), @pattern_suffix_code varchar(5))
RETURNS bit
AS
BEGIN
	-- Declare the return variable
    DECLARE @result bit

    DECLARE @model_code varchar(8)
    DECLARE @pattern_model_code varchar(8)

    SET @model_code = @model_year + @suffix_code
    SET @pattern_model_code = REPLACE(@pattern_year + @pattern_suffix_code, '*', '.')

    SET @result = dbo.RegexMatch(@model_code, @pattern_model_code)

	RETURN @result
END
    "
    ActiveRecord::Base.connection.begin_db_transaction if ActiveRecord::Base.connection.supports_ddl_transactions?
 end

  def self.down
     function_list.each do |fn|
          execute "
            DROP FUNCTION [dbo].[#{fn[:name]}]
          "
     end

     execute "
        DROP ASSEMBLY [sqlserver_regexp]
      "
  end

    def self.function_list
    [
      {
        :name =>'fnc_compare_model_pattern'
      },
      {
        :name =>'RegexMatch'
      },
      {
        :name =>'RegexReplace'
      },
      {
        :name =>'RegexSelectAll'
      },
      {
        :name =>'RegexSelectOne'
      }

    ]
  end
end
