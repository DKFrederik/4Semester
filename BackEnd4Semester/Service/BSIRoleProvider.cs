﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Controller;

namespace Service
{
    class BSIRoleProvider : RoleProvider 
    {
        public override string[] GetRolesForUser(string username)
        {
            return new string[] { new UserCtr().GetUserRole(username).ToString() };
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            int role = new UserCtr().GetUserRole(username);
            return Convert.ToInt32(roleName) <= role;

            //if (roleName == "Admin")
            //    return (role >= 0);
            //else if (roleName.Equals("Member"))
            //    return (role == 0);
            //else
            //    return false;

            //if (GetRolesForUser(username).Contains(roleName.ToString()))
            //    return true;
            //else
            //    return false;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}