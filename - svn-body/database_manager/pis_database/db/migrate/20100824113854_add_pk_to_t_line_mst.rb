class AddPkToTLineMst < ActiveRecord::Migration
  def self.up
    execute "
ALTER TABLE T_Line_MST ADD CONSTRAINT
 PK_T_Line_MST PRIMARY KEY CLUSTERED
(
	LineCode ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
 ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]      "
  end

  def self.down
    execute "ALTER TABLE T_Line_MST
DROP CONSTRAINT PK_T_Line_MST"
  end
end
