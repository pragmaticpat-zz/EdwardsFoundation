using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class ChoiceTests
    {
        ExamSystemDataContext db;

        [SetUp]
        public void Setup()
        {
            db = new ExamSystemDataContext();
            Teardown();
        }

        [Test]
        public void Choice_WhenCreated_HasId()
        {
            var choice = new Choice() { Label = "label", Value  = 10};
            db.Choices.InsertOnSubmit(choice);
            db.SubmitChanges();
            Assert.AreEqual(1, choice.ChoiceId);
        }

        [TearDown]
        public void Teardown()
        {
            db.ExecuteCommand("truncate table dbo.Choice");
        }
    }
}
