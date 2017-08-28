class AddStageCodeMakeProcessNoAnIdAndAddEntranceFlagToTProcessMst < ActiveRecord::Migration
  def self.up
    execute sql_drop_t_parameter_cell_process_no_fk
    execute sql_drop_t_paint_cell_process_no_fk
    execute sql_drop_t_process_linkage_from_process_no_fk
    execute sql_drop_t_process_linkage_to_process_no_fk
    execute sql_drop_pk_t_process_mst

    rename_column("T_PROCESS_MST", :PROCESS_NO, :STAGE_CODE)
    execute sql_add_t_process_mst_process_no_as_id
    execute sql_create_t_process_mst_process_no_pk

    execute sql_create_t_process_linkage_from_process_no_fk
    execute sql_check_t_process_linkage_from_process_no_fk
    execute sql_create_t_process_linkage_to_process_no_fk
    execute sql_check_t_process_linkage_to_process_no_fk
    execute sql_create_t_paint_cell_process_no_fk
    execute sql_check_t_paint_cell_process_no_fk
    execute sql_create_t_parameter_cell_process_no_fk
    execute sql_check_t_parameter_cell_process_no_fk
  end

  def self.down
    execute sql_drop_t_parameter_cell_process_no_fk
    execute sql_drop_t_paint_cell_process_no_fk
    execute sql_drop_t_process_linkage_from_process_no_fk
    execute sql_drop_t_process_linkage_to_process_no_fk
    execute sql_drop_pk_t_process_mst

    remove_column("T_PROCESS_MST", :PROCESS_NO)
    rename_column("T_PROCESS_MST", :STAGE_CODE, :PROCESS_NO)
    execute sql_create_t_process_mst_process_no_pk

    execute sql_create_t_process_linkage_from_process_no_fk
    execute sql_check_t_process_linkage_from_process_no_fk
    execute sql_create_t_process_linkage_to_process_no_fk
    execute sql_check_t_process_linkage_to_process_no_fk
    execute sql_create_t_paint_cell_process_no_fk
    execute sql_check_t_paint_cell_process_no_fk
    execute sql_create_t_parameter_cell_process_no_fk
    execute sql_check_t_parameter_cell_process_no_fk
  end

  def self.sql_add_t_process_mst_process_no_as_id
    "ALTER TABLE dbo.T_PROCESS_MST ADD
      PROCESS_NO int NOT NULL IDENTITY (1, 1)"
  end

  def self.sql_create_t_process_mst_process_no_pk
    "ALTER TABLE T_PROCESS_MST ADD CONSTRAINT
     PK_T_PROCESS_MST PRIMARY KEY CLUSTERED
      (
        PROCESS_NO ASC
      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]      "
  end

  def self.sql_drop_t_parameter_cell_process_no_fk
    "ALTER TABLE T_PARAMETER_CELL DROP CONSTRAINT [FK_T_PARAMETER_CELL_PROCESS_NO]"
  end

  def self.sql_drop_t_paint_cell_process_no_fk
    "ALTER TABLE T_PAINT_CELL DROP CONSTRAINT [FK_T_PAINT_CELL_PROCESS_NO]"
  end

  def self.sql_drop_t_process_linkage_from_process_no_fk
    "ALTER TABLE T_PROCESS_LINKAGE DROP CONSTRAINT [FK_T_PROCESS_LINKAGE_FROM_PROCESS_NO]"
  end

  def self.sql_drop_t_process_linkage_to_process_no_fk
    "ALTER TABLE T_PROCESS_LINKAGE DROP CONSTRAINT [FK_T_PROCESS_LINKAGE_TO_PROCESS_NO]"
  end

  def self.sql_drop_pk_t_process_mst
    "
      ALTER TABLE [T_PROCESS_MST] DROP CONSTRAINT PK_T_PROCESS_MST
    "
  end

  def self.sql_create_t_process_linkage_from_process_no_fk
    "
    ALTER TABLE [T_PROCESS_LINKAGE]  WITH CHECK ADD  CONSTRAINT [FK_T_PROCESS_LINKAGE_FROM_PROCESS_NO] FOREIGN KEY([FROM_PROCESS_NO])
      REFERENCES [T_PROCESS_MST] ([PROCESS_NO])
    "
  end

  def self.sql_check_t_process_linkage_from_process_no_fk
    "ALTER TABLE [T_PROCESS_LINKAGE] CHECK CONSTRAINT [FK_T_PROCESS_LINKAGE_FROM_PROCESS_NO]"
  end

  def self.sql_create_t_process_linkage_to_process_no_fk
    "
    ALTER TABLE [T_PROCESS_LINKAGE]  WITH CHECK ADD  CONSTRAINT [FK_T_PROCESS_LINKAGE_TO_PROCESS_NO] FOREIGN KEY([TO_PROCESS_NO])
      REFERENCES [T_PROCESS_MST] ([PROCESS_NO])
    "
  end

  def self.sql_check_t_process_linkage_to_process_no_fk
    "ALTER TABLE [T_PROCESS_LINKAGE] CHECK CONSTRAINT [FK_T_PROCESS_LINKAGE_TO_PROCESS_NO]"
  end

  def self.sql_create_t_paint_cell_process_no_fk
    "
    ALTER TABLE [T_PAINT_CELL]  WITH CHECK ADD  CONSTRAINT [FK_T_PAINT_CELL_PROCESS_NO] FOREIGN KEY([PROCESS_NO])
      REFERENCES [T_PROCESS_MST] ([PROCESS_NO])
    "
  end

  def self.sql_check_t_paint_cell_process_no_fk
    "ALTER TABLE [T_PAINT_CELL] CHECK CONSTRAINT [FK_T_PAINT_CELL_PROCESS_NO]"
  end

  def self.sql_create_t_parameter_cell_process_no_fk
    "
    ALTER TABLE [T_PARAMETER_CELL]  WITH CHECK ADD  CONSTRAINT [FK_T_PARAMETER_CELL_PROCESS_NO] FOREIGN KEY([PROCESS_NO])
      REFERENCES [T_PROCESS_MST] ([PROCESS_NO])
    "
  end

  def self.sql_check_t_parameter_cell_process_no_fk
    "ALTER TABLE [T_PARAMETER_CELL] CHECK CONSTRAINT [FK_T_PARAMETER_CELL_PROCESS_NO]"
  end
end
