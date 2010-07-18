using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class QuestionAnswerTests : DataAccessTestBase
    {

        [Test]
        public void Question_HasOneAnswer_PerUser()
        {
            var exam = new Exam() { Instructions = new string('a', 3500), Title = "here is the title" };
            var question = new Question() { QuestionCategory = "label", QuestionText = "here is the question text", QuestionType = "M" };
            db.Exams.InsertOnSubmit(exam);
            db.Questions.InsertOnSubmit(question);
            var expectedProfile = new UserProfile() { EmailAddress = "email", FirstName = "name", LastName = "lname", GradeLevel = "5", UserType = 'S', Password = new string('p', 300) };
            db.UserProfiles.InsertOnSubmit(expectedProfile);
            exam.ExamQuestions.Add(new ExamQuestion() { Exam = exam, Question = question, SortOrder = 1 });
            question.QuestionAnswers.Add(new QuestionAnswer() { Question = question, Exam = exam, UserProfile = expectedProfile, Answer = "answer" });
            db.SubmitChanges();

            var actualQuestion = (from e in db.Questions
                              where e.QuestionId == question.QuestionId
                              select e).First();
            Assert.AreEqual(1, actualQuestion.QuestionAnswers.Count);

        }
    }
}
