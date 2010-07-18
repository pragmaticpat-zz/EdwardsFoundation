using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public class ChoiceTests : DataAccessTestBase
    {
        [Test]
        public void Choice_WhenCreated_OneChoiceInTheTable()
        {
            var choice = new Choice() { Label = "label", Value  = 10};
            db.Choices.InsertOnSubmit(choice);
            db.SubmitChanges();
            Assert.AreEqual(1, db.Choices.Count());
        }
    }
}
