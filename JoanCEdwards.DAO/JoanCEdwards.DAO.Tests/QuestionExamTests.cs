using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class QuestionExamTests
    {
        [Test]
        public void Exam_CanHaveOneQuestion()
        {
            var exam = new Exam() { Instructions = new string('a', 3500), Title = "here is the title" };
            var question = new Question() { QuestionCategory = "label", QuestionText = "here is the question text", QuestionType = "M" };
            var db = new ExamSystemDataContext();
            db.Exams.InsertOnSubmit(exam);
            db.Questions.InsertOnSubmit(question);
            exam.Questions.InsertOnSubmit(question);
            db.SubmitChanges();
            var actualExam = (from e in db.Exams
                              where e.ExamId == exam.ExamId
                              select e).FirstOrDefault();
            Assert.AreEqual(1, actualExam.Questions.Count);
        }
    }
}
