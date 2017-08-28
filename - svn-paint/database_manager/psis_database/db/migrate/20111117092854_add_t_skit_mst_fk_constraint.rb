class AddTSkitMstFkConstraint < ActiveRecord::Migration
  def self.up
    execute sql_add_constraint_ck_t_skit_mst

  end

  def self.down
    execute sql_drop_constraint_ck_t_skit_mst
  end

  def self.sql_add_constraint_ck_t_skit_mst
    "ALTER TABLE dbo.T_SKIT_MST ADD CONSTRAINT
	CK_T_SKIT_MST_MODEL_YEAR_SUFFIX_CODE_LOT_NO_UNIT CHECK ((MODEL_YEAR IS NULL
 AND SUFFIX_CODE IS NULL
 AND LOT_NO IS NULL
 AND UNIT IS NULL)
OR
(MODEL_YEAR IS NOT NULL
 AND SUFFIX_CODE IS NOT NULL
 AND LOT_NO IS NOT NULL
 AND UNIT IS NOT NULL))"
  end

  def self.sql_drop_constraint_ck_t_skit_mst
    "ALTER TABLE [dbo].[T_SKIT_MST] DROP CONSTRAINT [CK_T_SKIT_MST_MODEL_YEAR_SUFFIX_CODE_LOT_NO_UNIT]"
#    "ALTER TABLE [dbo].[T_SKIT_MST] DROP CONSTRAINT [CK_T_SKIT_MST]"
  end
end
