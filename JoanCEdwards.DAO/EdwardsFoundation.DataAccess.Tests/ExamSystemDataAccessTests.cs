using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JoanCEdwards.DAO;

namespace EdwardsFoundation.DataAccess.Tests
{
    public class ExamSystemDataAccessTests
    {
        [SetUp]
        public void Setup()
        {
            Teardown();
        }

        [Test]
        public void CreateUser_isNotNull()
        {
            ExamSystemDataAccess da = new ExamSystemDataAccess();
            IUser actual_user = da.CreateUser("g", "firstname", "lastname", 'S', "5", "xyz");
            Assert.IsNotNull(actual_user);
        }
        [TearDown]
        public void Teardown()
        {
            ExamSystemDataContext db = new ExamSystemDataContext();
            db.ExecuteCommand("truncate table dbo.UserProfile");
            db.SubmitChanges();
        }

    }
}
