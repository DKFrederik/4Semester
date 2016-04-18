using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDAO
{
    [TestClass]
    public class TestPlayerDAO
    {
        private PlayerDao pDao;

        [TestInitialize]
        public void Initialize()
        {
            pDao = new PlayerDao();
        }

        [TestMethod]
        public void TestFindPlayer()
        {
            string firstname = "testFindPlayer";
            string lastname = "testFindPlayer";
            Assert.IsNotNull(pDao.FindPlayer(firstname, lastname));
        }
        [TestMethod]
        public void TestCreatePlayer()
        {
            Player player = new Player
            {
                UserName = "TestPlayer",
                Password = "TestPlayer",
                FirstName = "TestPlayer",
                LastName = "TestPlayer",
                Email = "TestPlayer",
                AdminPrivilege = -1,
                Number = 0,
                GamesPlayed = 0,
                Goals = 0,
                Penalties = 0
            };


            Assert.AreNotEqual(-1, (player));
        }

        [TestMethod]
        public void TestUpdatePlayer()
        {
            string oldFirstname = "TestPlayer";
            string oldLastname = "TestPlayer";

            Player player = new Player
            {
                UserName = "TestUpdatePlayer",
                Password = "TestUpdatePlayer",
                FirstName = "TestUpdatePlayer",
                LastName = "TestUpdatePlayer",
                Email = "TestUpdatePlayer",
                AdminPrivilege = -1,
                Number = 0,
                GamesPlayed = 0,
                Goals = 0,
                Penalties = 0
            };

            Assert.AreNotEqual(-1, pDao.UpdatePlayer(player, oldFirstname, oldLastname));
        }

        [TestMethod]
        public void TestDeletePlayer()
        {
            string email = "TestEmail";

            Assert.AreNotEqual(-1, pDao.DeletePlayer(email));
        }
    }
}
