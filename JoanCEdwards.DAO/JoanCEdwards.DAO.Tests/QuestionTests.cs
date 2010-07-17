using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

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
            Teardown();
        }

        [Test]
        public void Question_WhenCreated_HasId()
        {
            var question = new Question() { QuestionCategory = "label", QuestionText = "here is the question text", QuestionType = "M" };
            db.Questions.InsertOnSubmit(question);
            db.SubmitChanges();
            Assert.AreEqual(1, question.QuestionId);
        }

        [TearDown]
        public void Teardown()
        {
            db.ExecuteCommand("truncate table dbo.Question");
        }
    }
}
