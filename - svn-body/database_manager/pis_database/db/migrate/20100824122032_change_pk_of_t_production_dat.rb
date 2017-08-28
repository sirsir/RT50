class ChangePkOfTProductionDat < ActiveRecord::Migration
  def self.up
    execute"
ALTER TABLE T_Production_DAT
DROP CONSTRAINT PK_T_Production_DAT
    "

    execute"
ALTER TABLE T_Production_DAT ADD CONSTRAINT
 PK_T_Production_DAT PRIMARY KEY CLUSTERED
(
	ModelYear ASC,
	SuffixCode ASC,
	LotNo ASC,
	Unit ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
 ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    "
  end

  def self.down
    execute"
ALTER TABLE T_Production_DAT
DROP CONSTRAINT PK_T_Production_DAT
    "

    execute"
ALTER TABLE T_Production_DAT ADD CONSTRAINT
 PK_T_Production_DAT PRIMARY KEY CLUSTERED
(
	SeqNo ASC,
	ModelYear ASC,
	SuffixCode ASC,
	LotID ASC,
	LotNo ASC,
	Unit ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
 ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    "
  end
end
