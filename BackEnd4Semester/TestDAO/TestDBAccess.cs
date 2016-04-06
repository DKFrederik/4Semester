using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;

namespace DataAccessLayerTest
{
    [TestClass]
    public class TestDBAccess
    {
        [TestMethod]
        public void ConnectionTest()
        {
            DBAccess dba = new DBAccess();
            Assert.IsTrue(dba.Open());
            dba.Close();
        }
    }
}
