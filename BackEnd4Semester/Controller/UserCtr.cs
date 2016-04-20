﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Model;

namespace Controller
{
    public class UserCtr
    {
        private UserDAO udao;

        public UserCtr()
        {
            udao = new UserDAO();
        }

        public Boolean CreateUser(string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            Boolean success = false;
            User u = new User(username, password, firstname, lastname, email, admPri, type);

            if(udao.CreateUser(u) != -1)
            {
                success = true;
            }

            return success;
        }

        public Boolean DeleteUser(string email)
        {
            Boolean success = false;
            if(udao.DeleteUser(email) != 0)
            {
                success = true;
            }

            return success;
        }

        public User FindUser(string email)
        {
            return udao.FindUser(email);
        }

        public Boolean UpdateUser(string oldFn, string oldLn, string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            Boolean success = false;
            User u = new User(username, password, firstname, lastname, email, admPri, type);
            if(udao.UpdateUser(u, oldFn, oldLn) > 0)
            {
                success = true;
            }

            return success;
        }
    }
}
