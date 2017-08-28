class ChangeColumnInTempProductionDat < ActiveRecord::Migration
  def self.up
    add_column "TEMP_Production_DAT", :TempImport , :string, :null => true, :limit => 1200
    remove_column "TEMP_Production_DAT", :SeqNo,
:ModelYear,
:SuffixCode,
:LotID,
:LotNo,
:Unit,
:BlockModel,
:BlockSeq,
:MARK,
:ProductionDate,
:ProductionTime,
:ImportCode,
:YChassisFlag,
:GAShop,
:HanmmerYears,
:MODEL01ASM01,
:MODEL01ASM02,
:MODEL01ASM03,
:MODEL01ASM04,
:MODEL01ASM05,
:MODEL02ASM01,
:MODEL02ASM02,
:MODEL02ASM03,
:MODEL02ASM04,
:MODEL02ASM05,
:MODEL03ASM01,
:MODEL03ASM02,
:MODEL03ASM03,
:MODEL03ASM04,
:MODEL03ASM05,
:MODEL04ASM01,
:MODEL04ASM02,
:MODEL04ASM03,
:MODEL04ASM04,
:MODEL04ASM05,
:MODEL05ASM01,
:MODEL05ASM02,
:MODEL05ASM03,
:MODEL05ASM04,
:MODEL05ASM05,
:MODEL06ASM01,
:MODEL06ASM02,
:MODEL06ASM03,
:MODEL06ASM04,
:MODEL06ASM05,
:MODEL07ASM01,
:MODEL07ASM02,
:MODEL07ASM03,
:MODEL07ASM04,
:MODEL07ASM05,
:MODEL08ASM01,
:MODEL08ASM02,
:MODEL08ASM03,
:MODEL08ASM04,
:MODEL08ASM05,
:MODEL09ASM01,
:MODEL09ASM02,
:MODEL09ASM03,
:MODEL09ASM04,
:MODEL09ASM05,
:MODEL10ASM01,
:MODEL10ASM02,
:MODEL10ASM03,
:MODEL10ASM04,
:MODEL10ASM05,
:MODEL11ASM01,
:MODEL11ASM02,
:MODEL11ASM03,
:MODEL11ASM04,
:MODEL11ASM05,
:MODEL12ASM01,
:MODEL12ASM02,
:MODEL12ASM03,
:MODEL12ASM04,
:MODEL12ASM05,
:MODEL13ASM01,
:MODEL13ASM02,
:MODEL13ASM03,
:MODEL13ASM04,
:MODEL13ASM05,
:MODEL14ASM01,
:MODEL14ASM02,
:MODEL14ASM03,
:MODEL14ASM04,
:MODEL14ASM05,
:MODEL15ASM01,
:MODEL15ASM02,
:MODEL15ASM03,
:MODEL15ASM04,
:MODEL15ASM05,
:MODEL16ASM01,
:MODEL16ASM02,
:MODEL16ASM03,
:MODEL16ASM04,
:MODEL16ASM05,
:MODEL17ASM01,
:MODEL17ASM02,
:MODEL17ASM03,
:MODEL17ASM04,
:MODEL17ASM05,
:MODEL18ASM01,
:MODEL18ASM02,
:MODEL18ASM03,
:MODEL18ASM04,
:MODEL18ASM05,
:MODEL19ASM01,
:MODEL19ASM02,
:MODEL19ASM03,
:MODEL19ASM04,
:MODEL19ASM05,
:MODEL20ASM01,
:MODEL20ASM02,
:MODEL20ASM03,
:MODEL20ASM04,
:MODEL20ASM05,
:Reserve01,
:Reserve02

  end

  def self.down

    add_column "TEMP_Production_DAT", :SeqNo, :string, :null => true, :limit => 5
    add_column "TEMP_Production_DAT", :ModelYear, :string, :null => true, :limit => 3
    add_column "TEMP_Production_DAT", :SuffixCode, :string, :null => true, :limit => 5
    add_column "TEMP_Production_DAT", :LotID, :string, :null => true, :limit => 3
    add_column "TEMP_Production_DAT", :LotNo, :string, :null => true, :limit => 3
    add_column "TEMP_Production_DAT", :Unit, :string, :null => true, :limit => 3
    add_column "TEMP_Production_DAT", :BlockModel, :string, :limit => 8
    add_column "TEMP_Production_DAT", :BlockSeq, :string, :limit => 3
    add_column "TEMP_Production_DAT", :MARK, :string, :limit => 3
    add_column "TEMP_Production_DAT", :ProductionDate, :string, :limit => 8
    add_column "TEMP_Production_DAT", :ProductionTime, :string, :limit => 4
    add_column "TEMP_Production_DAT", :ImportCode, :string, :limit => 10
    add_column "TEMP_Production_DAT", :YChassisFlag, :string, :limit => 1
    add_column "TEMP_Production_DAT", :GAShop, :string, :limit => 2
    add_column "TEMP_Production_DAT", :HanmmerYears, :string, :limit => 2
    add_column "TEMP_Production_DAT", :MODEL01ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL01ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL01ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL01ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL01ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL02ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL02ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL02ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL02ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL02ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL03ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL03ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL03ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL03ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL03ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL04ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL04ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL04ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL04ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL04ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL05ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL05ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL05ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL05ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL05ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL06ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL06ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL06ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL06ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL06ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL07ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL07ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL07ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL07ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL07ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL08ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL08ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL08ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL08ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL08ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL09ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL09ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL09ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL09ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL09ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL10ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL10ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL10ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL10ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL10ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL11ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL11ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL11ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL11ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL11ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL12ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL12ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL12ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL12ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL12ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL13ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL13ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL13ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL13ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL13ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL14ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL14ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL14ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL14ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL14ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL15ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL15ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL15ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL15ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL15ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL16ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL16ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL16ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL16ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL16ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL17ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL17ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL17ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL17ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL17ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL18ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL18ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL18ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL18ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL18ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL19ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL19ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL19ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL19ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL19ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL20ASM01, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL20ASM02, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL20ASM03, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL20ASM04, :string, :limit => 10
    add_column "TEMP_Production_DAT", :MODEL20ASM05, :string, :limit => 10
    add_column "TEMP_Production_DAT", :Reserve01, :string, :limit => 100
    add_column "TEMP_Production_DAT", :Reserve02, :string, :limit => 100

    remove_column "TEMP_Production_DAT", :TempImport
  end
  
end
