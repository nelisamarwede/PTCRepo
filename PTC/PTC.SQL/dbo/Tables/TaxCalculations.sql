CREATE TABLE [dbo].[TaxCalculations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Income] [money] NOT NULL,
	[PostalCode] [nvarchar](50) NOT NULL,
	[CalculatedTax] [money] NOT NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_TaxCalculations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO