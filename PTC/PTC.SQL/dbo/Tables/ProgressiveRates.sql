CREATE TABLE [dbo].[ProgressiveRates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rate] [varchar](50) NOT NULL,
	[EntryPoint] [decimal](18, 0) NULL,
	[EndPoint] [decimal](18, 0) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProgressiveRates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO