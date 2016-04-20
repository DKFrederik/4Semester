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

        [TestMethod]
        public void TestCreateTeam()
        {
            Assert.AreNotEqual(-1, tDao.CreateTeam(new Team("hold1", "serie1")));
        }
    }
}
