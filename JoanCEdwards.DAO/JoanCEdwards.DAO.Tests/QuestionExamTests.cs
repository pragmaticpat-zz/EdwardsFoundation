using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class QuestionExamTests : DataAccessTestBase
    {
        [Test]
        public void Exam_CanHaveOneQuestion()
        {
            var exam = new Exam() { Instructions = new string('a', 3500), Title = "here is the title" };
            var question = new Question() { QuestionCategory = "label", QuestionText = "here is the question text", QuestionType = "M" };
            db.Exams.InsertOnSubmit(exam);
            db.Questions.InsertOnSubmit(question);
            exam.ExamQuestions.Add(new ExamQuestion() { Exam = exam, Question = question, SortOrder = 1 });
            db.SubmitChanges();

            var actualExam = (from e in db.Exams
                              where e.ExamId == exam.ExamId
                              select e).First();
            Assert.AreEqual(1, actualExam.ExamQuestions.Count);
        }
    }
}
