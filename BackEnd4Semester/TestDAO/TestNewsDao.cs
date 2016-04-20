using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using Model;

namespace TestDAO
{
    [TestClass]
    public class TestNewsDao
    {
        NewsDao newsDao;

        [TestInitialize]
        public void Initialize()
        {
            newsDao = new NewsDao();
        }

        [TestMethod]
        public void TestCreateNews()
        {
            News testNews = new News()
            {
                Author = new User() { Email = "ContentTestUser" },
                Content = "testNews",
                Date = DateTime.Now,
                IsPublic = true,
                Picture = "EtBilledeafCarsten.url",
                Title = "testNews"
            };
            Assert.IsTrue(0 < newsDao.CreateNews(testNews));
        }
    }
}
