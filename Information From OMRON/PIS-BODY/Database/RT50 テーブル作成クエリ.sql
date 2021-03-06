USE [RT50BodyShop]
GO
/****** Object:  Table [dbo].[T_Production_DAT]    Script Date: 08/02/2010 17:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Production_DAT](
	[SeqNo] [varchar](5) NOT NULL,
	[ModelYear] [varchar](3) NOT NULL,
	[SuffixCode] [varchar](5) NOT NULL,
	[LotID] [varchar](3) NOT NULL,
	[LotNo] [varchar](3) NOT NULL,
	[Unit] [varchar](3) NOT NULL,
	[BlockModel] [varchar](8) NULL,
	[BlockSeq] [varchar](3) NULL,
	[MARK] [varchar](3) NULL,
	[ProductionDate] [varchar](8) NULL,
	[ProductionTime] [varchar](4) NULL,
	[ImportCode] [varchar](10) NULL,
	[YChassisFlag] [varchar](1) NULL,
	[GAShop] [varchar](2) NULL,
	[HanmmerYears] [varchar](2) NULL,
	[MODEL01ASM01] [varchar](10) NULL,
	[MODEL01ASM02] [varchar](10) NULL,
	[MODEL01ASM03] [varchar](10) NULL,
	[MODEL01ASM04] [varchar](10) NULL,
	[MODEL01ASM05] [varchar](10) NULL,
	[MODEL02ASM01] [varchar](10) NULL,
	[MODEL02ASM02] [varchar](10) NULL,
	[MODEL02ASM03] [varchar](10) NULL,
	[MODEL02ASM04] [varchar](10) NULL,
	[MODEL02ASM05] [varchar](10) NULL,
	[MODEL03ASM01] [varchar](10) NULL,
	[MODEL03ASM02] [varchar](10) NULL,
	[MODEL03ASM03] [varchar](10) NULL,
	[MODEL03ASM04] [varchar](10) NULL,
	[MODEL03ASM05] [varchar](10) NULL,
	[MODEL04ASM01] [varchar](10) NULL,
	[MODEL04ASM02] [varchar](10) NULL,
	[MODEL04ASM03] [varchar](10) NULL,
	[MODEL04ASM04] [varchar](10) NULL,
	[MODEL04ASM05] [varchar](10) NULL,
	[MODEL05ASM01] [varchar](10) NULL,
	[MODEL05ASM02] [varchar](10) NULL,
	[MODEL05ASM03] [varchar](10) NULL,
	[MODEL05ASM04] [varchar](10) NULL,
	[MODEL05ASM05] [varchar](10) NULL,
	[MODEL06ASM01] [varchar](10) NULL,
	[MODEL06ASM02] [varchar](10) NULL,
	[MODEL06ASM03] [varchar](10) NULL,
	[MODEL06ASM04] [varchar](10) NULL,
	[MODEL06ASM05] [varchar](10) NULL,
	[MODEL07ASM01] [varchar](10) NULL,
	[MODEL07ASM02] [varchar](10) NULL,
	[MODEL07ASM03] [varchar](10) NULL,
	[MODEL07ASM04] [varchar](10) NULL,
	[MODEL07ASM05] [varchar](10) NULL,
	[MODEL08ASM01] [varchar](10) NULL,
	[MODEL08ASM02] [varchar](10) NULL,
	[MODEL08ASM03] [varchar](10) NULL,
	[MODEL08ASM04] [varchar](10) NULL,
	[MODEL08ASM05] [varchar](10) NULL,
	[MODEL09ASM01] [varchar](10) NULL,
	[MODEL09ASM02] [varchar](10) NULL,
	[MODEL09ASM03] [varchar](10) NULL,
	[MODEL09ASM04] [varchar](10) NULL,
	[MODEL09ASM05] [varchar](10) NULL,
	[MODEL10ASM01] [varchar](10) NULL,
	[MODEL10ASM02] [varchar](10) NULL,
	[MODEL10ASM03] [varchar](10) NULL,
	[MODEL10ASM04] [varchar](10) NULL,
	[MODEL10ASM05] [varchar](10) NULL,
	[MODEL11ASM01] [varchar](10) NULL,
	[MODEL11ASM02] [varchar](10) NULL,
	[MODEL11ASM03] [varchar](10) NULL,
	[MODEL11ASM04] [varchar](10) NULL,
	[MODEL11ASM05] [varchar](10) NULL,
	[MODEL12ASM01] [varchar](10) NULL,
	[MODEL12ASM02] [varchar](10) NULL,
	[MODEL12ASM03] [varchar](10) NULL,
	[MODEL12ASM04] [varchar](10) NULL,
	[MODEL12ASM05] [varchar](10) NULL,
	[MODEL13ASM01] [varchar](10) NULL,
	[MODEL13ASM02] [varchar](10) NULL,
	[MODEL13ASM03] [varchar](10) NULL,
	[MODEL13ASM04] [varchar](10) NULL,
	[MODEL13ASM05] [varchar](10) NULL,
	[MODEL14ASM01] [varchar](10) NULL,
	[MODEL14ASM02] [varchar](10) NULL,
	[MODEL14ASM03] [varchar](10) NULL,
	[MODEL14ASM04] [varchar](10) NULL,
	[MODEL14ASM05] [varchar](10) NULL,
	[MODEL15ASM01] [varchar](10) NULL,
	[MODEL15ASM02] [varchar](10) NULL,
	[MODEL15ASM03] [varchar](10) NULL,
	[MODEL15ASM04] [varchar](10) NULL,
	[MODEL15ASM05] [varchar](10) NULL,
	[MODEL16ASM01] [varchar](10) NULL,
	[MODEL16ASM02] [varchar](10) NULL,
	[MODEL16ASM03] [varchar](10) NULL,
	[MODEL16ASM04] [varchar](10) NULL,
	[MODEL16ASM05] [varchar](10) NULL,
	[MODEL17ASM01] [varchar](10) NULL,
	[MODEL17ASM02] [varchar](10) NULL,
	[MODEL17ASM03] [varchar](10) NULL,
	[MODEL17ASM04] [varchar](10) NULL,
	[MODEL17ASM05] [varchar](10) NULL,
	[MODEL18ASM01] [varchar](10) NULL,
	[MODEL18ASM02] [varchar](10) NULL,
	[MODEL18ASM03] [varchar](10) NULL,
	[MODEL18ASM04] [varchar](10) NULL,
	[MODEL18ASM05] [varchar](10) NULL,
	[MODEL19ASM01] [varchar](10) NULL,
	[MODEL19ASM02] [varchar](10) NULL,
	[MODEL19ASM03] [varchar](10) NULL,
	[MODEL19ASM04] [varchar](10) NULL,
	[MODEL19ASM05] [varchar](10) NULL,
	[MODEL20ASM01] [varchar](10) NULL,
	[MODEL20ASM02] [varchar](10) NULL,
	[MODEL20ASM03] [varchar](10) NULL,
	[MODEL20ASM04] [varchar](10) NULL,
	[MODEL20ASM05] [varchar](10) NULL,
	[Reserve01] [varchar](100) NULL,
	[Reserve02] [varchar](100) NULL,
	[SubSeq01] [int] NULL,
	[SubSeq02] [int] NULL,
	[XchgFlag] [varchar](4) NULL,
	[InstructFlag] [int] NULL,
	[FileName] [varchar](32) NULL,
 CONSTRAINT [PK_T_Production_DAT] PRIMARY KEY CLUSTERED 
(
	[SeqNo] ASC,
	[ModelYear] ASC,
	[SuffixCode] ASC,
	[LotID] ASC,
	[LotNo] ASC,
	[Unit] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_IDX_Production] ON [dbo].[T_Production_DAT] 
(
	[SeqNo] ASC,
	[ModelYear] ASC,
	[SuffixCode] ASC,
	[MODEL01ASM01] ASC,
	[ProductionDate] ASC,
	[ProductionTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_LOG_DAT]    Script Date: 08/02/2010 17:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_LOG_DAT](
	[LogType] [int] NOT NULL,
	[PcName] [varchar](20) NULL,
	[OccDate] [datetime] NOT NULL,
	[Message] [varchar](100) NULL,
 CONSTRAINT [PK_T_LOG_DAT] PRIMARY KEY CLUSTERED 
(
	[LogType] ASC,
	[OccDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Line_MST]    Script Date: 08/02/2010 17:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Line_MST](
	[LineCode] [int] NOT NULL,
	[LineName] [varchar](60) NULL,
 CONSTRAINT [PK_T_Line_MST] PRIMARY KEY CLUSTERED 
(
	[LineCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Instruction_DAT]    Script Date: 08/02/2010 17:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Instruction_DAT](
	[SeqNo] [varchar](5) NOT NULL,
	[ModelYear] [varchar](3) NOT NULL,
	[SuffixCode] [varchar](5) NOT NULL,
	[LotID] [varchar](3) NOT NULL,
	[LotNo] [varchar](3) NOT NULL,
	[Unit] [varchar](3) NOT NULL,
	[BlockModel] [varchar](8) NULL,
	[BlockSeq] [varchar](3) NULL,
	[MARK] [varchar](3) NULL,
	[ProductionDate] [varchar](8) NULL,
	[ProductionTime] [varchar](4) NULL,
	[ImportCode] [varchar](10) NULL,
	[YChassisFlag] [varchar](1) NULL,
	[GAShop] [varchar](2) NULL,
	[HanmmerYears] [varchar](2) NULL,
	[ASM01] [varchar](10) NULL,
	[ASM02] [varchar](10) NULL,
	[ASM03] [varchar](10) NULL,
	[ASM04] [varchar](10) NULL,
	[ASM05] [varchar](10) NULL,
	[XchgFlag] [varchar](4) NULL,
	[RESULT] [datetime] NULL,
	[Line_No] [int] NOT NULL,
 CONSTRAINT [PK_T_Instruction_DAT] PRIMARY KEY CLUSTERED 
(
	[SeqNo] ASC,
	[ModelYear] ASC,
	[SuffixCode] ASC,
	[LotID] ASC,
	[LotNo] ASC,
	[Unit] ASC,
	[Line_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_IDX_Instruct] ON [dbo].[T_Instruction_DAT] 
(
	[SeqNo] ASC,
	[ModelYear] ASC,
	[SuffixCode] ASC,
	[ProductionDate] ASC,
	[ProductionTime] ASC,
	[ASM01] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_CarryOut_DAT]    Script Date: 08/02/2010 17:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_CarryOut_DAT](
	[SeqNo] [varchar](5) NOT NULL,
	[ModelYear] [varchar](3) NOT NULL,
	[SuffixCode] [varchar](5) NOT NULL,
	[LotID] [varchar](3) NOT NULL,
	[LotNo] [varchar](3) NOT NULL,
	[Unit] [varchar](3) NOT NULL,
	[BlockModel] [varchar](8) NULL,
	[BlockSeq] [varchar](3) NULL,
	[MARK] [varchar](3) NULL,
	[ProductionDate] [varchar](8) NULL,
	[ProductionTime] [varchar](4) NULL,
	[ImportCode] [varchar](10) NULL,
	[YChassisFlag] [varchar](1) NULL,
	[GAShop] [varchar](2) NULL,
	[HanmmerYears] [varchar](2) NULL,
	[ASM01] [varchar](10) NULL,
	[ASM02] [varchar](10) NULL,
	[ASM03] [varchar](10) NULL,
	[ASM04] [varchar](10) NULL,
	[ASM05] [varchar](10) NULL,
	[XchgFlag] [varchar](4) NULL,
	[RESULT] [datetime] NULL,
	[LinNo] [int] NOT NULL,
 CONSTRAINT [PK_T_CarryOut_DAT] PRIMARY KEY CLUSTERED 
(
	[SeqNo] ASC,
	[ModelYear] ASC,
	[SuffixCode] ASC,
	[LotID] ASC,
	[LotNo] ASC,
	[Unit] ASC,
	[LinNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_IDX_CarryOut] ON [dbo].[T_CarryOut_DAT] 
(
	[SeqNo] ASC,
	[ModelYear] ASC,
	[SuffixCode] ASC,
	[ProductionDate] ASC,
	[ProductionTime] ASC,
	[ASM01] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
