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
        private PlayerDao pdao;

        [TestInitialize]
        public void Initialize()
        {
            pdao = new PlayerDao();
        }

        [TestMethod]
        public void TestFindPlayer()
        {
            string email = "PlayerForTestingFind";
            Assert.IsNotNull(pdao.FindPlayer(email));
        }
        [TestMethod]
        public void TestCreatePlayer()
        {
            Assert.AreNotEqual(-1, pdao.CreatePlayer("PlayerForTestingCreate", "PlayerForTestingCreate", "PlayerForTestingCreate", "PlayerForTestingCreate", "PlayerForTestingCreate", -1, "PlayerForTestingCreate", 0, 0, 0, 0));
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

            Assert.AreNotEqual(-1, pdao.UpdatePlayer(player, oldFirstname, oldLastname));
        }

        [TestMethod]
        public void TestDeletePlayer()
        {
            string email = "PlayerForTestingDelete";

            Assert.AreNotEqual(-1, pdao.DeletePlayer(email));
        }
    }
}
