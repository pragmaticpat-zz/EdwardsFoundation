using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Diagnostics;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class QuestionTests : DataAccessTestBase
    {
        [Test]
        public void Question_WhenCreated_ThereIsOneQuestionInTheTable()
        {
            var question = new Question() { QuestionCategory = "category", QuestionText = "here is the question text", QuestionType = "M" };
            db.Questions.InsertOnSubmit(question);
            db.SubmitChanges();
            Assert.AreEqual(1, db.Questions.Count());
        }
    }
}
