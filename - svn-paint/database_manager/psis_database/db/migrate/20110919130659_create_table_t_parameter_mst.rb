class CreateTableTParameterMst < ActiveRecord::Migration
  def self.up
    create_table "T_PARAMETER_MST", :id => false, :force => true do |t|
      t.string  "MODEL_CODE",     :limit => 8, :null => false
      t.string  "MODEL_YEAR",     :limit => 3, :null => false
      t.string  "SUFFIX_CODE",    :limit => 5, :null => false
      t.integer "PROCESS_NO",     :null => false
      t.string  "PARAMETER",       :limit => 10, :null =>false
    end

    execute sql_create_parameter_pk
    execute sql_create_parameter_sk
    execute sql_create_process_fk
    execute sql_check_process_fk

    add_index("T_PARAMETER_MST", "MODEL_YEAR", :name => "IDX_MODEL_YEAR")
    add_index("T_PARAMETER_MST", "SUFFIX_CODE", :name => "IDX_SUFFIX_CODE")

  end

  def self.down
    drop_table "T_PARAMETER_MST"
  end

  def self.sql_create_parameter_pk
    "ALTER TABLE T_PARAMETER_MST ADD CONSTRAINT
       PK_T_PARAMETER_MST PRIMARY KEY NONCLUSTERED
      (
        MODEL_CODE ASC
      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
  end

  def self.sql_create_parameter_sk
    "
      CREATE UNIQUE CLUSTERED INDEX [SK_T_PARAMETER_MST] ON [dbo].[T_PARAMETER_MST]
      (
        [MODEL_CODE] ASC,
        [PROCESS_NO] ASC
      ) ON [PRIMARY]
    "
  end

  def self.sql_create_process_fk
    "
    ALTER TABLE [T_PARAMETER_MST]  WITH CHECK ADD  CONSTRAINT [PROCESS_FKEY_T_PARAMETER_MST] FOREIGN KEY([PROCESS_NO])
      REFERENCES [T_PROCESS_MST] ([PROCESS_NO])
    "
  end

  def self.sql_check_process_fk
    "ALTER TABLE [T_PARAMETER_MST] CHECK CONSTRAINT [PROCESS_FKEY_T_PARAMETER_MST]"
  end
end
