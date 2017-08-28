class CreateTableTPaintDat < ActiveRecord::Migration
  def self.up
    create_table "T_PAINT_DAT", :id => false, :force => true do |t|
      t.integer "SKIT_NO",   :null => false
      t.integer  "PROCESS_NO",      :null => false
      t.datetime "PROCESS_ON_DATE",     :null => false
      t.datetime "PROCESS_OFF_DATE",    :null => true
    end

    execute sql_create_paint_pk

    add_index("T_PAINT_DAT", "PROCESS_NO", :name => "IDX_PROCESS_NO")
    add_index("T_PAINT_DAT", "PROCESS_ON_DATE", :name => "IDX_PROCESS_NO")
    add_index("T_PAINT_DAT", "SKIT_NO", :name => "IDX_PROCESS_NO")

    execute sql_create_process_fk
    execute sql_check_process_fk
  end

  def self.down
    drop_table "T_PAINT_DAT"
  end

  def self.sql_create_paint_pk
    "ALTER TABLE T_PAINT_DAT ADD CONSTRAINT PK_T_PAINT_DAT PRIMARY KEY NONCLUSTERED
      (
        PROCESS_NO ASC,
        PROCESS_ON_DATE ASC,
        SKIT_NO ASC

      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]"
  end

  def self.sql_create_process_fk
    "
    ALTER TABLE [T_PAINT_DAT]  WITH CHECK ADD  CONSTRAINT [PROCESS_FKEY_T_PAINT_DAT] FOREIGN KEY([PROCESS_NO])
      REFERENCES [T_PROCESS_MST] ([PROCESS_NO])
    "
  end

  def self.sql_check_process_fk
    "ALTER TABLE [T_PAINT_DAT] CHECK CONSTRAINT [PROCESS_FKEY_T_PAINT_DAT]"
  end
end
