using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using DAO;

namespace TestDAO
{
    [TestClass]
    public class TestTeamDAO
    {

        private TeamDao tDao;

        [TestInitialize]
        public void Initialize()
        {
            tDao = new TeamDao();
        }

        [TestMethod]
        public void TestCreateTeam()
        {
            Assert.AreNotEqual(-1, tDao.CreateTeam(new Team("hold1", "serie1")));
        }

        [TestMethod]
        public void TestFindTeam()
        {
            Assert.IsNotNull(tDao.FindTeam("TeamForTestingFind", true).Players);
            Assert.AreEqual(tDao.FindTeam("TeamForTestingFind", true).Players.Count, 1);
        }
    }
}
