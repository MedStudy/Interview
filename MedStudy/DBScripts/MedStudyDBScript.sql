USE [Employee]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 02-12-2022 12:44:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Year] [nchar](10) NULL,
	[State] [nvarchar](50) NULL,
	[Address1] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NULL,
	[Zipcode] [nchar](10) NULL,
	[Country] [nchar](10) NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[States]    Script Date: 02-12-2022 12:44:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[States](
	[Code] [char](2) NULL,
	[Name] [varchar](50) NULL
) ON [PRIMARY]
GO

INSERT INTO States VALUES
('AL','ALABAMA'),
('AK','ALASKA'),
('AB','ALBERTA'),
('AS','AMERICAN SAMOA'),
('AZ','ARIZONA'),
('AR','ARKANSAS'),
('BC','BRITISH COLUMBIA'),
('CA','CALIFORNIA'),
('PW','CAROLINE ISLANDS'),
('CO','COLORADO'),
('CT','CONNETICUT'),
('DE','DELAWARE'),
('DC','DISTRICT OF COLUMBIA'),
('FM','FEDERATED STATE'),
('FL','FLORIDA'),
('GA','GEORGIA'),
('GU','GUAM'),
('HI','HAWAII'),
('ID','IDOHA'),
('IL','ILLINOIS'),
('IN','INDIANA'),
('IA','IOWA'),
('KS','KANSAS'),
('KY','KENTUCKY'),
('LA','LOUSIANA'),
('ME','MAINE'),
('MB','MANITOBA'),
('MP','MARIANA ISLANDS'),
('MH','MARSHALL ISLANDS'),
('MD','MARYLAND'),
('MA','MASSACHUSETTS'),
('MI','MICHIGAN'),
('MN','MINNESOTA'),
('MS','MISSISSIPPI'),
('MO','MISSOURI'),
('MT','MONTANA'),
('NE','NEBRASKA'),
('NV','NEVADA'),
('NB','NEW BRUNSWICK'),
('NH','NEW HAMPSHIRE'),
('NJ','NEW JERSEY'),
('NM','NEW MEXICO'),
('NY','NEW YORK'),
('NF','NEWFOUNDLAND'),
('NC','NORTH CAROLINA'),
('ND','NORTH DAKOTA'),
('NT','NORTHWEST TERRITORIES'),
('NS','NOVA SCOTIA'),
('NU','NUNAVUT'),
('OH','OHIO'),
('OK','OKLAHOMA'),
('ON','ONTARIO'),
('OR','OREGON'),
('PA','PENNSYLVANIA'),
('PE','PRINCE EDWARD ISLAND'),
('PR','PUERTO RICO'),
('PQ','QUEBEC'),
('RI','RHODE ISLAND'),
('SK','SASKATCHEWAN'),
('SC','SOUTH CAROLINA'),
('SD','SOUTH DAKOTA'),
('TN','TENNESSEE'),
('TX','TEXAS'),
('UT','UTAH'),
('VT','VERMONT'),
('VI','VIRGIN ISLANDS'),
('VA','VIRGINIA'),
('WA','WASHINGTON'),
('WV','WEST VIRGINIA'),
('WI','WISCONSIN'),
('WY','WYOMING'),
('YT','YUKON TERRITORY'),
('AE','ARMED FORCES - EUROPE'),
('AA','ARMED FORCES - AMERICAS'),
('AP','ARMED FORCES - PACIFIC')

GO

/****** Object:  StoredProcedure [dbo].[PorcGetEmployeeDetails]    Script Date: 02-12-2022 12:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PorcGetEmployeeDetails]
	@FirstName nvarchar(100) = null,
	@LastName nvarchar(100) = null,
	@State nchar(10) = null,
	@Year nvarchar(10) = null
AS
BEGIN	
	SELECT	[EmployeeID]
		   ,[FirstName]
           ,[LastName]
           ,[Year]
           ,[State]
           ,[Address1]
           ,[Address2]
           ,[Zipcode]
           ,[Country]
	FROM [dbo].[Employee]
	where ((@FirstName IS NULL OR @FirstName = '') OR FirstName like '%'+ @FirstName + '%')
	AND ((@LastName IS NULL OR @LastName = '')  OR LastName like '%'+ @LastName + '%')
	AND ((@State IS NULL OR @State = '') OR [State] = @State)
	AND ((@Year IS NULL  OR @Year = '') OR Year = @Year)
END

/****** Object:  StoredProcedure [dbo].[ProcGetStates]    Script Date: 02-12-2022 12:46:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ProcGetStates]
AS
BEGIN	
	SELECT	[Code] as StateCode
		   ,[Name]   as StateName         
	FROM [dbo].[States]	order by [name] asc
END 
