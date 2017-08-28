Public Module ModConstant

    Public Const PRODUCTION_DATA_SIZE_PER_PAGE As Integer = 23
    Public Const INSTRUCTION_DATA_SIZE_PER_PAGE As Integer = 20
    Public Const CARRYOUT_DATA_SIZE_PER_PAGE As Integer = 21

    Public Const INSTRUCTION_LOCK_FLAG_NOT_LOCK As Integer = -1
    Public Const INSTRUCTION_LOCK_BLOCK_INDEX_GEN As Integer = 1000

    Public Const INI_FILE_NAME As String = "PSIS-Setting.ini"

    'SQL DB Setting in Ini file  
    Public Const INI_SECTION_SQLDB As String = "SqlDB"
    Public Const INI_KEY_DATASOURCE As String = "DataSource"
    Public Const INI_KEY_DATABASE As String = "Database"
    Public Const INI_KEY_USERID As String = "UserID"
    Public Const INI_KEY_PASSWORD As String = "Password"

    'INI Default Value
    Public Const INI_DEFAULT_VALUE_MAX_SKIT_NO As String = "600"
    Public Const INI_DEFAULT_VALUE_EXPORT_FILE_FULL_PATH As String = "C:\AS400\ExportPath\exp.txt"
    Public Const INI_DEFAULT_VALUE_EXPORT_FILE_PATH As String = "C:\AS400\ExportPath"

    'Flag to show MessageBox when Error
    Public Const ERROR_MESSAGE_DISPLAY As Boolean = False
    Public Const OPERATION_FAIL_MESSAGE_DISPLAY As Boolean = True

    'Process status
    Public Const PROCESS_STATUS_ID_WAITING As Integer = 0
    Public Const PROCESS_STATUS_ID_PROCESSING As Integer = 1
    Public Const PROCESS_STATUS_ID_COMPLETE As Integer = 2
    Public Const PROCESS_STATUS_ID_NO_DATA As Integer = 3
    Public Const PROCESS_STATUS_ID_ERROR As Integer = 4

    'Import File Mode
    Public Const IMPORT_EXE_LOG_SUFFIX As String = "AS400Import"
    Public Const LENGTH_OF_SEQ_NO As Integer = 5
    Public Const LENGTH_OF_MODEL_YEAR As Integer = 3
    Public Const LENGTH_OF_SUFFIX_CODE As Integer = 5
    Public Const LENGTH_OF_LOT_ID As Integer = 3
    Public Const LENGTH_OF_LOT_NO As Integer = 3
    Public Const LENGTH_OF_UNIT As Integer = 3
    Public Const LENGTH_OF_BLOCK As Integer = 8
    Public Const LENGTH_OF_BLOCK_SEQ As Integer = 3
    Public Const LENGTH_OF_MARK As Integer = 3
    Public Const LENGTH_OF_PRODUCTION_DATE As Integer = 8
    Public Const LENGTH_OF_SHIFT As Integer = 1
    Public Const LENGTH_OF_ONTIME As Integer = 4
    Public Const LENGTH_OF_IMPORT_CODE As Integer = 10
    Public Const LENGTH_OF_Y_CHASSIS_FLAG As Integer = 1
    Public Const LENGTH_OF_GA_SHOP As Integer = 2
    Public Const LENGTH_OF_BODY_SHOP_CODE As Integer = 2
    Public Const LENGTH_OF_HANDLE_TYPE As Integer = 2
    Public Const LENGTH_OF_BODY_COLOR_TC_SW As Integer = 3
    Public Const LENGTH_OF_BODY_COLOR_SEQ As Integer = 3
    Public Const LENGTH_OF_BODY_COLOR_OPT As Integer = 3
    Public Const LENGTH_OF_BODY_COLOR_NAME As Integer = 20
    Public Const LENGTH_OF_SURFACE_COLOR_SF_SW As Integer = 3
    Public Const LENGTH_OF_SURFACE_COLOR_XXX As Integer = 3
    Public Const LENGTH_OF_SURFACE_COLOR_NAME As Integer = 20
    Public Const LENGTH_OF_SPARE As Integer = 79

    'PLC Memory Type
    Public PLC_MEMORY_TYPE As Byte = CByte("&H82")

    'PLC Write BCD
    Public Const PLC_WRITE_STATUS_LENGTH As UInteger = 2
    Public Const PLC_WRITE_SKIT_NO_LENGTH As UInteger = 1
    Public Const PLC_WRITE_SERVER_STATUS_LENGTH As UInteger = 2
    Public Const PLC_WRITE_STATUS_WAITING As Integer = 0
    Public Const PLC_WRITE_STATUS_INSTRUCTION As Integer = 1
    Public Const PLC_WRITE_STATUS_COMPLETE As Integer = 2

    Public Const PLC_WRITE_STATUS_NO_DATA As Integer = 3
    Public Const PLC_WRITE_STATUS_NO_DATA_PREFIX_DATA_NOT_FOUND As Integer = 0
    Public Const PLC_WRITE_STATUS_NO_DATA_PREFIX_DATA_REPEAT As Integer = 300
    Public Const PLC_WRITE_STATUS_NO_DATA_PREFIX_MODEL_OPTION_NOT_FOUND As Integer = 100
    Public Const PLC_WRITE_STATUS_NO_DATA_PREFIX_NO_DATA_ON_LANE As Integer = 200

    Public Const PLC_WRITE_STATUS_ERROR As Integer = 4
    Public Const PLC_WRITE_STATUS_ERROR_PREFIX_ERROR As Integer = 0
    Public Const PLC_WRITE_STATUS_ERROR_PREFIX_STAGE_CODE_INVALID As Integer = 100
    Public Const PLC_WRITE_STATUS_ERROR_PREFIX_STATUS_CODE_INVALID As Integer = 200
    Public Const PLC_WRITE_STATUS_ERROR_PREFIX_SKID_EXCEEDS_MAX As Integer = 300
    Public Const PLC_WRITE_STATUS_ERROR_PREFIX_MODEL_ALREADY_FINISHING_IN As Integer = 400
    Public Const PLC_WRITE_STATUS_ERROR_PREFIX_MODEL_ALREADY_HAS_SKID_NO As Integer = 500
    Public Const PLC_WRITE_STATUS_ERROR_PREFIX_SKID_IN_USE_BY_OTHER_MODEL As Integer = 600
    Public Const PLC_WRITE_STATUS_ERROR_PREFIX_WBS_LANE_INVALID As Integer = 700
    Public Const PLC_WRITE_STATUS_ERROR_PREFIX_MODEL_ALREADY_WBS_IN As Integer = 800
    Public Const PLC_WRITE_STATUS_ERROR_PREFIX_SKID_ALREADY_PBR_ON As Integer = 900

    Public Const PLC_WRITE_LANE_NO_LENGTH As UInteger = 1

    'PLC Write ASCII
    Public Const PLC_WRITE_ASCII_SKIT_NO_FORMAT As String = "D3"
    Public Const PLC_WRITE_ASCII_SKIT_NO_LENGTH As Integer = 4
    Public Const PLC_WRITE_ASCII_SEQ_NO_LENGTH As Integer = 6
    Public Const PLC_WRITE_ASCII_MODEL_YEAR_LENGTH As Integer = 3
    Public Const PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH As Integer = 5
    Public Const PLC_WRITE_ASCII_LOT_NO_LENGTH As Integer = 4
    Public Const PLC_WRITE_ASCII_UNIT_LENGTH As Integer = 4
    Public Const PLC_WRITE_ASCII_BLOCK_LENGTH As Integer = 8
    Public Const PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH As Integer = 4
    Public Const PLC_WRITE_ASCII_HANDLE_TYPE_LENGTH As Integer = 2
    Public Const PLC_WRITE_ASCII_BODY_COLOR_OPT_LENGTH As Integer = 4
    Public Const PLC_WRITE_ASCII_WBS_PROGRESS_DATA_LENGTH As Integer = 1600

    'PLC Read
    Public Const PLC_READ_SKIT_NO_LENGTH As UInteger = 1
    Public Const PLC_READ_STATUS_LENGTH As UInteger = 2
    Public Const PLC_READ_STATUS_WAITING As Integer = 0
    Public Const PLC_READ_STATUS_REQUEST As Integer = 1
    Public Const PLC_READ_STATUS_COMPLETE As Integer = 2
    Public Const PLC_READ_STATUS_OFF_INFO As Integer = 3
    Public Const PLC_READ_STATUS_ERROR As Integer = 4
    Public Const PLC_READ_STATUS_SAME_STATUS As Integer = -1
    Public Const PLC_READ_STATUS_INVALID_STAGE_CODE As Integer = -2
    Public Const PLC_READ_STATUS_READ_FAILED As Integer = -3

    'PLC I/O Length in WORD
    Public ReadOnly PLC_WRITE_FINISHING_DATA_LENGTH As UInteger = PLC_WRITE_STATUS_LENGTH + PLC_WRITE_SKIT_NO_LENGTH _
                                            + Math.Ceiling(CDbl(PLC_WRITE_ASCII_MODEL_YEAR_LENGTH _
                                            + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH _
                                            + PLC_WRITE_ASCII_LOT_NO_LENGTH - 1 _
                                            + PLC_WRITE_ASCII_UNIT_LENGTH - 1 _
                                            + PLC_WRITE_ASCII_BLOCK_LENGTH _
                                            + PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH) / 2)

    Public ReadOnly PLC_WRITE_WBS_DATA_LENGTH As UInteger = PLC_WRITE_STATUS_LENGTH + PLC_WRITE_SKIT_NO_LENGTH + PLC_WRITE_LANE_NO_LENGTH _
                                            + Math.Ceiling(CDbl(PLC_WRITE_ASCII_SKIT_NO_LENGTH _
                                            + PLC_WRITE_ASCII_SEQ_NO_LENGTH _
                                            + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH _
                                            + PLC_WRITE_ASCII_LOT_NO_LENGTH _
                                            + PLC_WRITE_ASCII_UNIT_LENGTH _
                                            + PLC_WRITE_ASCII_BLOCK_LENGTH _
                                            + PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH _
                                            + PLC_WRITE_ASCII_HANDLE_TYPE_LENGTH _
                                            + PLC_WRITE_ASCII_BODY_COLOR_OPT_LENGTH _
                                            + PLC_OPTION_DATA_TOTAL_LENGTH) / 2)

    Public ReadOnly PLC_WRITE_PAINT_DATA_LENGTH As UInteger = PLC_WRITE_STATUS_LENGTH + PLC_WRITE_SKIT_NO_LENGTH + PLC_WRITE_LANE_NO_LENGTH _
                                            + Math.Ceiling(CDbl(PLC_WRITE_ASCII_SKIT_NO_LENGTH _
                                            + PLC_WRITE_ASCII_SEQ_NO_LENGTH _
                                            + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH _
                                            + PLC_WRITE_ASCII_LOT_NO_LENGTH _
                                            + PLC_WRITE_ASCII_UNIT_LENGTH _
                                            + PLC_WRITE_ASCII_BLOCK_LENGTH _
                                            + PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH _
                                            + PLC_WRITE_ASCII_HANDLE_TYPE_LENGTH _
                                            + PLC_WRITE_ASCII_BODY_COLOR_OPT_LENGTH _
                                            + PLC_OPTION_DATA_TOTAL_LENGTH) / 2)

    Public ReadOnly PLC_WRITE_PBR_DATA_LENGTH As UInteger = PLC_WRITE_STATUS_LENGTH + PLC_WRITE_SKIT_NO_LENGTH + PLC_WRITE_LANE_NO_LENGTH _
                                            + Math.Ceiling(CDbl(PLC_WRITE_ASCII_SKIT_NO_LENGTH _
                                            + PLC_WRITE_ASCII_SEQ_NO_LENGTH _
                                            + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH _
                                            + PLC_WRITE_ASCII_LOT_NO_LENGTH _
                                            + PLC_WRITE_ASCII_UNIT_LENGTH _
                                            + PLC_WRITE_ASCII_BLOCK_LENGTH _
                                            + PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH _
                                            + PLC_WRITE_ASCII_HANDLE_TYPE_LENGTH _
                                            + PLC_WRITE_ASCII_BODY_COLOR_OPT_LENGTH _
                                            + PLC_OPTION_DATA_TOTAL_LENGTH) / 2)

    Public Const PLC_WRITE_WBS_PROGRESS_PER_RECORD_DATA_LENGTH As UInteger = 20
    Public Const PLC_WRITE_WBS_PROGRESS_PER_LANE_RECORD_COUNT As UInteger = 10
    Public Const PLC_WRITE_WBS_PROGRESS_DATA_LENGTH As UInteger = 800

    'Process Type Master
    Public Const PROCESS_TYPE_FINISHING As Integer = 0
    Public Const PROCESS_TYPE_WBS_ON As Integer = 1
    Public Const PROCESS_TYPE_PAINT As Integer = 2
    Public Const PROCESS_TYPE_PBR As Integer = 3
    Public Const PROCESS_TYPE_WBS_PROGRESS As Integer = 4

    'PLC Option Constant
    Public Const PLC_OPTION_DATA_SPLITTER As String = ","
    Public Const PLC_OPTION_DATA_LENGTH As Integer = 16
    Public Const PLC_OPTION_DATA_TOTAL_LENGTH As Integer = 160
    Public Const PLC_OPTION_DATA_PADDER As String = " "

    'DBLog Type
    Public Const DB_LOG_TYPE_AS400 As Integer = 1
    Public Const DB_LOG_TYPE_PLC As Integer = 2
    Public Const DB_LOG_TYPE_OPERATION As Integer = 3
    Public Const DB_LOG_TYPE_DEBUG As Integer = 9

    'DBLog Code(Normal)
    Public Const DB_LOG_CODE_N_EDIT_WBS_STOCK_DATA As String = "PNTC/WBSM-30000"
    Public Const DB_LOG_CODE_N_EDIT_PROCESS_INSTRUCTION_DATA_ROW As String = "PNTC/INDE-30000"
    Public Const DB_LOG_CODE_N_ADD_INSTRUCTION_DATA_ROW As String = "PNTC/INDE-30001"
    Public Const DB_LOG_CODE_N_EDIT_INSTRUCTION_DATA_ROW As String = "PNTC/INDE-30002"
    Public Const DB_LOG_CODE_N_DELETE_INSTRUCTION_DATA_ROW As String = "PNTC/INDE-30003"
    Public Const DB_LOG_CODE_N_DELETE_OPTION_MST_ROW As String = "PNTC/OPTM-30000"
    Public Const DB_LOG_CODE_N_ADD_OPTION_MST_ROW As String = "PNTC/OPTM-30001"
    Public Const DB_LOG_CODE_N_EDIT_OPTION_MST_ROW As String = "PNTC/OPTM-30002"
    Public Const DB_LOG_CODE_N_DELETE_PLC_MST_ROW As String = "PNTC/PLCM-30000"
    Public Const DB_LOG_CODE_N_ADD_PLC_MST_ROW As String = "PNTC/PLCM-30001"
    Public Const DB_LOG_CODE_N_EDIT_PLC_MST_ROW As String = "PNTC/PLCM-30002"
    Public Const DB_LOG_CODE_N_DELETE_MODEL_OPTION_ROW As String = "PNTC/MOPS-30000"
    Public Const DB_LOG_CODE_N_ADD_MODEL_OPTION_ROW As String = "PNTC/MOPS-30001"
    Public Const DB_LOG_CODE_N_EDIT_MODEL_OPTION_ROW As String = "PNTC/MOPS-30002"
    Public Const DB_LOG_CODE_N_EDIT_PROCESS_OPTION_ROW As String = "PNTC/POPS-30000"
    Public Const DB_LOG_CODE_N_DELETE_PROCESS_MASTER_ROW As String = "PNTC/PRCM-30000"
    Public Const DB_LOG_CODE_N_ADD_PROCESS_MASTER_ROW As String = "PNTC/PRCM-30001"
    Public Const DB_LOG_CODE_N_EDIT_PROCESS_MASTER_ROW As String = "PNTC/PRCM-30002"
    Public Const DB_LOG_CODE_N_SHOW_IMPORT_RESULT As String = "PNTS/IMPF-10000"
    Public Const DB_LOG_CODE_N_DATA_COLLECT_START As String = "PNTS/IMPF-10001"
    Public Const DB_LOG_CODE_N_MANUAL_IMPORT_FILE_FOUND As String = "PNTS/IMPF-10002"
    Public Const DB_LOG_CODE_N_AS400_IMPORT_FILE_FOUND As String = "PNTS/IMPF-10003"
    Public Const DB_LOG_CODE_N_HULF_MESSAGE As String = "SCSV/HULF-10000"
    Public Const DB_LOG_CODE_N_UTL_RECV_START As String = "SCSV/HULF-10001"
    Public Const DB_LOG_CODE_N_UTL_RECV_JOB_OK As String = "SCSV/HULF-10002"
    Public Const DB_LOG_CODE_N_UTL_SEND_START As String = "SCSV/HULF-10003"
    Public Const DB_LOG_CODE_N_UTL_SEND_JOB_OK As String = "SCSV/HULF-10004"
    Public Const DB_LOG_CODE_N_EXP_SEND_START As String = "SCSV/HULF-10005"
    Public Const DB_LOG_CODE_N_EXP_SEND_JOB_OK As String = "SCSV/HULF-10006"
    Public Const DB_LOG_CODE_N_PLC_FINI_INSTRUCTION_COMPLETE As String = "PNTS/FINI-20000"
    Public Const DB_LOG_CODE_N_PLC_WBSI_INSTRUCTION_COMPLETE As String = "PNTS/WBSI-20000"
    Public Const DB_LOG_CODE_N_PLC_PNTI_INSTRUCTION_COMPLETE As String = "PNTS/PNTI-20000"
    Public Const DB_LOG_CODE_N_PLC_PBRI_INSTRUCTION_COMPLETE As String = "PNTS/PBRI-20000"
    Public Const DB_LOG_CODE_N_PLC_WBSP_INSTRUCTION_COMPLETE As String = "PNTS/WBSP-20000"


    'DBLog Code(Error)
    Public Const DB_LOG_CODE_E_CAN_NOT_READ_FILE As String = "PNTS/IMPF-10202"
    Public Const DB_LOG_CODE_E_INVALID_FILE As String = "PNTS/IMPF-10203"
    Public Const DB_LOG_CODE_E_HEADER_MISSING As String = "PNTS/IMPF-10205"
    Public Const DB_LOG_CODE_E_DUP_SECOND_KEY As String = "PNTS/IMPF-10206"
    Public Const DB_LOG_CODE_E_DUP_PRIMARY_KEY As String = "PNTS/IMPF-10207"
    Public Const DB_LOG_CODE_E_MISMATCH_NUMBER_OF_RECORD As String = "PNTS/IMPF-10208"
    Public Const DB_LOG_CODE_E_TRAIL_MISSING As String = "PNTS/IMPF-10209"
    Public Const DB_LOG_CODE_E_INVALID_AT_RECORD As String = "PNTS/IMPF-10210"
    Public Const DB_LOG_CODE_E_PROD_DATE_AND_SEQ_NO_LESS_THAN_CURRENT As String = "PNTS/IMPF-10213"
    Public Const DB_LOG_CODE_E_CAN_NOT_UPDATE_PRODUCTION_DATA As String = "PNTS/IMPF-10214"
    Public Const DB_LOG_CODE_E_ERROR_WHILE_IMPORT_FILE As String = "PNTS/IMPF-10215"
    Public Const DB_LOG_CODE_E_UTL_RECV_JOB_ERROR As String = "SCSV/HULF-10200"
    Public Const DB_LOG_CODE_E_UTL_SEND_JOB_ERROR As String = "SCSV/HULF-10201"
    Public Const DB_LOG_CODE_E_EXP_SEND_JOB_ERROR As String = "SCSV/HULF-10202"
    Public Const DB_LOG_CODE_E_PLC_FINI_INVALID_STAGE_CODE As String = "PNTS/FINI-20200"
    Public Const DB_LOG_CODE_E_PLC_FINI_INVALID_REQ_STATUS As String = "PNTS/FINI-20201"
    Public Const DB_LOG_CODE_E_PLC_FINI_SKIT_NO_EXCEEDS_MAX As String = "PNTS/FINI-20202"
    Public Const DB_LOG_CODE_E_PLC_FINI_NO_PROD_DATA_EXIST As String = "PNTS/FINI-20203"
    Public Const DB_LOG_CODE_E_PLC_FINI_SKIT_IN_USED As String = "PNTS/FINI-20204"
    Public Const DB_LOG_CODE_E_PLC_FINI_HAD_SKIT_NO As String = "PNTS/FINI-20205"
    Public Const DB_LOG_CODE_E_PLC_FINI_HAD_FINI_RESULT_DATE As String = "PNTS/FINI-20206"
    Public Const DB_LOG_CODE_E_PLC_FINI_ERROR_REQ_STATUS As String = "PNTS/FINI-20207"
    Public Const DB_LOG_CODE_E_PLC_FINI_INSTRUCTION_FAILED As String = "PNTS/FINI-20208"
    Public Const DB_LOG_CODE_E_PLC_WBSI_INVALID_STAGE_CODE As String = "PNTS/WBSI-20200"
    Public Const DB_LOG_CODE_E_PLC_WBSI_INVALID_REQ_STATUS As String = "PNTS/WBSI-20201"
    Public Const DB_LOG_CODE_E_PLC_WBSI_SKIT_NO_EXCEEDS_MAX As String = "PNTS/WBSI-20202"
    Public Const DB_LOG_CODE_E_PLC_WBSI_LANE_NO_NOT_EXIST As String = "PNTS/WBSI-20203"
    Public Const DB_LOG_CODE_E_PLC_WBSI_PROD_OF_SKIT_NOT_EXIST As String = "PNTS/WBSI-20204"
    Public Const DB_LOG_CODE_E_PLC_WBSI_PPOD_OF_SKIT_HAD_NEXT_PROC_RESULT As String = "PNTS/WBSI-20205"
    Public Const DB_LOG_CODE_E_PLC_WBSI_ERROR_REQ_STATUS As String = "PNTS/WBSI-20206"
    Public Const DB_LOG_CODE_E_PLC_WBSI_MODEL_OPT_NOT_EXIST As String = "PNTS/WBSI-20208"
    Public Const DB_LOG_CODE_E_PLC_WBSI_INSTRUCTION_FAILED As String = "PNTS/WBSI-20207"
    Public Const DB_LOG_CODE_E_PLC_PNTI_INVALID_STAGE_CODE As String = "PNTS/PNTI-20200"
    Public Const DB_LOG_CODE_E_PLC_PNTI_INVALID_REQ_STATUS As String = "PNTS/PNTI-20201"
    Public Const DB_LOG_CODE_E_PLC_PNTI_SKIT_NO_EXCEEDS_MAX As String = "PNTS/PNTI-20202"
    Public Const DB_LOG_CODE_E_PLC_PNTI_PROD_OF_SKIT_NOT_EXIST As String = "PNTS/PNTI-20203"
    Public Const DB_LOG_CODE_E_PLC_PNTI_PROD_OF_SKIT_NO_WBS_RESULT As String = "PNTS/PNTI-20204"
    Public Const DB_LOG_CODE_E_PLC_PNTI_PROD_OF_SKIT_NO_PREV_PROCESS_RESULT As String = "PNTS/PNTI-20205"
    Public Const DB_LOG_CODE_E_PLC_PNTI_ERROR_REQ_STATUS As String = "PNTS/PNTI-20206"
    Public Const DB_LOG_CODE_E_PLC_PNTI_SKIT_NOT_FIRST_SEQ As String = "PNTS/PNTI-20207"
    Public Const DB_LOG_CODE_E_PLC_PNTI_MODEL_OPT_NOT_EXIST As String = "PNTS/PNTI-20209"
    Public Const DB_LOG_CODE_E_PLC_PNTI_INSTRUCTION_FAILED As String = "PNTS/PNTI-20208"
    Public Const DB_LOG_CODE_E_PLC_PNTI_PROD_OF_SKIT_HAD_PBR_ON_RESULT As String = "PNTS/PNTI-20210"
    Public Const DB_LOG_CODE_E_PLC_PNTI_PROD_OF_SKIT_HAD_NEXT_PROC_RESULT As String = "PNTS/PNTI-20211"
    Public Const DB_LOG_CODE_E_PLC_PNTI_NO_MODEL_ON_SELECTED_LANE As String = "PNTS/PNTI-20212"
    Public Const DB_LOG_CODE_E_PLC_PBRI_INVALID_STAGE_CODE As String = "PNTS/PBRI-20200"
    Public Const DB_LOG_CODE_E_PLC_PBRI_INVALID_REQ_STATUS As String = "PNTS/PBRI-20201"
    Public Const DB_LOG_CODE_E_PLC_PBRI_SKIT_NO_EXCEEDS_MAX As String = "PNTS/PBRI-20202"
    Public Const DB_LOG_CODE_E_PLC_PBRI_PROD_OF_SKIT_NOT_EXIST As String = "PNTS/PBRI-20203"
    Public Const DB_LOG_CODE_E_PLC_PBRI_PROD_OF_SKIT_HAD_PBR_ON_RESULT As String = "PNTS/PBRI-20204"
    Public Const DB_LOG_CODE_E_PLC_PBRI_PROD_OF_SKIT_NO_PREV_PROCESS_RESULT As String = "PNTS/PBRI-20205"
    Public Const DB_LOG_CODE_E_PLC_PBRI_ERROR_REQ_STATUS As String = "PNTS/PBRI-20206"
    Public Const DB_LOG_CODE_E_PLC_PBRI_MODEL_OPT_NOT_EXIST As String = "PNTS/PBRI-20210"
    Public Const DB_LOG_CODE_E_PLC_PBRI_PROD_OF_SKIT_NO_PBR_ON_RESULT As String = "PNTS/PBRI-20207"
    Public Const DB_LOG_CODE_E_PLC_PBRI_INSTRUCTION_FAILED As String = "PNTS/PBRI-20208"
    Public Const DB_LOG_CODE_E_PLC_PBRI_EXPORT_FILE_ERROR As String = "PNTS/PBRI-20209"
    Public Const DB_LOG_CODE_E_PLC_WBSP_NO_LANE_DATA As String = "PNTS/WBSP-20200"
    Public Const DB_LOG_CODE_E_PLC_WBSP_NO_PROD_DATA As String = "PNTS/WBSP-20201"
    Public Const DB_LOG_CODE_E_PLC_WBSP_NO_SKIT_DATA As String = "PNTS/WBSP-20202"
    Public Const DB_LOG_CODE_E_PLC_WBSP_NO_WBS_ON_DATA As String = "PNTS/WBSP-20203"

    'DBLog Code(Warning)
    Public Const DB_LOG_CODE_W_DUP_DATA_INSERT_NEW As String = "PNTS/IMPF-10101"
    Public Const DB_LOG_CODE_W_DUP_DATA_UPDATE As String = "PNTS/IMPF-10102"
    Public Const DB_LOG_CODE_W_CAN_NOT_INSERT_INSTRUCTED_MODEL As String = "PNTS/IMPF-10103"
    Public Const DB_LOG_CODE_W_NO_DATA_TO_INSERT As String = "PNTS/IMPF-10104"
    Public Const DB_LOG_CODE_W_PART_NOT_MATCH As String = "PNTS/IMPF-10105"
    Public Const DB_LOG_CODE_W_PLC_FINI_USER_CANCEL As String = "PNTS/FINI-20100"
    Public Const DB_LOG_CODE_W_PLC_WBSI_USER_CANCEL As String = "PNTS/WBSI-20100"
    Public Const DB_LOG_CODE_W_PLC_PNTI_USER_CANCEL As String = "PNTS/PNTI-20100"
    Public Const DB_LOG_CODE_W_PLC_PBRI_USER_CANCEL As String = "PNTS/PBRI-20100"

    ' FILLER PART
    '' FILE HEADER
    Public Const TITLE As Integer = 6
    Public Const DATASET_NAME As Integer = 18
    Public Const _DATE As Integer = 8
    Public Const TIME As Integer = 6
    Public Const RECORD_SIZE As Integer = 5
    Public Const BLOCK_SIZE As Integer = 5
    Public Const FILLER_HEADER As Integer = 22

    Public Const TITLE_HEADER_NAME As String = "HEADER"
    Public Const _DATASET_NAME As String = "PBR RESULT"
    Public Const BLOCK_SIZE_VALUE As String = "0"

    '' FILE TRAILER
    Public Const DATA_NUMBER As Integer = 8
    Public Const FILLER_TRAILER As Integer = 56

    Public Const TITLE_TRAILER_NAME As String = "TRAIL"
    Public Const DATA_NUMBER_VALUE As String = "1"

    ' DATA PART
    Public Const MODEL_CODE As Integer = 8
    Public Const TIMESTAMP As Integer = 14
    Public Const SPARE As Integer = 31

End Module
