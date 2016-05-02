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
                Date = new DateTime(2016, 04, 20),
                IsPublic = true,
                Picture = "EtBilledeafCarsten.url",
                Title = "testNews"
            };
            Assert.IsTrue(0 < newsDao.CreateNews(testNews));
        }

        [TestMethod]
        public void TestFindNews()
        {
            Assert.IsFalse(newsDao.FindNews(new DateTime(2016, 04, 20)).Count == 0);
        }
    }
}
