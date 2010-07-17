USE [EdwardsFoundation]
GO

declare @actual_userid int
declare @expected_userid int = 1
exec [dbo].[usp_CreateUserProfile] 'FirstName', 'LastName', 'UserType', 'EmailAddress', 'GradeLevel', @actual_userid output

if(@expected_userid != @actual_userid)
	print 'ERROR: dbo.usp_CreateUserProfile: Expected ' + str(@expected_userid) + ' , but got ' + str(@actual_userid)

GO
truncate table dbo.UserProfile
