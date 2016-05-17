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
            ts.Author.Id = 1;
            ts.Date = new DateTime(2016, 01, 01);
            ts.Content = "content";
            ts.IsPublic = true;
            ts.ContentType = "event";
            ts.StartTime = ts.Date = new DateTime(2016, 01, 01); ;
            ts.EndTime = ts.Date = new DateTime(2016, 01, 02); ;
            ts.EventType = "trainingSession";
            ts.Trainer = "Claus";

            //Assert.IsTrue(tsDao.CreateTrainingSession(ts));
            Assert.AreNotEqual(-1, tsDao.CreateTrainingSession(ts));
        }

        [TestMethod]
        public void FindTrainingSession()
        {
            Assert.IsFalse(tdao.FindTrainingSessions(new DateTime(2016, 01, 01)) == null);
        }
    }
}
