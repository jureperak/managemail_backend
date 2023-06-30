# ManagemailBackend

Backend project for managing emails

Update connection string in Managemail.Alpha -> appSettings.json

SQL scripts for creating database and tables:

~~~~sql
CREATE DATABASE Managemail;
GO

USE [Managemail]

CREATE TABLE [dbo].[ImportanceType](
	[Id] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Abrv] [nvarchar](250) NOT NULL,
	[Sort] [int] NOT NULL,
 CONSTRAINT [PK_ImportanceType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EmailHistory](
	[Id] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	[FromEmailAddress] [nvarchar](250) NOT NULL,
	[ToEmailAddress] [nvarchar](250) NOT NULL,
	[CCEmailAddress] [nvarchar](1000) NULL,
	[Subject] [nvarchar](250) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[ImportanceTypeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EmailHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmailHistory]  WITH CHECK ADD  CONSTRAINT [FK_EmailHistory_ImportanceType] FOREIGN KEY([ImportanceTypeId])
REFERENCES [dbo].[ImportanceType] ([Id])
GO

ALTER TABLE [dbo].[EmailHistory] CHECK CONSTRAINT [FK_EmailHistory_ImportanceType]
GO

INSERT INTO [dbo].[ImportanceType]
           ([Id]
           ,[DateCreated]
           ,[DateUpdated]
           ,[Name]
           ,[Abrv]
           ,[Sort])
     VALUES
           (newid() ,getdate() ,getdate() ,'Low' ,'low' ,1),
		   (newid() ,getdate() ,getdate() ,'Normal' ,'normal' ,2),
		   (newid() ,getdate() ,getdate() ,'High' ,'high' ,3)
GO

~~~~
