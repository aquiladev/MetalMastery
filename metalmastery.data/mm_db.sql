IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'mm_db')
CREATE DATABASE [mm_db] COLLATE Latin1_General_CI_AS
GO

USE [mm_db]
GO
/****** Object:  ForeignKey [FK_OrderStateOrder]    Script Date: 01/25/2012 02:13:19 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderStateOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderStateOrder]
GO
/****** Object:  ForeignKey [FK_OrderThing]    Script Date: 01/25/2012 02:13:19 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderThing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderThing]
GO
/****** Object:  ForeignKey [FK_UserOrder]    Script Date: 01/25/2012 02:13:19 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_UserOrder]
GO
/****** Object:  ForeignKey [FK_ThingFormat]    Script Date: 01/25/2012 02:13:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingFormat]') AND parent_object_id = OBJECT_ID(N'[dbo].[Things]'))
ALTER TABLE [dbo].[Things] DROP CONSTRAINT [FK_ThingFormat]
GO
/****** Object:  ForeignKey [FK_ThingMaterial]    Script Date: 01/25/2012 02:13:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[Things]'))
ALTER TABLE [dbo].[Things] DROP CONSTRAINT [FK_ThingMaterial]
GO
/****** Object:  ForeignKey [FK_ThingState]    Script Date: 01/25/2012 02:13:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingState]') AND parent_object_id = OBJECT_ID(N'[dbo].[Things]'))
ALTER TABLE [dbo].[Things] DROP CONSTRAINT [FK_ThingState]
GO
/****** Object:  ForeignKey [FK_ThingTag_Tag]    Script Date: 01/25/2012 02:13:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] DROP CONSTRAINT [FK_ThingTag_Tag]
GO
/****** Object:  ForeignKey [FK_ThingTag_Thing]    Script Date: 01/25/2012 02:13:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Thing]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] DROP CONSTRAINT [FK_ThingTag_Thing]
GO
/****** Object:  ForeignKey [FK_UserRole]    Script Date: 01/25/2012 02:13:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_UserRole]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 01/25/2012 02:13:19 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderStateOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderStateOrder]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderThing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderThing]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_UserOrder]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Orders__Id__41EDCAC5]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [DF__Orders__Id__41EDCAC5]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
DROP TABLE [dbo].[Orders]
GO
/****** Object:  Table [dbo].[ThingTag]    Script Date: 01/25/2012 02:13:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] DROP CONSTRAINT [FK_ThingTag_Tag]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Thing]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] DROP CONSTRAINT [FK_ThingTag_Thing]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ThingTag]') AND type in (N'U'))
DROP TABLE [dbo].[ThingTag]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01/25/2012 02:13:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_UserRole]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Users__Id__3D2915A8]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__Users__Id__3D2915A8]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Things]    Script Date: 01/25/2012 02:13:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingFormat]') AND parent_object_id = OBJECT_ID(N'[dbo].[Things]'))
ALTER TABLE [dbo].[Things] DROP CONSTRAINT [FK_ThingFormat]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[Things]'))
ALTER TABLE [dbo].[Things] DROP CONSTRAINT [FK_ThingMaterial]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingState]') AND parent_object_id = OBJECT_ID(N'[dbo].[Things]'))
ALTER TABLE [dbo].[Things] DROP CONSTRAINT [FK_ThingState]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Things__Id__3A4CA8FD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Things] DROP CONSTRAINT [DF__Things__Id__3A4CA8FD]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Things]') AND type in (N'U'))
DROP TABLE [dbo].[Things]
GO
/****** Object:  Table [dbo].[Formats]    Script Date: 01/25/2012 02:13:19 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Formats__Id__37703C52]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Formats] DROP CONSTRAINT [DF__Formats__Id__37703C52]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Formats]') AND type in (N'U'))
DROP TABLE [dbo].[Formats]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 01/25/2012 02:13:19 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Materials__Id__3493CFA7]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Materials] DROP CONSTRAINT [DF__Materials__Id__3493CFA7]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Materials]') AND type in (N'U'))
DROP TABLE [dbo].[Materials]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 01/25/2012 02:13:19 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Roles__Id__31B762FC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF__Roles__Id__31B762FC]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[StateOrders]    Script Date: 01/25/2012 02:13:19 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__StateOrders__Id__2EDAF651]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[StateOrders] DROP CONSTRAINT [DF__StateOrders__Id__2EDAF651]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StateOrders]') AND type in (N'U'))
DROP TABLE [dbo].[StateOrders]
GO
/****** Object:  Table [dbo].[States]    Script Date: 01/25/2012 02:13:20 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__States__Id__2BFE89A6]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[States] DROP CONSTRAINT [DF__States__Id__2BFE89A6]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[States]') AND type in (N'U'))
DROP TABLE [dbo].[States]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 01/25/2012 02:13:20 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Tags__Id__29221CFB]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tags] DROP CONSTRAINT [DF__Tags__Id__29221CFB]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tags]') AND type in (N'U'))
DROP TABLE [dbo].[Tags]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 01/25/2012 02:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tags]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tags](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[States]    Script Date: 01/25/2012 02:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[States]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[States](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[StateOrders]    Script Date: 01/25/2012 02:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StateOrders]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StateOrders](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_StateOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 01/25/2012 02:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Roles](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 01/25/2012 02:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Materials]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Materials](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Formats]    Script Date: 01/25/2012 02:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Formats]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Formats](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Formats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Things]    Script Date: 01/25/2012 02:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Things]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Things](
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
 CONSTRAINT [PK_Things] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Things]') AND name = N'IX_FK_ThingFormat')
CREATE NONCLUSTERED INDEX [IX_FK_ThingFormat] ON [dbo].[Things] 
(
	[FormatId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Things]') AND name = N'IX_FK_ThingMaterial')
CREATE NONCLUSTERED INDEX [IX_FK_ThingMaterial] ON [dbo].[Things] 
(
	[MaterialId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Things]') AND name = N'IX_FK_ThingState')
CREATE NONCLUSTERED INDEX [IX_FK_ThingState] ON [dbo].[Things] 
(
	[StateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01/25/2012 02:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[Email] [nvarchar](256) NOT NULL,
	[Password] [nvarchar](32) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = N'IX_FK_UserRole')
CREATE NONCLUSTERED INDEX [IX_FK_UserRole] ON [dbo].[Users] 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThingTag]    Script Date: 01/25/2012 02:13:20 ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 01/25/2012 02:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Orders](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newsequentialid()),
	[CreateDate] [datetime] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[StateOrderId] [uniqueidentifier] NOT NULL,
	[ThingId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND name = N'IX_FK_OrderStateOrder')
CREATE NONCLUSTERED INDEX [IX_FK_OrderStateOrder] ON [dbo].[Orders] 
(
	[StateOrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND name = N'IX_FK_OrderThing')
CREATE NONCLUSTERED INDEX [IX_FK_OrderThing] ON [dbo].[Orders] 
(
	[ThingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND name = N'IX_FK_UserOrder')
CREATE NONCLUSTERED INDEX [IX_FK_UserOrder] ON [dbo].[Orders] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_OrderStateOrder]    Script Date: 01/25/2012 02:13:19 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderStateOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_OrderStateOrder] FOREIGN KEY([StateOrderId])
REFERENCES [dbo].[StateOrders] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderStateOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_OrderStateOrder]
GO
/****** Object:  ForeignKey [FK_OrderThing]    Script Date: 01/25/2012 02:13:19 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderThing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_OrderThing] FOREIGN KEY([ThingId])
REFERENCES [dbo].[Things] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderThing]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_OrderThing]
GO
/****** Object:  ForeignKey [FK_UserOrder]    Script Date: 01/25/2012 02:13:19 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_UserOrder] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserOrder]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_UserOrder]
GO
/****** Object:  ForeignKey [FK_ThingFormat]    Script Date: 01/25/2012 02:13:20 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingFormat]') AND parent_object_id = OBJECT_ID(N'[dbo].[Things]'))
ALTER TABLE [dbo].[Things]  WITH CHECK ADD  CONSTRAINT [FK_ThingFormat] FOREIGN KEY([FormatId])
REFERENCES [dbo].[Formats] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingFormat]') AND parent_object_id = OBJECT_ID(N'[dbo].[Things]'))
ALTER TABLE [dbo].[Things] CHECK CONSTRAINT [FK_ThingFormat]
GO
/****** Object:  ForeignKey [FK_ThingMaterial]    Script Date: 01/25/2012 02:13:20 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[Things]'))
ALTER TABLE [dbo].[Things]  WITH CHECK ADD  CONSTRAINT [FK_ThingMaterial] FOREIGN KEY([MaterialId])
REFERENCES [dbo].[Materials] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingMaterial]') AND parent_object_id = OBJECT_ID(N'[dbo].[Things]'))
ALTER TABLE [dbo].[Things] CHECK CONSTRAINT [FK_ThingMaterial]
GO
/****** Object:  ForeignKey [FK_ThingState]    Script Date: 01/25/2012 02:13:20 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingState]') AND parent_object_id = OBJECT_ID(N'[dbo].[Things]'))
ALTER TABLE [dbo].[Things]  WITH CHECK ADD  CONSTRAINT [FK_ThingState] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingState]') AND parent_object_id = OBJECT_ID(N'[dbo].[Things]'))
ALTER TABLE [dbo].[Things] CHECK CONSTRAINT [FK_ThingState]
GO
/****** Object:  ForeignKey [FK_ThingTag_Tag]    Script Date: 01/25/2012 02:13:20 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag]  WITH CHECK ADD  CONSTRAINT [FK_ThingTag_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] CHECK CONSTRAINT [FK_ThingTag_Tag]
GO
/****** Object:  ForeignKey [FK_ThingTag_Thing]    Script Date: 01/25/2012 02:13:20 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Thing]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag]  WITH CHECK ADD  CONSTRAINT [FK_ThingTag_Thing] FOREIGN KEY([ThingId])
REFERENCES [dbo].[Things] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ThingTag_Thing]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThingTag]'))
ALTER TABLE [dbo].[ThingTag] CHECK CONSTRAINT [FK_ThingTag_Thing]
GO
/****** Object:  ForeignKey [FK_UserRole]    Script Date: 01/25/2012 02:13:20 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_UserRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_UserRole]
GO
