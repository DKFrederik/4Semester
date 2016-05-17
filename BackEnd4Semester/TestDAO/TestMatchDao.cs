using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using Model;

namespace TestDAO
{
    [TestClass]
    public class TestMatchDao
    {
        MatchDao mDao;

        [TestInitialize]
        public void Initialize()
        {
            mDao = new MatchDao();
        }

        [TestMethod]
        public void TestCreateMatch()
        {
            Match match = new Match()
            {
                Title = "testMatch",
                Author = new User(){Email = "ContentTestUser"},
                Date = new DateTime(2016, 04, 20),
                Content = "TestMatchContent",
                IsPublic = true,
                ContentType = "event",
                StartTime = new DateTime(2016, 04, 20, 14, 00, 00),
                EndTime = new DateTime(2016, 04, 20, 16, 30, 00),
                EventType = "match",
                Team = new Team() { Name = "MatchTestTeam" },
                Opponent = "TestOpponent",
                HomeGoal = 20,
                AwayGoal = 3      
            };

            Assert.IsTrue(0 < mDao.CreateMatch(match));
        }

        [TestMethod]
        public void TestFindMatches()
        {
            Assert.IsFalse(mDao.FindMatches(new DateTime(2016, 04, 20)).Count == 0);
        }
    }
}
