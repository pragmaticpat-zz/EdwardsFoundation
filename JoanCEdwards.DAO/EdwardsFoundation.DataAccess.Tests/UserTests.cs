using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JoanCEdwards.DAO;

namespace EdwardsFoundation.DataAccess.Tests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void User_WhenSave_GetId()
        {
            int userId = new User() { FirstName = "a", LastName = "b", EmailAddress = "e", UserType = 'M', GradeLevel = "10"}.Save();
            Assert.AreEqual(1, userId);
        }

        [Test]
        public void User_WhenSave2_Get2ForSecondId()
        {
            new User() { FirstName = "a", LastName = "b", EmailAddress = "e", UserType = 'M', GradeLevel = "10" }.Save();
            int userId = new User() { FirstName = "a", LastName = "b", EmailAddress = "f", UserType = 'M', GradeLevel = "10" }.Save();
            Assert.AreEqual(2, userId);
        }

        [TearDown]
        public void Teardown()
        {
            var db = new ExamSystemDataContext();
            db.ExecuteCommand("truncate table dbo.UserProfile");
            db.SubmitChanges();
        }
    }
}
