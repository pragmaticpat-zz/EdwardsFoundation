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
        public void Choice_WhenCreated_HasId()
        {
            var choice = new Choice() { Label = "label", Value  = 10};
            db.Choices.InsertOnSubmit(choice);
            db.SubmitChanges();
            Assert.Greater(choice.ChoiceId, 0);
        }
    }
}
