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
    public class TestUserDAO
    {
        private UserDAO udao;

        [TestInitialize]
        public void Initialize()
        {
            udao = new UserDAO();
        }

        [TestMethod]
        public void TestFindUser()
        {
            string firstname = "testFindUser";
            string lastname = "testFindUser";
            Assert.IsNotNull(udao.FindUser(firstname, lastname));
        }
        [TestMethod]
        public void TestCreateUser()
        {
            User user = new User
            {
                UserName = "TestUser",
                Password = "TestUser",
                FirstName = "TestUser",
                LastName = "TestUser",
                Email = "TestUser",
                AdminPrivilege = -1
            };


            Assert.AreNotEqual(-1, udao.CreateUser(user));
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            string oldFirstname = "TestUser";
            string oldLastname = "TestUser";

            User user = new User
            {
                UserName = "TestUpdateUser",
                Password = "TestUpdateUser",
                FirstName = "TestUpdateUser",
                LastName = "TestUpdateUser",
                Email = "TestUpdateUser",
                AdminPrivilege = -1
            };

            Assert.AreNotEqual(-1, udao.UpdateUser(user, oldFirstname, oldLastname));
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            string email = "TestEmail";

            Assert.AreNotEqual(-1, udao.DeleteUser(email));
        }
    }
}
