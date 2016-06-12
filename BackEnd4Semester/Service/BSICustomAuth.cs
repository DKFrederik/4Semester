using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.IdentityModel;
using System.IdentityModel.Selectors;
using Controller;

namespace Service
{
    class BSICustomAuth : UserNamePasswordValidator
    {

        public override void Validate(string userName, string password)
        {
            if (userName != null || password != null)
            {
                if (!new UserCtr().ValidateUser(userName, password))
                {
                    throw new IdentityValidationException("Not Allowed");
                }
            }
            else
                throw new ArgumentNullException();
        }
    }
}
