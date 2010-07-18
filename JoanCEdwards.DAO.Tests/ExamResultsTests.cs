using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Data.SqlClient;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class ExamResultsTests : DataAccessTestBase
    {
        [Test]
        public void ExamResult_CanCreateOneForUser()
        {
            StoreDefaultExamResult();
            Assert.AreEqual(1, db.ExamResults.Count());
        }

        [Test]
        [ExpectedException(typeof(SqlException))]
        public void ExamResult_CannotHaveManyResultsForSameUserOnSameExam()
        {
            StoreDefaultExamResult();
            StoreDefaultExamResult();
        }

        [Test]
        public void ExamResult_CanHaveMultipleResultsForMultipleUsersOnSameExam()
        {
            StoreDefaultExamResult();
            StoreDefaultExamResult("emailAddress1");
            Assert.AreEqual(2, db.ExamResults.Count());
        }

        private void StoreDefaultExamResult(string emailAddress = "emailaddress")
        {
            var exam = new Exam() { Instructions = "instructions", Title = "title" };
            db.Exams.InsertOnSubmit(exam);
            var userProfile = new UserProfile() { EmailAddress = emailAddress, FirstName = "firstname", LastName = "lastname", Password = "password", GradeLevel = "12", UserType = 'M', Status = true };
            db.UserProfiles.InsertOnSubmit(userProfile);
            userProfile.ExamResults.Add(new ExamResult() { Exam = exam, UserProfile = userProfile, Status = "not started", MaxScore = 100 });
            db.SubmitChanges();
        }
    }
}
