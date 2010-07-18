using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class QuestionChoicesTests
    {
        ExamSystemDataContext db;

        [SetUp]
        public void Setup()
        {
            db = new ExamSystemDataContext();
            db.ExecuteCommand("delete from dbo.QuestionChoice");
            db.SubmitChanges();
            db.ExecuteCommand("delete from dbo.Choice");
            db.ExecuteCommand("delete from dbo.Question");
            db.SubmitChanges();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
        }

        [Test]
        public void Question_CanHaveOneChoice()
        {
            var question = new Question() { QuestionText = "Question Text", QuestionCategory = "Category" };
            var choice = new Choice() { Label = "label", Value = -1 };
            var questionchoice = new QuestionChoice() { Question = question, Choice = choice, SortOrder = 1 };
            db.Questions.InsertOnSubmit(question);
            db.Choices.InsertOnSubmit(choice);
            db.QuestionChoices.InsertOnSubmit(questionchoice);
            Assert.AreEqual(1, question.QuestionChoices.Count);
        }

        [Test]
        public void Question_CanHaveMultipleChoices()
        {
            
        }

        [TearDown]
        public void Teardown()
        {
            db.Transaction.Rollback();
        }
    }
}
