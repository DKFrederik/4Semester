using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using DAO;

namespace TestDAO
{
    [TestClass]
    public class TestTrainingSessionDAO
    {
        [TestMethod]
        public void CreateTrainingSession()
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
            ts.Trainer = "trainer";

            Assert.IsTrue(tsDao.CreateTrainingSession(ts));
        }
    }
}
