class AddIndexToTProductionDat < ActiveRecord::Migration
  def self.up
    execute sql_drop_pk_t_production_dat
    execute sql_create_non_clustered_pk_t_production_dat

    execute sql_create_production_sk

    add_index("T_PRODUCTION_DAT", :IN_USE_FLAG, :name => 'IDX_IN_USE_FLAG')
    add_index("T_PRODUCTION_DAT", [:BLOCK_MODEL,:BLOCK_SEQ], :name => 'IDX_BLOCK_MODEL_BLOCK_SEQ')
    add_index("T_PRODUCTION_DAT", :BLOCK_MODEL, :name => 'IDX_BLOCK_MODEL')
    add_index("T_PRODUCTION_DAT", :BLOCK_SEQ, :name => 'IDX_BLOCK_SEQ')
  end

  def self.down
    remove_index("T_PRODUCTION_DAT", :name => 'IDX_IN_USE_FLAG')
    remove_index("T_PRODUCTION_DAT", :name => 'IDX_BLOCK_MODEL_BLOCK_SEQ')
    remove_index("T_PRODUCTION_DAT", :name => 'IDX_BLOCK_MODEL')
    remove_index("T_PRODUCTION_DAT", :name => 'IDX_BLOCK_SEQ')

    execute sql_drop_pk_t_production_dat
    execute sql_drop_production_sk
    execute sql_create_clustered_pk_t_production_dat
  end

  def self.sql_drop_pk_t_production_dat
    "
      ALTER TABLE [T_PRODUCTION_DAT] DROP CONSTRAINT PK_T_PRODUCTION_DAT
    "
  end

  def self.sql_create_non_clustered_pk_t_production_dat
    "
      ALTER TABLE T_PRODUCTION_DAT ADD CONSTRAINT
       PK_T_PRODUCTION_DAT PRIMARY KEY NONCLUSTERED
      (
        MODEL_YEAR ASC,
        SUFFIX_CODE ASC,
        LOT_NO ASC,
        UNIT ASC
      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    "
  end

  def self.sql_create_production_sk
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



  def self.sql_create_clustered_pk_t_production_dat
    "
      ALTER TABLE T_PRODUCTION_DAT ADD CONSTRAINT
       PK_T_PRODUCTION_DAT PRIMARY KEY CLUSTERED
      (
        MODEL_YEAR ASC,
        SUFFIX_CODE ASC,
        LOT_NO ASC,
        UNIT ASC
      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    "
  end

end
