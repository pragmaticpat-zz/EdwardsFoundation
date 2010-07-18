using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class ExamTests
    {
        [Test]
        public void Exam_WhenCreated_HasAnID()
        {
            var db = new ExamSystemDataContext();
            var exam = new Exam() { Instructions = new string('a', 3500), Title = "here is the title" };
            db.Exams.InsertOnSubmit(exam);
            db.SubmitChanges();
            var actualExamId = db.Exams.First<Exam>().ExamId;
            Assert.AreEqual(1, db.Exams.Count());
        }

        [Test]
        public void Exam_WhenDeleted_StatusIsFalse()
        {
            ExamSystemDataContext db = new ExamSystemDataContext();
            Exam exam = new Exam() { Instructions = new string('a', 3500), Title = "here is the title" };
            db.Exams.InsertOnSubmit(exam);
            db.SubmitChanges();
            db.DeleteExam(exam.ExamId);
            Assert.AreEqual(false, exam.Status);
        }
    }
}
