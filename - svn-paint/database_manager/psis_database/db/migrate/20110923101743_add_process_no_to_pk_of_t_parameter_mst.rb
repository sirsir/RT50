class AddProcessNoToPkOfTParameterMst < ActiveRecord::Migration
  def self.up
    execute sql_drop_parameter_pk
    execute sql_create_parameter_pk_up
  end

  def self.down
    execute sql_drop_parameter_pk
    execute sql_create_parameter_pk_down
  end

  def self.sql_drop_parameter_pk
    "ALTER TABLE T_PARAMETER_MST
              DROP CONSTRAINT PK_T_PARAMETER_MST"
  end

  def self.sql_create_parameter_pk_up
    "ALTER TABLE T_PARAMETER_MST ADD CONSTRAINT
       PK_T_PARAMETER_MST PRIMARY KEY NONCLUSTERED
      (
        MODEL_CODE ASC,
        PROCESS_NO ASC
      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
  end

  def self.sql_create_parameter_pk_down
    "ALTER TABLE T_PARAMETER_MST ADD CONSTRAINT
       PK_T_PARAMETER_MST PRIMARY KEY NONCLUSTERED
      (
        MODEL_CODE ASC
      )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
  end
end
