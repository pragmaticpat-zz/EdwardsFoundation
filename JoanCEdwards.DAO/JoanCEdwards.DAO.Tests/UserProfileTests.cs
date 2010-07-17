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
        ExamSystemDataContext db;
        UserProfile expectedProfile;
        UserProfile actualProfile;

        [SetUp]
        public void Setup() {
            db = new ExamSystemDataContext();
            expectedProfile = new UserProfile() { EmailAddress = "email", FirstName = "name", LastName = "lname", GradeLevel = "5", UserType = 'S' };
            db.UserProfiles.InsertOnSubmit(expectedProfile);
            db.SubmitChanges();
        }

        [Test]
        public void UserProfile_WhenStored_ReturnsId()
        {
            Assert.AreEqual(1, db.UserProfiles.First().UserId);
        }

        [Test]
        public void UserProfile_WhenRetrieved_IsWhatWasStored()
        {
            actualProfile = (from p in db.UserProfiles
                                where p.UserId == expectedProfile.UserId
                                select p).First();

            AssertThatExpectedProfileEquals(actualProfile);
        }

        [Test]
        public void UserProfile_WhenDeleted_IsNotRemovedFromTheDatabase()
        {
            db.DeleteUser(expectedProfile.UserId);
            actualProfile = (from p in db.UserProfiles
                             where p.UserId == expectedProfile.UserId
                             select p).First();
            Assert.AreEqual(false,actualProfile.Status);
        }

        [Test]
        public void UserProfile_WhenAddingMultiple_IsTheRightSize()
        {
            for (int i = 0; i < 4; i++) //one done in setup
            {
                expectedProfile = new UserProfile() { EmailAddress = "email", FirstName = "name", LastName = "lname", GradeLevel = "5", UserType = 'S' };
                db.UserProfiles.InsertOnSubmit(expectedProfile);
                db.SubmitChanges();
            }
            Assert.AreEqual(5,db.UserProfiles.Count());
        }



        private void AssertThatExpectedProfileEquals(UserProfile actualProfile)
        {
            Assert.AreEqual(expectedProfile.UserId, actualProfile.UserId);
            Assert.AreEqual(expectedProfile.FirstName, actualProfile.FirstName);
            Assert.AreEqual(expectedProfile.LastName, actualProfile.LastName);
            Assert.AreEqual(expectedProfile.EmailAddress, actualProfile.EmailAddress);
            Assert.AreEqual(expectedProfile.GradeLevel, actualProfile.GradeLevel);
            Assert.AreEqual(expectedProfile.UserType, actualProfile.UserType);
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
