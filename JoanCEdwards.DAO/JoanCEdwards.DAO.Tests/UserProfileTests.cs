using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class UserProfileTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void UserProfile_WhenStored_ReturnsId()
        {
            ExamSystemDataContext db = new ExamSystemDataContext();
            UserProfile profile = new UserProfile(){EmailAddress = "email", FirstName = "name", LastName = "lname", GradeLevel = "5", UserType = 'S'};
            db.UserProfiles.InsertOnSubmit(profile);
            db.SubmitChanges();
            Assert.AreEqual(1, db.UserProfiles.First().UserId);
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
