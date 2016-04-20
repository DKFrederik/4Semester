using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using DAO;

namespace TestDAO
{
    [TestClass]
    public class TestTrainingSessionDAO
    {
        private TrainingSessionDao tdao;

        [TestInitialize]
        public void Initialize()
        {
            tdao = new TrainingSessionDao();
        }

        [TestMethod]
        public void TestCreateTrainingSession()
        {
            TrainingSessionDao tsDao = new TrainingSessionDao();
            TrainingSession ts = new TrainingSession();
            ts.Title = "test";
            ts.Author = new User { Email = "ContentTestUser" };
            ts.Date = new DateTime(2016, 01, 01);
            ts.Content = "content";
            ts.IsPublic = true;
            ts.StartTime = ts.Date = new DateTime(2016, 01, 01); ;
            ts.EndTime = ts.Date = new DateTime(2016, 01, 02); ;
            ts.Trainer = "Claus";

            //Assert.IsTrue(tsDao.CreateTrainingSession(ts));
            Assert.AreNotEqual(-1, tsDao.CreateTrainingSession(ts));
        }

        [TestMethod]
        public void FindTrainingSession()
        {
            Assert.IsFalse(tdao.FindTrainingSession("træning1" == null));
        }

        [TestMethod]
        public void DeleteTrainingSession()
        {
            string title = "træning1";

            Assert.IsTrue(0 == tdao.DeleteTrainingSession(title));
        }
    }
}
