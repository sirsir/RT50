class CreateTableTParameterRow < ActiveRecord::Migration
  def self.up
    create_table "T_PARAMETER_ROW", :id => false, :force => true do |t|
      t.string "MODEL_CODE",  :limit => 8, :null => false
      t.string "MODEL_YEAR",  :limit => 3, :null => false
      t.string "SUFFIX_CODE", :limit => 5, :null => false
    end

    execute sql_create_parameter_row_pk
  end

  def self.down
    drop_table "T_PARAMETER_ROW"
  end

  def self.sql_create_parameter_row_pk
    "ALTER TABLE T_PARAMETER_ROW ADD CONSTRAINT PK_T_PARAMETER_ROW PRIMARY KEY NONCLUSTERED
      (
        MODEL_CODE ASC

      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]"

  end
end
