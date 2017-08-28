class AddFkToTProcessLinkage < ActiveRecord::Migration
  def self.up
    execute sql_create_from_process_fk
    execute sql_check_from_process_fk

    execute sql_create_to_process_fk
    execute sql_check_to_process_fk
  end

  def self.down
    execute sql_drop_from_process_fk
    execute sql_drop_to_process_fk
  end

  def self.sql_create_from_process_fk
    "
    ALTER TABLE [T_PROCESS_LINKAGE]  WITH CHECK ADD  CONSTRAINT [FK_T_PROCESS_LINKAGE_FROM_PROCESS_NO] FOREIGN KEY([FROM_PROCESS_NO])
      REFERENCES [T_PROCESS_MST] ([PROCESS_NO])
    "
  end

  def self.sql_check_from_process_fk
    "ALTER TABLE [T_PROCESS_LINKAGE] CHECK CONSTRAINT [FK_T_PROCESS_LINKAGE_FROM_PROCESS_NO]"
  end

  def self.sql_drop_from_process_fk
     "ALTER TABLE [T_PROCESS_LINKAGE] DROP CONSTRAINT [FK_T_PROCESS_LINKAGE_FROM_PROCESS_NO]"
  end

  def self.sql_create_to_process_fk
    "
    ALTER TABLE [T_PROCESS_LINKAGE]  WITH CHECK ADD  CONSTRAINT [FK_T_PROCESS_LINKAGE_TO_PROCESS_NO] FOREIGN KEY([TO_PROCESS_NO])
      REFERENCES [T_PROCESS_MST] ([PROCESS_NO])
    "
  end

  def self.sql_check_to_process_fk
    "ALTER TABLE [T_PROCESS_LINKAGE] CHECK CONSTRAINT [FK_T_PROCESS_LINKAGE_TO_PROCESS_NO]"
  end

  def self.sql_drop_to_process_fk
     "ALTER TABLE [T_PROCESS_LINKAGE] DROP CONSTRAINT [FK_T_PROCESS_LINKAGE_TO_PROCESS_NO]"
  end
end
