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
            ctDAO = new ContentInfoDAO();
        }

        [TestMethod]
        public void TestCreateContentInfo()
        {
            Assert.AreNotEqual(-1, ctDAO.CreateContentInfo("testString", new User() { Email = "ContentTestUser" }, DateTime.Now, "testContent", true, "news"));
        }
    }
}
