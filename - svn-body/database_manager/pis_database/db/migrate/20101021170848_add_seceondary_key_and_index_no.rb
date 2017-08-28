class AddSeceondaryKeyAndIndexNo < ActiveRecord::Migration
  def self.up
    execute sql_drop_prod_pk
    execute sql_create_prod_pk(false)
    execute sql_create_prod_sk()
    
    #~ add_column :T_Production_DAT, :skTxt, :string, :limit => 20
    #~ add_column :T_Production_DAT, :indexNo, :integer
    
    #~ add_index :T_Production_DAT, [:skTxt], :name => "IX_T_Production_DAT_skTxt"
    #~ add_index :T_Production_DAT, [:indexNo], :name => "IX_T_Production_DAT_indexNo"
    
    execute sql_drop_insp_pk
    execute sql_create_insp_pk(false)
    execute sql_create_insp_sk()
    
    #~ add_column :T_Instruction_DAT, :indexNo, :integer
    
    #~ add_index :T_Instruction_DAT, [:indexNo], :name => "IX_T_Instruction_DAT_indexNo"
    
    #~ production_dates = select_rows(sql_select_production_dates)
    
    #~ production_dates.each do |production_date|
      #~ update sql_update_prod_sk_txt(production_date)
      #~ update sql_update_prod_index_no(production_date)
      #~ update sql_update_insp_index_no(production_date)
    #~ end
  end

  def self.down
    #remove_index :T_Instruction_DAT, :name => "IX_T_Instruction_DAT_indexNo"
    
    #remove_column :T_Instruction_DAT, :indexNo

    remove_index :T_Instruction_DAT, :name => "SK_T_Instruction_DAT"
    execute sql_drop_insp_pk
    execute sql_create_insp_pk(true)
    
    #~ remove_index :T_Production_DAT, :name => "IX_T_Production_DAT_indexNo"
    #~ remove_index :T_Production_DAT, :name => "IX_T_Production_DAT_skTxt"
    
    #~ remove_column :T_Production_DAT, :indexNo
    #~ remove_column :T_Production_DAT, :skTxt
    
    remove_index :T_Production_DAT, :name => "SK_T_Production_DAT"
    execute sql_drop_prod_pk
    execute sql_create_prod_pk(true)
  end
  
  def self.sql_drop_prod_pk
    "
ALTER TABLE T_Production_DAT
DROP CONSTRAINT PK_T_Production_DAT
    "
  end
  
  def self.sql_drop_insp_pk
    "
ALTER TABLE T_Instruction_DAT
DROP CONSTRAINT PK_T_Instruction_DAT
    "
  end
  
  def self.sql_create_prod_pk(clustered)
    "
ALTER TABLE T_Production_DAT
ADD CONSTRAINT PK_T_Production_DAT PRIMARY KEY #{clustered ? "CLUSTERED" : "NONCLUSTERED"}
(
  ModelYear ASC,
  SuffixCode ASC,
  LotNo ASC,
  Unit ASC
) ON [PRIMARY]
    "
  end
  
  def self.sql_create_insp_pk(clustered)
    "
ALTER TABLE T_Instruction_DAT
ADD CONSTRAINT PK_T_Instruction_DAT PRIMARY KEY #{clustered ? "CLUSTERED" : "NONCLUSTERED"}
(
  [ModelYear] ASC,
  [SuffixCode] ASC,
  [LotNo] ASC,
  [Unit] ASC,
  [Line_No] ASC
) ON [PRIMARY]
    "
  end
  
  def self.sql_create_prod_sk
    "
CREATE UNIQUE CLUSTERED INDEX [SK_T_Production_DAT] ON [dbo].[T_Production_DAT] 
(
  [ProductionDate] ASC,
  [ProductionTime] ASC,
  [SeqNo] ASC,
  [SubSeq] ASC
) ON [PRIMARY]
    "
  end
  
  def self.sql_create_insp_sk
  "
CREATE UNIQUE CLUSTERED INDEX [SK_T_Instruction_DAT] ON [dbo].[T_Instruction_DAT] 
(
  [Line_No] ASC,
  [ProductionDate] ASC,
  [ProductionTime] ASC,
  [SeqNo] ASC,
  [SubSeq] ASC
) ON [PRIMARY]
  "
  end

  def self.sql_update_prod_sk_txt(production_date)
    "
UPDATE pd
SET pd.[skTxt] = pd.productionDate + pd.productionTime + pd.seqNo + 
	CASE WHEN pd.[SubSeq] IS NULL
		THEN ''
		ELSE CASE WHEN pd.[SubSeq] < 10 
				THEN '0'
				ELSE ''
			END + CAST(pd.[SubSeq] AS VARCHAR) 
	END
FROM [T_Production_DAT] pd
WHERE
  pd.[ProductionDate] = '#{production_date}'
    "
  end
  
  def self.sql_update_prod_index_no(production_date)
    "
UPDATE pd
SET pd.[indexNo] = (
				SELECT COUNT(*) AS cnt
				FROM [T_Production_DAT] AS pd_
				WHERE pd_.[skTxt] <= pd.[skTxt]
			)
FROM [T_Production_DAT] pd
WHERE
  pd.[ProductionDate] = '#{production_date}'
    "
  end
  
  def self.sql_update_insp_index_no(production_date)
    "
UPDATE i
SET i.[indexNo] = pd.[indexNo]
FROM [T_Instruction_DAT] i
  LEFT JOIN [T_Production_DAT] pd
    ON i.[ModelYear] = pd.[ModelYear] 
    AND i.[SuffixCode] = pd.[SuffixCode] 
    AND i.[LotNo] = pd.[LotNo] 
    AND i.[Unit] = pd.[Unit] 
WHERE
  i.[ProductionDate] = '#{production_date}'
  AND pd.[ProductionDate] = '#{production_date}'
    "
  end
  
  def self.sql_select_production_dates
    "
SELECT DISTINCT
  pd.[ProductionDate]
FROM [T_Production_DAT] pd
    "
  end
  
end
