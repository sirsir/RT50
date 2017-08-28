class CreateIdxSkitNoOnTWbsOn < ActiveRecord::Migration
  def self.up
    execute sql_create_idx_skit_no
  end

  def self.down
    execute sql_drop_idx_skit_no
  end

  def self.sql_create_idx_skit_no
    "
CREATE UNIQUE NONCLUSTERED INDEX [IDX_SKIT_NO] ON [dbo].[T_WBS_ON]
(
  [SKIT_NO] ASC
) ON [PRIMARY]
    "
  end

  def self.sql_drop_idx_skit_no
    "
        DROP INDEX [IDX_SKIT_NO] ON [dbo].[T_WBS_ON] WITH ( ONLINE = OFF )
    "
  end
end
