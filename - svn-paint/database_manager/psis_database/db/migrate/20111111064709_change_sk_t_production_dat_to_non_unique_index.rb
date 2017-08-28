class ChangeSkTProductionDatToNonUniqueIndex < ActiveRecord::Migration
  def self.up
    execute sql_drop_production_sk
    execute sql_create_production_sk_up
  end

  def self.down
    execute sql_drop_production_sk
    execute sql_create_production_sk_down
  end
  
   def self.sql_create_production_sk_up
    "
CREATE CLUSTERED INDEX [SK_T_PRODUCTION_DAT] ON [dbo].[T_PRODUCTION_DAT]
(
  [PRODUCTION_DATE] ASC,
  [ON_TIME] ASC
) ON [PRIMARY]
    "
  end
  
   def self.sql_create_production_sk_down
    "
CREATE UNIQUE CLUSTERED INDEX [SK_T_PRODUCTION_DAT] ON [dbo].[T_PRODUCTION_DAT]
(
  [PRODUCTION_DATE] ASC,
  [ON_TIME] ASC
) ON [PRIMARY]
    "
  end

     def self.sql_drop_production_sk
    "
        DROP INDEX [SK_T_PRODUCTION_DAT] ON [dbo].[T_PRODUCTION_DAT] WITH ( ONLINE = OFF )
    "
  end
end
