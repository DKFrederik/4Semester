using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using Model;

namespace TestDAO
{
    [TestClass]
    public class TestContentInfoDAO
    {
        ContentInfoDAO ctDAO;

        [TestInitialize]
        public void Initialize()
        {
            ctDAO = new UserDAO();
        }

        [TestMethod]
        public void TestCreateContentInfo()
        {
            Assert.AreNotEqual(-1, ctDAO.CreateContentInfo("testString", new User(){Email = "test@email.com"}, DateTime.Now, "testContent", true, "news"));
        }
    }
}
