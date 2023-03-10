
/****** Object:  Database [Neosoft_Amit]    Script Date: 8/9/2021 10:50:23 AM ******/
-- 1.CREATE DATABASE [Neosoft_Amit]
-- 2.Run below entire script. It will create entire database table structure

ALTER DATABASE [Neosoft_Amit] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Neosoft_Amit].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Neosoft_Amit] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET ARITHABORT OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Neosoft_Amit] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Neosoft_Amit] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Neosoft_Amit] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Neosoft_Amit] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET RECOVERY FULL 
GO
ALTER DATABASE [Neosoft_Amit] SET  MULTI_USER 
GO
ALTER DATABASE [Neosoft_Amit] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Neosoft_Amit] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Neosoft_Amit] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Neosoft_Amit] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Neosoft_Amit] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Neosoft_Amit] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Neosoft_Amit', N'ON'
GO
ALTER DATABASE [Neosoft_Amit] SET QUERY_STORE = OFF
GO
USE [Neosoft_Amit]
GO
/****** Object:  Table [dbo].[City]    Script Date: 8/9/2021 10:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Row_Id] [int] IDENTITY(1,1) NOT NULL,
	[StateId] [int] NULL,
	[CityName] [nvarchar](50) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Row_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 8/9/2021 10:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Row_Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Row_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeMaster]    Script Date: 8/9/2021 10:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeMaster](
	[Row_Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeCode]  AS ('00'+right('0000000'+CONVERT([varchar](8),[Row_Id]),(8))) PERSISTED,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[CityId] [int] NULL,
	[EmailAddress] [varchar](100) NOT NULL,
	[MobileNumber] [varchar](15) NOT NULL,
	[PanNumber] [varchar](12) NOT NULL,
	[PassportNumber] [varchar](20) NOT NULL,
	[ProfileImage] [nvarchar](100) NULL,
	[Gender] [tinyint] NULL,
	[IsActive] [bit] NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[DateOfJoinee] [date] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_EmployeeMaster] PRIMARY KEY CLUSTERED 
(
	[Row_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 8/9/2021 10:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Log_Id] [int] IDENTITY(1,1) NOT NULL,
	[InnerException] [varchar](max) NULL,
	[StackTrace] [varchar](max) NULL,
	[Controller] [varchar](200) NULL,
	[RawUrl] [varchar](max) NULL,
	[Message] [varchar](max) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Log_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 8/9/2021 10:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Row_Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NULL,
	[StateName] [nvarchar](50) NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Row_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_EmployeeMaster_Email]    Script Date: 8/9/2021 10:50:24 AM ******/
ALTER TABLE [dbo].[EmployeeMaster] ADD  CONSTRAINT [UK_EmployeeMaster_Email] UNIQUE NONCLUSTERED 
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_EmployeeMaster_Mobile]    Script Date: 8/9/2021 10:50:24 AM ******/
ALTER TABLE [dbo].[EmployeeMaster] ADD  CONSTRAINT [UK_EmployeeMaster_Mobile] UNIQUE NONCLUSTERED 
(
	[MobileNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_EmployeeMaster_Pan]    Script Date: 8/9/2021 10:50:24 AM ******/
ALTER TABLE [dbo].[EmployeeMaster] ADD  CONSTRAINT [UK_EmployeeMaster_Pan] UNIQUE NONCLUSTERED 
(
	[PanNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_EmployeeMaster_Passport]    Script Date: 8/9/2021 10:50:24 AM ******/
ALTER TABLE [dbo].[EmployeeMaster] ADD  CONSTRAINT [UK_EmployeeMaster_Passport] UNIQUE NONCLUSTERED 
(
	[PassportNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeMaster] ADD  CONSTRAINT [DF_EmployeeMaster_Gender]  DEFAULT ((0)) FOR [Gender]
GO
ALTER TABLE [dbo].[EmployeeMaster] ADD  CONSTRAINT [DF_EmployeeMaster_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[EmployeeMaster] ADD  CONSTRAINT [DF_EmployeeMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[EmployeeMaster] ADD  CONSTRAINT [DF_EmployeeMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Log] ADD  CONSTRAINT [DF_Log_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Row_Id])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_State]
GO
ALTER TABLE [dbo].[EmployeeMaster]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeMaster_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Row_Id])
GO
ALTER TABLE [dbo].[EmployeeMaster] CHECK CONSTRAINT [FK_EmployeeMaster_City]
GO
ALTER TABLE [dbo].[EmployeeMaster]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeMaster_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Row_Id])
GO
ALTER TABLE [dbo].[EmployeeMaster] CHECK CONSTRAINT [FK_EmployeeMaster_Country]
GO
ALTER TABLE [dbo].[EmployeeMaster]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeMaster_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Row_Id])
GO
ALTER TABLE [dbo].[EmployeeMaster] CHECK CONSTRAINT [FK_EmployeeMaster_State]
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country1] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Row_Id])
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_Country1]
GO
/****** Object:  StoredProcedure [dbo].[stp_Emp_DeleteEmployee]    Script Date: 8/9/2021 10:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[stp_Emp_DeleteEmployee]
@employeeRowID int
as
begin
	update EmployeeMaster
	set IsDeleted=1,
	DeletedDate=getdate()
	where [Row_Id]=@employeeRowID
end
GO
/****** Object:  StoredProcedure [dbo].[stp_Emp_GetAllCitiesByStateId]    Script Date: 8/9/2021 10:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[stp_Emp_GetAllCitiesByStateId]
@stateId int
as
begin
	select [Row_Id] as cityId,[CityName] from [dbo].[City] where StateId=@stateId order by [CityName]
end
GO
/****** Object:  StoredProcedure [dbo].[stp_Emp_GetAllCountries]    Script Date: 8/9/2021 10:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[stp_Emp_GetAllCountries]
as
begin
	select [Row_Id],[CountryName] from [dbo].[Country] order by CountryName
end
GO
/****** Object:  StoredProcedure [dbo].[stp_Emp_GetAllEmployees]    Script Date: 8/9/2021 10:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[stp_Emp_GetAllEmployees]
as
begin
	SELECT e.[Row_Id]
      ,e.[EmployeeCode]
      ,e.[FirstName]
      ,e.[LastName]
      ,e.[CountryId]
	  ,c.[CountryName]
      ,e.[StateId]
	  ,s.[StateName]
      ,e.[CityId]
	  ,ci.[CityName]
      ,e.[EmailAddress]
      ,e.[MobileNumber]
      ,e.[PanNumber]
      ,e.[PassportNumber]
      ,e.[ProfileImage]
      ,e.[Gender]
      ,e.[IsActive]
      ,e.[DateOfBirth]
      ,e.[DateOfJoinee]
  FROM [dbo].[EmployeeMaster] e
  inner join [dbo].[Country] c
  on c.[Row_Id]=e.[CountryId]
  inner join [dbo].[State] s
  on s.[Row_Id]=e.[StateId]
  inner join [dbo].[City] ci
  on ci.[Row_Id]=e.[CityId]

  where [IsDeleted]=0
end
GO
/****** Object:  StoredProcedure [dbo].[stp_Emp_GetAllStatesByCountryId]    Script Date: 8/9/2021 10:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[stp_Emp_GetAllStatesByCountryId]
@countryId int
as
begin
	select [Row_Id] as stateId,[StateName] from [dbo].[State] where CountryId=@countryId order by [StateName] 
end
GO
/****** Object:  StoredProcedure [dbo].[stp_Emp_InsertUpdateEmployee]    Script Date: 8/9/2021 10:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[stp_Emp_InsertUpdateEmployee]
@row_Id int,
@firstName varchar(50),
@lastName varchar(50)=null,
@emailAddress varchar(100),
@mobileNumber varchar(15),
@panNumber varchar(12),
@passportNumber varchar(20),
@dateOfBirth varchar(50), 
@dateOfJoinee varchar(50)=null,
@profileImage varchar(50)=null,
@countryId int,
@stateId int,
@cityId int,
@gender tinyint,
@isActive bit
as
begin
	if(@row_Id=0)
	begin
		insert into [dbo].[EmployeeMaster]
		([FirstName],
		[LastName],
		[EmailAddress],
		[MobileNumber],
		[PanNumber],
		[PassportNumber],
		[DateOfBirth],
		[DateOfJoinee],
		[ProfileImage],
		[CountryId],
		[StateId],
		[CityId],
		[Gender],
		[IsActive])
		values(
		@firstName,
		@lastName,
		@emailAddress,
		@mobileNumber,
		@panNumber,
		@passportNumber,
		CONVERT(datetime,RIGHT(@dateOfBirth,4)+SUBSTRING(@dateOfBirth,4,2)+LEFT(@dateOfBirth,2)),
		CONVERT(datetime,RIGHT(@dateOfJoinee,4)+SUBSTRING(@dateOfJoinee,4,2)+LEFT(@dateOfJoinee,2)),
		@profileImage,
		@countryId,
		@stateId,
		@cityId,
		@gender,
		@isActive)
	end
	else
	begin
		if(@profileImage!=null)
		begin
			update [dbo].[EmployeeMaster]
			set [FirstName]=@firstName,
			[LastName]=@lastName,
			[EmailAddress]=@emailAddress,
			[MobileNumber]=@mobileNumber,
			[PanNumber]=@panNumber,
			[PassportNumber]=@passportNumber,
			[DateOfBirth]=CONVERT(datetime,RIGHT(@dateOfBirth,4)+SUBSTRING(@dateOfBirth,4,2)+LEFT(@dateOfBirth,2)),
			[DateOfJoinee]=CONVERT(datetime,RIGHT(@dateOfJoinee,4)+SUBSTRING(@dateOfJoinee,4,2)+LEFT(@dateOfJoinee,2)),
			[ProfileImage]=@profileImage,
			[CountryId]=@countryId,
			[StateId]=@stateId,
			[CityId]=@cityId,
			[Gender]=@gender,
			[IsActive]=@isActive,
			[UpdatedDate]=getdate()
			where [Row_Id]=@row_Id
		end
		else
		begin
			update [dbo].[EmployeeMaster]
			set [FirstName]=@firstName,
			[LastName]=@lastName,
			[EmailAddress]=@emailAddress,
			[MobileNumber]=@mobileNumber,
			[PanNumber]=@panNumber,
			[PassportNumber]=@passportNumber,
			[DateOfBirth]=CONVERT(datetime,RIGHT(@dateOfBirth,4)+SUBSTRING(@dateOfBirth,4,2)+LEFT(@dateOfBirth,2)),
			[DateOfJoinee]=CONVERT(datetime,RIGHT(@dateOfJoinee,4)+SUBSTRING(@dateOfJoinee,4,2)+LEFT(@dateOfJoinee,2)),
			[CountryId]=@countryId,
			[StateId]=@stateId,
			[CityId]=@cityId,
			[Gender]=@gender,
			[IsActive]=@isActive,
			[UpdatedDate]=getdate()
			where [Row_Id]=@row_Id
		end
		
	end
end
GO
/****** Object:  StoredProcedure [dbo].[stp_Emp_IsDuplicateField]    Script Date: 8/9/2021 10:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[stp_Emp_IsDuplicateField]
@fieldName varchar(50),
@fieldValue varchar(100)
as
begin
	if CHARINDEX('email',LOWER(@fieldName)) > 0
	begin
		select count([Row_Id]) as Count from [dbo].[EmployeeMaster] where [EmailAddress]=@fieldValue
	end
	else if CHARINDEX('mobile',LOWER(@fieldName)) > 0
	begin
		select count([Row_Id]) as Count from [dbo].[EmployeeMaster] where [MobileNumber]=@fieldValue
	end
	else if CHARINDEX('pan',LOWER(@fieldName)) > 0
	begin
		select count([Row_Id]) as Count from [dbo].[EmployeeMaster] where [PanNumber]=@fieldValue
	end
	else if CHARINDEX('passport',LOWER(@fieldName)) > 0
	begin
		select count([Row_Id]) as Count from [dbo].[EmployeeMaster] where [PassportNumber]=@fieldValue
	end
	else
	begin
		select '1' as Count;
	end
end
GO
/****** Object:  StoredProcedure [dbo].[stp_Log_InsertLog]    Script Date: 8/9/2021 10:50:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[stp_Log_InsertLog]
@InnerException varchar(max),
@StackTrace varchar(max),
@RawUrl varchar(max),
@Controller varchar(200),
@Message varchar(max)
as
begin
	insert into [dbo].[Log]([InnerException],[StackTrace],[Controller],[RawUrl],[Message])
	values(@InnerException,@StackTrace,@Controller,@RawUrl,@Message)
end
GO
USE [master]
GO
ALTER DATABASE [Neosoft_Amit] SET  READ_WRITE 
GO
