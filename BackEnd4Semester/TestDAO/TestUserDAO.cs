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
            string email = "testFindUser";
            Assert.IsNotNull(udao.FindUser(email));
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
                Type = "User",
                AdminPrivilege = -1
            };


            Assert.AreNotEqual(-1, udao.CreateUser(user));
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            string oldFirstname = "testUpdateUser";
            string oldLastname = "testUpdateUser";

            User user = new User
            {
                UserName = "TestUpdateUser23151",
                Password = "TestUpdateUser23151",
                FirstName = "TestUpdateUser23151",
                LastName = "TestUpdateUser23151",
                Email = "TestUpdateUser23151@gmail.com",
                AdminPrivilege = -1,
                Type = "user"
            };

            Assert.AreNotEqual(-1, udao.UpdateUser(user, oldFirstname, oldLastname));
        }

        [TestMethod]
        public void TestWrongInfoUpdateUser()
        {
            string oldFirstname = "NonExistingBumOfAUserLoser";
            string oldLastname = "NonExistingBumOfAUserLoser";

            User user = new User
            {
                UserName = "TestUpdateUser23151",
                Password = "TestUpdateUser23151",
                FirstName = "TestUpdateUser23151",
                LastName = "TestUpdateUser23151",
                Email = "TestUpdateUser23151@gmail.com",
                AdminPrivilege = -1,
                Type = "user"
            };

            Assert.AreEqual(0, udao.UpdateUser(user, oldFirstname, oldLastname));
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            string email = "DeleteUserTest";

            Assert.IsTrue(0 < udao.DeleteUser(email));
        }
    }
}
