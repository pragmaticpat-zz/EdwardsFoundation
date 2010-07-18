using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class ExamResultsTests
    {
        ExamSystemDataContext db;
        [SetUp]
        public void Setup()
        {
            db = new ExamSystemDataContext();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
        }


        [Test]
        public void ExamResult_CanCreateOneForUser()
        {
            var exam = new Exam() { Instructions = "instructions", Title = "title" };
            db.Exams.InsertOnSubmit(exam);
            var userProfile = new UserProfile() { EmailAddress = "emailaddress", FirstName = "firstname", LastName = "lastname", Password = "password", GradeLevel = "12", UserType = 'M', Status = true };
            db.UserProfiles.InsertOnSubmit(userProfile);
            userProfile.ExamResults.Add(new ExamResult() { Exam = exam, UserProfile = userProfile, Status = "not started", MaxScore = 100 });
            db.SubmitChanges();
            Assert.AreEqual(1, db.ExamResults.Count());
        }

        [TearDown]
        public void Teardown()
        {
            db.Transaction.Rollback();
        }
    }
}
