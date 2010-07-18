using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class ExamTests : DataAccessTestBase
    {
        [Test]
        public void Exam_WhenCreated_ThereIsOneExamInTheTable()
        {
            var exam = new Exam() { Instructions = new string('a', 3500), Title = "here is the title" };
            db.Exams.InsertOnSubmit(exam);
            db.SubmitChanges();
            Assert.AreEqual(1, db.Exams.Count());
        }

        [Test]
        public void Exam_WhenDeleted_StatusIsFalse()
        {
            Exam exam = new Exam() { Instructions = new string('a', 3500), Title = "here is the title" };
            db.Exams.InsertOnSubmit(exam);
            db.SubmitChanges();
            db.DeleteExam(exam.ExamId);
            Assert.AreEqual(false, exam.Status);
        }
    }
}
