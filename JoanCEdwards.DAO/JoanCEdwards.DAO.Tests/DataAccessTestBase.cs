using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace JoanCEdwards.DAO.Tests
{
    [TestFixture]
    public abstract class DataAccessTestBase
    {
        protected ExamSystemDataContext db;

        [SetUp]
        public void Setup()
        {
            db = new ExamSystemDataContext();
            db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
        }

        [TearDown]
        public void Teardown()
        {
            db.Transaction.Rollback();
        }
    }
}
