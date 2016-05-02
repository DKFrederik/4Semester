using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using Model;

namespace TestDAO
{
    [TestClass]
    public class TestEventsDao
    {
        EventsDao eDao;

        [TestInitialize]
        public void Initialize()
        {
            eDao = new EventsDao();
        }

        [TestMethod]
        public void TestCreateEvent()
        {
            DateTime start = new DateTime(2016,04,20,14,00,00);
            DateTime end = new DateTime(2016,04,20,16,30,00);
            
            Assert.AreNotEqual(-1, eDao.CreateEvent("testEvent", new User(){Email = "ContentTestUser"}, new DateTime(2016,04,20), "testEvent", 
                                true, start, end, "trainingSession"));
        }
    }
}
