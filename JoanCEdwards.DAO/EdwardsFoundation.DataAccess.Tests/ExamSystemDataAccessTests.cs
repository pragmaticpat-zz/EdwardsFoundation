using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JoanCEdwards.DAO;

namespace EdwardsFoundation.DataAccess.Tests
{
    public class ExamSystemDataAccessTests
    {
        [SetUp]
        public void Setup()
        {
            Teardown();
        }

        [Test]
        public void CreateUser_IsNotNull()
        {
            ExamSystemDataAccess da = new ExamSystemDataAccess();
            IUser actual_user = da.CreateUser("g", "firstname", "lastname", 'S', "5", "xyz");
            Assert.IsNotNull(actual_user);
        }

        [Test]
        public void CreateUser_WhenRead_IsFound()
        {
            var da = new ExamSystemDataAccess();
            var emailAddress = "email@daddress.com";
            var expectedUser = new UserProfile() { EmailAddress = emailAddress, FirstName = "f", LastName = "l", UserType = 'u', GradeLevel = "gl", Password = "password" };
            da.CreateUser(emailAddress, expectedUser.FirstName, expectedUser.LastName, expectedUser.UserType, expectedUser.GradeLevel, expectedUser.Password);
            var actualUser = da.GetUserByEmailAddress(emailAddress);
            AssertThatUsersEqual(expectedUser, actualUser);
        }

        private void AssertThatUsersEqual(IUser expectedUser, IUser actualUser)
        {
            Assert.AreEqual(expectedUser.FirstName, actualUser.FirstName);
            Assert.AreEqual(expectedUser.LastName, actualUser.LastName);
            Assert.AreEqual(expectedUser.EmailAddress, actualUser.EmailAddress);
            Assert.AreEqual(expectedUser.UserType, actualUser.UserType);
            Assert.AreEqual(expectedUser.GradeLevel, actualUser.GradeLevel);
            Assert.AreEqual(expectedUser.Password, actualUser.Password);
        }

        [TearDown]
        public void Teardown()
        {
            ExamSystemDataContext db = new ExamSystemDataContext();
            db.ExecuteCommand("truncate table dbo.UserProfile");
            db.SubmitChanges();
        }

    }
}
