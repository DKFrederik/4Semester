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
            string oldFirstname = "testUpdatePlayer";
            string oldLastname = "testUpdatePlayer";
            string un = "UpdatedPlayer";
            string pw = "UpdatedPlayer";
            string fn = "UpdatedPlayer";
            string ln = "UpdatedPlayer";
            string email = "UpdatedPlayer";
            string type = "UpdatePlayer";
            int ap = -1;
            int no = 999;
            int gp = 999;
            int g = 999;
            int p = 999;

            Assert.AreNotEqual(-1, pdao.UpdatePlayer(un, pw, fn, ln, email, type, ap, no, gp, g, p, oldFirstname, oldLastname));
        }

        [TestMethod]
        public void TestDeletePlayer()
        {
            string email = "PlayerForTestingDelete";

            Assert.AreNotEqual(-1, pdao.DeletePlayer(email));
        }
    }
}
