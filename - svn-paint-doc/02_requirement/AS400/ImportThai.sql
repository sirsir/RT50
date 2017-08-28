--delete from T_MODEL_OPTION_ROW

insert T_MODEL_OPTION_ROW ("MODEL_YEAR_PATTERN","SUFFIX_CODE_PATTERN")
select substring(ThaiR03.[MODEL PATTERN],1,3), substring(ThaiR03.[MODEL PATTERN],4,3) + '*' + substring(ThaiR03.[MODEL PATTERN],8,1)
from ThaiR03


insert T_MODEL_OPTION_CELL("MODEL_OPTION_ROW_ID","OPTION_ID","IS_USED")
select oprow.MODEL_OPTION_ROW_ID, opmst.OPTION_ID, imp.[FOOT REST]
from T_MODEL_OPTION_ROW as oprow, T_OPTION_MST as opmst, ThaiR03 as imp
where imp.[MODEL PATTERN] LIKE replace(oprow.MODEL_YEAR_PATTERN+oprow.SUFFIX_CODE_PATTERN,'*','%')
 AND opmst.OPTION_DISPLAY = 'FOOT REST'
 UNION
select oprow.MODEL_OPTION_ROW_ID, opmst.OPTION_ID, imp.[SIDE STEP]
from T_MODEL_OPTION_ROW as oprow, T_OPTION_MST as opmst, ThaiR03 as imp
where imp.[MODEL PATTERN] LIKE replace(oprow.MODEL_YEAR_PATTERN+oprow.SUFFIX_CODE_PATTERN,'*','%')
 AND opmst.OPTION_DISPLAY = 'SIDE STEP'
 UNION
select oprow.MODEL_OPTION_ROW_ID, opmst.OPTION_ID, imp.[B PANEL]
from T_MODEL_OPTION_ROW as oprow, T_OPTION_MST as opmst, ThaiR03 as imp
where imp.[MODEL PATTERN] LIKE replace(oprow.MODEL_YEAR_PATTERN+oprow.SUFFIX_CODE_PATTERN,'*','%')
 AND opmst.OPTION_DISPLAY = 'B/PANEL'
 UNION
select oprow.MODEL_OPTION_ROW_ID, opmst.OPTION_ID, imp.[EURO-5]
from T_MODEL_OPTION_ROW as oprow, T_OPTION_MST as opmst, ThaiR03 as imp
where imp.[MODEL PATTERN] LIKE replace(oprow.MODEL_YEAR_PATTERN+oprow.SUFFIX_CODE_PATTERN,'*','%')
 AND opmst.OPTION_DISPLAY = 'EURO-5'
 UNION
select oprow.MODEL_OPTION_ROW_ID, opmst.OPTION_ID, imp.[SGC FRT PUBX]
from T_MODEL_OPTION_ROW as oprow, T_OPTION_MST as opmst, ThaiR03 as imp
where imp.[MODEL PATTERN] LIKE replace(oprow.MODEL_YEAR_PATTERN+oprow.SUFFIX_CODE_PATTERN,'*','%')
 AND opmst.OPTION_DISPLAY = 'SGC:FRT PUBX'
 UNION
select oprow.MODEL_OPTION_ROW_ID, opmst.OPTION_ID, imp.[SGC FRT PUBX UP]
from T_MODEL_OPTION_ROW as oprow, T_OPTION_MST as opmst, ThaiR03 as imp
where imp.[MODEL PATTERN] LIKE replace(oprow.MODEL_YEAR_PATTERN+oprow.SUFFIX_CODE_PATTERN,'*','%')
 AND opmst.OPTION_DISPLAY = 'SGC:FRT PUBX UP'
 UNION
select oprow.MODEL_OPTION_ROW_ID, opmst.OPTION_ID, imp.[SGC REAR PUBX]
from T_MODEL_OPTION_ROW as oprow, T_OPTION_MST as opmst, ThaiR03 as imp
where imp.[MODEL PATTERN] LIKE replace(oprow.MODEL_YEAR_PATTERN+oprow.SUFFIX_CODE_PATTERN,'*','%')
 AND opmst.OPTION_DISPLAY = 'SGC:REAR PUBX'
 UNION
select oprow.MODEL_OPTION_ROW_ID, opmst.OPTION_ID, 'True'
from T_MODEL_OPTION_ROW as oprow, T_OPTION_MST as opmst, ThaiR03 as imp
where imp.[MODEL PATTERN] LIKE replace(oprow.MODEL_YEAR_PATTERN+oprow.SUFFIX_CODE_PATTERN,'*','%')
 AND opmst.OPTION_DISPLAY = 'THAI'
 