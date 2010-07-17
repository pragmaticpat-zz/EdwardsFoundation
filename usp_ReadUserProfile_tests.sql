USE [EdwardsFoundation]
GO

declare @expected_table table (
	FirstName nvarchar(max) NOT NULL,
	LastName nvarchar(max) NOT NULL,
	UserType nchar(10) NOT NULL,
	EmailAddress nvarchar(max) NOT NULL,
	UserId int IDENTITY(1,1) NOT NULL,
	GradeLevel nchar(10) NOT NULL,
	)
	
insert into @expected_table (FirstName, LastName, UserType, EmailAddress, UserId, GradeLevel) values ('FirstName', 'LastName', 'UserType', 'EmailAddress', 1, 'GradeLevel')
declare @actual_userid int

exec [dbo].[usp_CreateUserProfile] 'FirstName', 'LastName', 'UserType', 'EmailAddress', 'GradeLevel', @actual_userid output
declare @actual_table table
declare @actual_firstname nvarchar(max)
declare @actual_lastname nvarchar(max)
declare @actual_emailaddress nvarchar(max)
declare @actual_gradelevel nvarchar(max)
declare @actual_usertype nvarchar(max)
exec [dbo].[usp_ReadUserProfile] @actual_userid, @actual_table

if(@expected_table != @actual_table)
	print 'ERROR: dbo.usp_ReadUserProfile: Expected ' + str(@expected_userid) + ' , but got ' + str(@actual_userid)

GO
truncate table dbo.UserProfile

