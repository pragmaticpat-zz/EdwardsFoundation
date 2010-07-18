using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Data.SqlClient;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class UserProfileTests : DataAccessTestBase
    {
        UserProfile expectedProfile;
        UserProfile actualProfile;

        [Test]
        public void UserProfile_WhenStored_ReturnsId()
        {
            StoreExpectedProfile();
            Assert.AreEqual(1, db.UserProfiles.Count());
        }

        [Test]
        public void UserProfile_WhenDeleted_IsNotRemovedFromTheDatabase()
        {
            StoreExpectedProfile();
            db.DeleteUser(expectedProfile.UserId);
            actualProfile = (from p in db.UserProfiles
                             where p.UserId == expectedProfile.UserId
                             select p).First();
            Assert.AreEqual(false, actualProfile.Status);
        }

        [Test]
        public void UserProfile_WhenAddingMultiple_IsTheRightSize()
        {
            for (int i = 0; i < 5; i++) //one done in setup
            {
                expectedProfile = new UserProfile() { EmailAddress = "email"+i, FirstName = "name", LastName = "lname", GradeLevel = "5", UserType = 'S' };
                db.UserProfiles.InsertOnSubmit(expectedProfile);
                db.SubmitChanges();
            }
            Assert.AreEqual(5, db.UserProfiles.Count());
        }

        [Test]
        [ExpectedException(typeof(SqlException))]
        public void UserProfile_WhenAddTwoProfilesWithSameEmailAddress_ErrorOccurs()
        {
            StoreExpectedProfile();
            StoreExpectedProfile();
        }


        private void StoreExpectedProfile()
        {
            expectedProfile = new UserProfile() { EmailAddress = "email", FirstName = "name", LastName = "lname", GradeLevel = "5", UserType = 'S' };
            db.UserProfiles.InsertOnSubmit(expectedProfile);
            db.SubmitChanges();
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
    }
}
