using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AdminPrivilege { get; set; }
        public string Type { get; set; }

        public User(int id, string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            Id = id;
            UserName = username;
            Password = password;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            AdminPrivilege = admPri;
            Type = type;
        }

        public User(string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            UserName = username;
            Password = password;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            AdminPrivilege = admPri;
            Type = type;
        }
        
        public User()
        {

        }
    }

}
