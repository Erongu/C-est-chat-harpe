USE [resto]
GO
/****** Object:  Table [dbo].[elementMAP]    Script Date: 04/12/2018 14:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[elementMAP](
	[id] [uniqueidentifier] NOT NULL,
	[nom] [nchar](50) NOT NULL,
	[x] [int] NOT NULL,
	[y] [int] NOT NULL,
 CONSTRAINT [PK_elementMAP] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingredient]    Script Date: 04/12/2018 14:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingredient](
	[id] [uniqueidentifier] NOT NULL,
	[nom] [nchar](50) NULL,
	[conservation] [nchar](50) NULL,
 CONSTRAINT [PK_ingredient] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personnel]    Script Date: 04/12/2018 14:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personnel](
	[id] [uniqueidentifier] NOT NULL,
	[prenom] [nchar](50) NOT NULL,
	[nom] [nchar](50) NOT NULL,
	[metier] [nchar](50) NOT NULL,
 CONSTRAINT [PK_personnel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[plat]    Script Date: 04/12/2018 14:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[plat](
	[id] [uniqueidentifier] NOT NULL,
	[nom] [nchar](50) NOT NULL,
	[categorie] [nchar](50) NOT NULL,
 CONSTRAINT [PK_plat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recette]    Script Date: 04/12/2018 14:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recette](
	[nombre] [int] NOT NULL,
	[action] [nchar](50) NOT NULL,
	[temps] [int] NOT NULL,
	[etape] [nchar](50) NOT NULL,
	[id_plat] [uniqueidentifier] NOT NULL,
	[id_ingredient] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stock]    Script Date: 04/12/2018 14:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stock](
	[id] [uniqueidentifier] NOT NULL,
	[date] [date] NOT NULL,
	[quantite] [int] NOT NULL,
	[fk_id_ingredient] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_stock] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[recette]  WITH CHECK ADD  CONSTRAINT [FK_recette_ingredient] FOREIGN KEY([id_ingredient])
REFERENCES [dbo].[ingredient] ([id])
GO
ALTER TABLE [dbo].[recette] CHECK CONSTRAINT [FK_recette_ingredient]
GO
ALTER TABLE [dbo].[recette]  WITH CHECK ADD  CONSTRAINT [FK_recette_plat] FOREIGN KEY([id_plat])
REFERENCES [dbo].[plat] ([id])
GO
ALTER TABLE [dbo].[recette] CHECK CONSTRAINT [FK_recette_plat]
GO
ALTER TABLE [dbo].[stock]  WITH CHECK ADD  CONSTRAINT [FK_stock_ingredient] FOREIGN KEY([fk_id_ingredient])
REFERENCES [dbo].[ingredient] ([id])
GO
ALTER TABLE [dbo].[stock] CHECK CONSTRAINT [FK_stock_ingredient]
GO
