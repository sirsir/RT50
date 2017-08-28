migration_version = File.basename(__FILE__).split('_')[0]
ENV['ASSEMBLIES_PATH'] = File.join('db/assemblies', migration_version)

class AddTriggerToTLineMstToFlushData < ActiveRecord::Migration
  def self.up
    new_connection do |conn|
      # Enable CLR Integration
      conn.execute "
exec sp_configure 'clr enabled', 1
      "
      conn.execute "
RECONFIGURE
      "

      # Create the Assembly
      assemblies_path = File.join(ENV['ASSEMBLIES_PATH'], 'pis_database_programmability.dll')
      assemblies_path = File.expand_path(assemblies_path).gsub("/","\\")

      #puts assemblies_path
      #  if (RAILS_ENV == "development") then
      #       assemblies_path = assemblies_path.gsub("E:","D:")
      #  end
      conn.execute "
CREATE ASSEMBLY [pis_database_programmability] FROM '#{assemblies_path}' WITH PERMISSION_SET = SAFE
      "

      # Create the Functions
      conn.execute "
CREATE TRIGGER [dbo].[trgFlushAllData] ON [dbo].[T_Line_MST]  AFTER  INSERT, UPDATE AS
EXTERNAL NAME [pis_database_programmability].[TSE.dotnet.OMRON.DatabaseProgrammability.pis_database.Triggers].[trgFlushAllData]
      "
        conn.execute "
EXEC sys.sp_addextendedproperty @name=N'AutoDeployed', @value=N'yes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Line_MST', @level2type=N'TRIGGER',@level2name=N'trgFlushAllData'
        "
        conn.execute "
EXEC sys.sp_addextendedproperty @name=N'SqlAssemblyFile', @value=N'Trigger\trgFlushAllData.vb' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Line_MST', @level2type=N'TRIGGER',@level2name=N'trgFlushAllData'
        "
        conn.execute "
EXEC sys.sp_addextendedproperty @name=N'SqlAssemblyFileLine', @value=51 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Line_MST', @level2type=N'TRIGGER',@level2name=N'trgFlushAllData'
        "

    end
  end

  def self.down
    new_connection do |conn|
      conn.execute "
DROP TRIGGER [dbo].[trgFlushAllData]
        "
      conn.execute "
DROP ASSEMBLY [pis_database_programmability]
      "
      end
   end
end
