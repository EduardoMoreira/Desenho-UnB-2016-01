CREATE TABLE [dbo].[Vaca](
	[NRBrinco] [int] NOT NULL,
	[DTNascimento] [datetime] NOT NULL,
	[TPSexo] [char](1) NOT NULL,
	[DTInseminacao] [datetime] NULL,
	[DTDesamamentacao] [datetime] NULL,
	[DTProcriacao] [datetime] NULL,
 CONSTRAINT [PK_Vaca] PRIMARY KEY CLUSTERED 
(
	[NRBrinco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
