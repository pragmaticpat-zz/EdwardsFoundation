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
<<<<<<< HEAD
            var exam = new Exam() { Instructions = new string('a', 3500), Title = "here is the title", Value = 100 };
=======
            CreateDefaultExam();
            Assert.AreEqual(1, db.Exams.Count());
        }

        [Test]
        public void Exam_TwoExamsHaveTheSameName_BothCanBeStored()
        {
            CreateDefaultExam();
            CreateDefaultExam();
            Assert.AreEqual(2, db.Exams.Count());
        }

        private void CreateDefaultExam()
        {
            var exam = new Exam() { Instructions = new string('a', 3500), Title = "here is the title" };
>>>>>>> c1cf1ab570cae6af2ee1923b7b68c9ee7ab08501
            db.Exams.InsertOnSubmit(exam);
            db.SubmitChanges();
        }

        [Test]
        public void Exam_WhenDeleted_StatusIsFalse()
        {
            Exam exam = new Exam() { Instructions = new string('a', 3500), Title = "here is the title", Value = 100 };
            db.Exams.InsertOnSubmit(exam);
            db.SubmitChanges();
            db.DeleteExam(exam.ExamId);
            Assert.AreEqual(false, exam.Status);
        }
    }
}
