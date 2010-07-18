using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Diagnostics;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class QuestionTests
    {
        ExamSystemDataContext db;

        [SetUp]
        public void Setup()
        {
            db = new ExamSystemDataContext();
            db.Connection.Open();
            db.ExecuteCommand("delete from dbo.questionchoice");
            db.ExecuteCommand("delete from dbo.question");
            db.Transaction = db.Connection.BeginTransaction();
        }

        [Test]
        public void Question_WhenCreated_HasId()
        {
            var question = new Question() { QuestionCategory = "category", QuestionText = "here is the question text", QuestionType = "M" };
            db.Questions.InsertOnSubmit(question);
            db.SubmitChanges();
            Assert.AreEqual(1, db.Questions.Count());
        }

        [TearDown]
        public void Teardown()
        {
            db.Transaction.Rollback();
            Debug.Assert(db.Choices.Count() == 0);
            db.Connection.Dispose();
        }
    }
}
