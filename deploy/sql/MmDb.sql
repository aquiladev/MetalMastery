/****** Object:  ForeignKey [FK_ArticleOwner]    Script Date: 02/21/2012 03:47:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArticleOwner]') AND parent_object_id = OBJECT_ID(N'[dbo].[Article]'))
ALTER TABLE [dbo].[Article] DROP CONSTRAINT [FK_ArticleOwner]
GO
/****** Object:  ForeignKey [FK_OrdertateOrder]    Script Date: 02/21/2012 03:47:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdertateOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_OrdertateOrder]
GO
/****** Object:  ForeignKey [FK_OrderThing]    Script Date: 02/21/2012 03:47:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderThing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_OrderThing]
GO
/****** Object:  ForeignKey [FK_UserOrder]    Script Date: 02/21/2012 03:47:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_UserOrder]
GO
/****** Object:  ForeignKey [FK_ThingFormat]    Script Date: 02/21/2012 03:47:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingFormat]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [FK_ThingFormat]
GO
/****** Object:  ForeignKey [FK_ThingMaterial]    Script Date: 02/21/2012 03:47:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [FK_ThingMaterial]
GO
/****** Object:  ForeignKey [FK_ThingState]    Script Date: 02/21/2012 03:47:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingState]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [FK_ThingState]
GO
/****** Object:  ForeignKey [FK_ThingTag_Tag]    Script Date: 02/21/2012 03:47:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] DROP CONSTRAINT [FK_ThingTag_Tag]
GO
/****** Object:  ForeignKey [FK_ThingTag_Thing]    Script Date: 02/21/2012 03:47:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Thing]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] DROP CONSTRAINT [FK_ThingTag_Thing]
GO
/****** Object:  ForeignKey [FK_UserRole]    Script Date: 02/21/2012 03:47:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserRole]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 02/21/2012 03:47:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdertateOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_OrdertateOrder]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderThing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_OrderThing]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_UserOrder]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Order__Id__182C9B23]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [DF__Order__Id__182C9B23]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
DROP TABLE [dbo].[Order]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 02/21/2012 03:47:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArticleOwner]') AND parent_object_id = OBJECT_ID(N'[dbo].[Article]'))
ALTER TABLE [dbo].[Article] DROP CONSTRAINT [FK_ArticleOwner]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Article]') AND type in (N'U'))
DROP TABLE [dbo].[Article]
GO
/****** Object:  Table [dbo].[ThingTag]    Script Date: 02/21/2012 03:47:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] DROP CONSTRAINT [FK_ThingTag_Tag]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Thing]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] DROP CONSTRAINT [FK_ThingTag_Thing]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ThingTag]') AND type in (N'U'))
DROP TABLE [dbo].[ThingTag]
GO
/****** Object:  Table [dbo].[User]    Script Date: 02/21/2012 03:47:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserRole]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__User__Id__1367E606]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF__User__Id__1367E606]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[Thing]    Script Date: 02/21/2012 03:47:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingFormat]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [FK_ThingFormat]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [FK_ThingMaterial]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingState]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [FK_ThingState]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Thing__Id__108B795B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Thing] DROP CONSTRAINT [DF__Thing__Id__108B795B]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Thing]') AND type in (N'U'))
DROP TABLE [dbo].[Thing]
GO
/****** Object:  Table [dbo].[Format]    Script Date: 02/21/2012 03:47:43 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Format__Id__0DAF0CB0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Format] DROP CONSTRAINT [DF__Format__Id__0DAF0CB0]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Format]') AND type in (N'U'))
DROP TABLE [dbo].[Format]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 02/21/2012 03:47:43 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Material__Id__0AD2A005]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Material] DROP CONSTRAINT [DF__Material__Id__0AD2A005]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Material]') AND type in (N'U'))
DROP TABLE [dbo].[Material]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 02/21/2012 03:47:43 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Role__Id__07F6335A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Role] DROP CONSTRAINT [DF__Role__Id__07F6335A]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[State]    Script Date: 02/21/2012 03:47:43 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__State__Id__023D5A04]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[State] DROP CONSTRAINT [DF__State__Id__023D5A04]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
DROP TABLE [dbo].[State]
GO
/****** Object:  Table [dbo].[StateOrder]    Script Date: 02/21/2012 03:47:43 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__StateOrder__Id__0519C6AF]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[StateOrder] DROP CONSTRAINT [DF__StateOrder__Id__0519C6AF]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StateOrder]') AND type in (N'U'))
DROP TABLE [dbo].[StateOrder]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 02/21/2012 03:47:44 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Tag__Id__7F60ED59]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tag] DROP CONSTRAINT [DF__Tag__Id__7F60ED59]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tag]') AND type in (N'U'))
DROP TABLE [dbo].[Tag]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 02/21/2012 03:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tag]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tag](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[StateOrder]    Script Date: 02/21/2012 03:47:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StateOrder]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StateOrder](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_StateOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[State]    Script Date: 02/21/2012 03:47:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[State](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Role]    Script Date: 02/21/2012 03:47:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Role](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Material]    Script Date: 02/21/2012 03:47:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Material]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Material](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Format]    Script Date: 02/21/2012 03:47:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Format]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Format](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Format] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Thing]    Script Date: 02/21/2012 03:47:44 ******/
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
	[Name] [nvarchar](256) COLLATE Latin1_General_CI_AS NOT NULL,
	[Description] [nvarchar](max) COLLATE Latin1_General_CI_AS NOT NULL,
	[ShowOnHome] [bit] NOT NULL,
	[ShowForAll] [bit] NOT NULL,
	[FormatId] [uniqueidentifier] NOT NULL,
	[Rating] [int] NULL,
	[Image1] [varbinary](max) NULL,
	[Image2] [varbinary](max) NULL,
	[Comment] [nvarchar](1024) COLLATE Latin1_General_CI_AS NULL,
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
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Thing]') AND name = N'IX_FK_ThingFormat')
CREATE NONCLUSTERED INDEX [IX_FK_ThingFormat] ON [dbo].[Thing] 
(
	[FormatId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Thing]') AND name = N'IX_FK_ThingMaterial')
CREATE NONCLUSTERED INDEX [IX_FK_ThingMaterial] ON [dbo].[Thing] 
(
	[MaterialId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Thing]') AND name = N'IX_FK_Thingtate')
CREATE NONCLUSTERED INDEX [IX_FK_Thingtate] ON [dbo].[Thing] 
(
	[StateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 02/21/2012 03:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Email] [nvarchar](256) COLLATE Latin1_General_CI_AS NOT NULL,
	[Password] [binary](20) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND name = N'IX_FK_UserRole')
CREATE NONCLUSTERED INDEX [IX_FK_UserRole] ON [dbo].[User] 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThingTag]    Script Date: 02/21/2012 03:47:44 ******/
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
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ThingTag]') AND name = N'IX_FK_ThingTag_Tag')
CREATE NONCLUSTERED INDEX [IX_FK_ThingTag_Tag] ON [dbo].[ThingTag] 
(
	[TagId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 02/21/2012 03:47:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Article]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Article](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](100) COLLATE Latin1_General_CI_AS NOT NULL,
	[Text] [nvarchar](max) COLLATE Latin1_General_CI_AS NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[OwnerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Order]    Script Date: 02/21/2012 03:47:43 ******/
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
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND name = N'IX_FK_OrdertateOrder')
CREATE NONCLUSTERED INDEX [IX_FK_OrdertateOrder] ON [dbo].[Order] 
(
	[StateOrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND name = N'IX_FK_OrderThing')
CREATE NONCLUSTERED INDEX [IX_FK_OrderThing] ON [dbo].[Order] 
(
	[ThingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND name = N'IX_FK_UserOrder')
CREATE NONCLUSTERED INDEX [IX_FK_UserOrder] ON [dbo].[Order] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_ArticleOwner]    Script Date: 02/21/2012 03:47:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArticleOwner]') AND parent_object_id = OBJECT_ID(N'[dbo].[Article]'))
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_ArticleOwner] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[User] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ArticleOwner]') AND parent_object_id = OBJECT_ID(N'[dbo].[Article]'))
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_ArticleOwner]
GO
/****** Object:  ForeignKey [FK_OrdertateOrder]    Script Date: 02/21/2012 03:47:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdertateOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_OrdertateOrder] FOREIGN KEY([StateOrderId])
REFERENCES [dbo].[StateOrder] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdertateOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_OrdertateOrder]
GO
/****** Object:  ForeignKey [FK_OrderThing]    Script Date: 02/21/2012 03:47:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderThing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_OrderThing] FOREIGN KEY([ThingId])
REFERENCES [dbo].[Thing] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderThing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_OrderThing]
GO
/****** Object:  ForeignKey [FK_UserOrder]    Script Date: 02/21/2012 03:47:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_UserOrder] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_UserOrder]
GO
/****** Object:  ForeignKey [FK_ThingFormat]    Script Date: 02/21/2012 03:47:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingFormat]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing]  WITH CHECK ADD  CONSTRAINT [FK_ThingFormat] FOREIGN KEY([FormatId])
REFERENCES [dbo].[Format] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingFormat]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] CHECK CONSTRAINT [FK_ThingFormat]
GO
/****** Object:  ForeignKey [FK_ThingMaterial]    Script Date: 02/21/2012 03:47:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing]  WITH CHECK ADD  CONSTRAINT [FK_ThingMaterial] FOREIGN KEY([MaterialId])
REFERENCES [dbo].[Material] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] CHECK CONSTRAINT [FK_ThingMaterial]
GO
/****** Object:  ForeignKey [FK_ThingState]    Script Date: 02/21/2012 03:47:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingState]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing]  WITH CHECK ADD  CONSTRAINT [FK_ThingState] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingState]') AND parent_object_id = OBJECT_ID(N'[dbo].[Thing]'))
ALTER TABLE [dbo].[Thing] CHECK CONSTRAINT [FK_ThingState]
GO
/****** Object:  ForeignKey [FK_ThingTag_Tag]    Script Date: 02/21/2012 03:47:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag]  WITH CHECK ADD  CONSTRAINT [FK_ThingTag_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] CHECK CONSTRAINT [FK_ThingTag_Tag]
GO
/****** Object:  ForeignKey [FK_ThingTag_Thing]    Script Date: 02/21/2012 03:47:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Thing]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag]  WITH CHECK ADD  CONSTRAINT [FK_ThingTag_Thing] FOREIGN KEY([ThingId])
REFERENCES [dbo].[Thing] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Thing]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] CHECK CONSTRAINT [FK_ThingTag_Thing]
GO
/****** Object:  ForeignKey [FK_UserRole]    Script Date: 02/21/2012 03:47:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_UserRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_UserRole]
GO