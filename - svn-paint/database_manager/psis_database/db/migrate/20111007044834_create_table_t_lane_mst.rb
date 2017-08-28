class CreateTableTLaneMst < ActiveRecord::Migration
  def self.up
    create_table  "T_LANE_MST", :id => false, :force => true do |t|
      t.integer   "LANE_NO",  :null => false
    end

    execute sql_create_lane_pk
  end

  def self.down
    drop_table("T_LANE_MST")
  end

  def self.sql_create_lane_pk
    "ALTER TABLE [T_LANE_MST] ADD CONSTRAINT
      PK_T_LANE_MST PRIMARY KEY CLUSTERED
    (
        LANE_NO ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
  end
end
