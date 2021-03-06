USE [resto]
GO
/****** Object:  Table [dbo].[commande]    Script Date: 14/12/2018 15:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[commande](
	[id_commande] [int] NOT NULL,
	[quantite] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingredient]    Script Date: 14/12/2018 15:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingredient](
	[id] [int] NOT NULL,
	[nom] [nchar](50) NULL,
	[conservation] [nchar](50) NULL,
	[stock] [int] NULL,
 CONSTRAINT [PK_ingredient] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personnel]    Script Date: 14/12/2018 15:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personnel](
	[id] [int] NOT NULL,
	[prenom] [nchar](50) NOT NULL,
	[nom] [nchar](50) NOT NULL,
	[metier] [nchar](50) NOT NULL,
	[id_metier] [int] NULL,
 CONSTRAINT [PK_personnel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[plat]    Script Date: 14/12/2018 15:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[plat](
	[id] [int] NOT NULL,
	[nom] [nchar](50) NOT NULL,
	[categorie] [nchar](50) NOT NULL,
	[part] [int] NULL,
 CONSTRAINT [PK_plat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recette]    Script Date: 14/12/2018 15:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recette](
	[nombre] [int] NOT NULL,
	[action] [nchar](50) NOT NULL,
	[temps] [int] NOT NULL,
	[etape] [nchar](50) NOT NULL,
	[id_plat] [int] NOT NULL,
	[id_ingredient] [int] NOT NULL
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
/****** Object:  StoredProcedure [dbo].[check_stock]    Script Date: 14/12/2018 15:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[check_stock]  /*ok*/
    @plat int   
AS   
    DECLARE @nombre_ingredient_recette int = (select count(*) from plat INNER JOIN recette on recette.id_plat = plat.id WHERE plat.id = @plat)
	DECLARE @nombre_ingredient_stock int =	(SELECT count(*) FROM plat INNER JOIN recette on recette.id_plat = plat.id	INNER JOIN ingredient on recette.id_ingredient = ingredient.id	WHERE plat.id = @plat and recette.nombre <= ingredient.stock)
	SELECT IIF ( @nombre_ingredient_recette = @nombre_ingredient_stock, 1, 0 ) AS Result; 
GO
/****** Object:  StoredProcedure [dbo].[choix_dessert]    Script Date: 14/12/2018 15:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[choix_dessert]
AS
	select top 1 plat.id from plat  WHERE plat.categorie = 'dessert' order by newid()
GO
/****** Object:  StoredProcedure [dbo].[choix_entree]    Script Date: 14/12/2018 15:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[choix_entree]
AS
	select top 1 plat.id from plat  WHERE plat.categorie = 'entrée' order by newid()
GO
/****** Object:  StoredProcedure [dbo].[choix_plat]    Script Date: 14/12/2018 15:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[choix_plat]
AS
	select top 1 plat.id from plat  WHERE plat.categorie = 'plat' order by newid()
GO
/****** Object:  StoredProcedure [dbo].[livraison]    Script Date: 14/12/2018 15:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc	[dbo].[livraison]
AS
	UPDATE ingredient
	set ingredient.stock= ingredient.stock + recette.nombre*commande.quantite
	FROM plat
	INNER JOIN recette on recette.id_plat = plat.id
	INNER JOIN ingredient on recette.id_ingredient = ingredient.id
	inner join commande on plat.id=commande.id_commande


	UPDATE commande
	set commande.quantite =0
GO
/****** Object:  StoredProcedure [dbo].[update_stock]    Script Date: 14/12/2018 15:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[update_stock] /*ok*/
	@plat int 
AS
	UPDATE ingredient
	set ingredient.stock= (ingredient.stock - recette.nombre)
	FROM plat
	INNER JOIN recette on recette.id_plat = plat.id
	INNER JOIN ingredient on recette.id_ingredient = ingredient.id
	where @plat=plat.id

	UPDATE commande
	set commande.quantite = (commande.quantite +1)
	FROM commande
	INNER JOIN plat on commande.id_commande = plat.id
	INNER JOIN ingredient on commande.id_commande = ingredient.id
	where @plat=plat.id

GO
