using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using Controller;

namespace Service
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class Service : IService 
    {
        public Player getPlayer(String email)
        {
            return new Player();
        }

        public Boolean CreateUser(string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            UserCtr uCtr = new UserCtr();
            return uCtr.CreateUser(username, password, firstname, lastname, email, admPri, type);
        }

        public Boolean CreatePlayer(string username, string password, string firstname, string lastname, string email, int adminPrivilege, string type, int number, int gamesPlayed, int goals, int penalties)
        {
            PlayerCtr pCtr = new PlayerCtr();
            return pCtr.CreatePlayer(username, password, firstname, lastname, email, adminPrivilege, type, number, gamesPlayed, goals, penalties);
        }
    }
}
