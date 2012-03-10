/****** Object:  ForeignKey [FK_ArticleOwner]    Script Date: 03/10/2012 17:32:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArticleOwner]') AND parent_object_id = OBJECT_ID(N'[dbo].[Article]'))
ALTER TABLE [dbo].[Article] DROP CONSTRAINT [FK_ArticleOwner]
GO
/****** Object:  ForeignKey [FK_OrdertateOrder]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdertateOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_OrdertateOrder]
GO
/****** Object:  ForeignKey [FK_OrderThing]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderThing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_OrderThing]
GO
/****** Object:  ForeignKey [FK_UserOrder]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_UserOrder]
GO
/****** Object:  ForeignKey [FK_ThingFormat]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingFormat]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [FK_ThingFormat]
GO
/****** Object:  ForeignKey [FK_ThingMaterial]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [FK_ThingMaterial]
GO
/****** Object:  ForeignKey [FK_ThingState]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingState]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [FK_ThingState]
GO
/****** Object:  ForeignKey [FK_ThingTag_Tag]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] DROP CONSTRAINT [FK_ThingTag_Tag]
GO
/****** Object:  ForeignKey [FK_ThingTag_Thing]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Thing]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] DROP CONSTRAINT [FK_ThingTag_Thing]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdertateOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_OrdertateOrder]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderThing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_OrderThing]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_UserOrder]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Order__Id__1273C1CD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [DF__Order__Id__1273C1CD]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
DROP TABLE [dbo].[Order]
GO
/****** Object:  Table [dbo].[ThingTag]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] DROP CONSTRAINT [FK_ThingTag_Tag]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Thing]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] DROP CONSTRAINT [FK_ThingTag_Thing]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ThingTag]') AND type in (N'U'))
DROP TABLE [dbo].[ThingTag]
GO
/****** Object:  Table [dbo].[Thing]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingFormat]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [FK_ThingFormat]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [FK_ThingMaterial]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingState]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [FK_ThingState]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Thing__Id__164452B1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [DF__Thing__Id__164452B1]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Thing]') AND type in (N'U'))
DROP TABLE [dbo].[Thing]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 03/10/2012 17:32:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArticleOwner]') AND parent_object_id = OBJECT_ID(N'[dbo].[Article]'))
ALTER TABLE [dbo].[Article] DROP CONSTRAINT [FK_ArticleOwner]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Article]') AND type in (N'U'))
DROP TABLE [dbo].[Article]
GO
/****** Object:  Table [dbo].[Format]    Script Date: 03/10/2012 17:32:16 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Format__Id__108B795B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Format] DROP CONSTRAINT [DF__Format__Id__108B795B]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Format]') AND type in (N'U'))
DROP TABLE [dbo].[Format]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Material__Id__117F9D94]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Material] DROP CONSTRAINT [DF__Material__Id__117F9D94]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Material]') AND type in (N'U'))
DROP TABLE [dbo].[Material]
GO
/****** Object:  Table [dbo].[State]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__State__Id__1367E606]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[State] DROP CONSTRAINT [DF__State__Id__1367E606]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
DROP TABLE [dbo].[State]
GO
/****** Object:  Table [dbo].[StateOrder]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__StateOrder__Id__145C0A3F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[StateOrder] DROP CONSTRAINT [DF__StateOrder__Id__145C0A3F]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StateOrder]') AND type in (N'U'))
DROP TABLE [dbo].[StateOrder]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Tag__Id__15502E78]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tag] DROP CONSTRAINT [DF__Tag__Id__15502E78]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tag]') AND type in (N'U'))
DROP TABLE [dbo].[Tag]
GO
/****** Object:  Table [dbo].[User]    Script Date: 03/10/2012 17:32:17 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__User__Id__173876EA]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF__User__Id__173876EA]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[User]    Script Date: 03/10/2012 17:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Email] [nvarchar](256) NOT NULL,
	[Password] [binary](20) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 03/10/2012 17:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tag]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tag](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[StateOrder]    Script Date: 03/10/2012 17:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StateOrder]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StateOrder](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_StateOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[State]    Script Date: 03/10/2012 17:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[State](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Material]    Script Date: 03/10/2012 17:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Material]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Material](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Format]    Script Date: 03/10/2012 17:32:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Format]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Format](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Format] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Article]    Script Date: 03/10/2012 17:32:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Article]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Article](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[OwnerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Thing]    Script Date: 03/10/2012 17:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Thing]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Thing](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ShowOnHome] [bit] NOT NULL,
	[ShowForAll] [bit] NOT NULL,
	[FormatId] [uniqueidentifier] NOT NULL,
	[Rating] [int] NULL,
	[Image1] [varbinary](max) NULL,
	[Image2] [varbinary](max) NULL,
	[Comment] [nvarchar](1024) NULL,
	[ImageRes] [varbinary](max) NOT NULL,
	[MaterialId] [uniqueidentifier] NOT NULL,
	[StateId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Thing] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThingTag]    Script Date: 03/10/2012 17:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ThingTag]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ThingTag](
	[ThingId] [uniqueidentifier] NOT NULL,
	[TagId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ThingTag] PRIMARY KEY NONCLUSTERED 
(
	[ThingId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Order]    Script Date: 03/10/2012 17:32:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Order](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[CreateDate] [datetime] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[StateOrderId] [uniqueidentifier] NOT NULL,
	[ThingId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  ForeignKey [FK_ArticleOwner]    Script Date: 03/10/2012 17:32:16 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArticleOwner]') AND parent_object_id = OBJECT_ID(N'[dbo].[Article]'))
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_ArticleOwner] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[User] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArticleOwner]') AND parent_object_id = OBJECT_ID(N'[dbo].[Article]'))
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_ArticleOwner]
GO
/****** Object:  ForeignKey [FK_OrdertateOrder]    Script Date: 03/10/2012 17:32:17 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdertateOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_OrdertateOrder] FOREIGN KEY([StateOrderId])
REFERENCES [dbo].[StateOrder] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdertateOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_OrdertateOrder]
GO
/****** Object:  ForeignKey [FK_OrderThing]    Script Date: 03/10/2012 17:32:17 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderThing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_OrderThing] FOREIGN KEY([ThingId])
REFERENCES [dbo].[Thing] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderThing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_OrderThing]
GO
/****** Object:  ForeignKey [FK_UserOrder]    Script Date: 03/10/2012 17:32:17 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_UserOrder] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_UserOrder]
GO
/****** Object:  ForeignKey [FK_ThingFormat]    Script Date: 03/10/2012 17:32:17 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingFormat]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing]  WITH CHECK ADD  CONSTRAINT [FK_ThingFormat] FOREIGN KEY([FormatId])
REFERENCES [dbo].[Format] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingFormat]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] CHECK CONSTRAINT [FK_ThingFormat]
GO
/****** Object:  ForeignKey [FK_ThingMaterial]    Script Date: 03/10/2012 17:32:17 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing]  WITH CHECK ADD  CONSTRAINT [FK_ThingMaterial] FOREIGN KEY([MaterialId])
REFERENCES [dbo].[Material] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] CHECK CONSTRAINT [FK_ThingMaterial]
GO
/****** Object:  ForeignKey [FK_ThingState]    Script Date: 03/10/2012 17:32:17 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingState]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing]  WITH CHECK ADD  CONSTRAINT [FK_ThingState] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingState]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] CHECK CONSTRAINT [FK_ThingState]
GO
/****** Object:  ForeignKey [FK_ThingTag_Tag]    Script Date: 03/10/2012 17:32:17 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag]  WITH CHECK ADD  CONSTRAINT [FK_ThingTag_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] CHECK CONSTRAINT [FK_ThingTag_Tag]
GO
/****** Object:  ForeignKey [FK_ThingTag_Thing]    Script Date: 03/10/2012 17:32:17 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Thing]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag]  WITH CHECK ADD  CONSTRAINT [FK_ThingTag_Thing] FOREIGN KEY([ThingId])
REFERENCES [dbo].[Thing] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Thing]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] CHECK CONSTRAINT [FK_ThingTag_Thing]
GO