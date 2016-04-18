using DAO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class PlayerCtr
    {
        private PlayerDao pdao;

        public PlayerCtr()
        {
            pdao = new PlayerDao();
        }

        public Boolean CreatePlayer(string username, string password, string firstname, string lastname, string email, int admPri, 
            string type, int number, int gamesPlayed, int goals, int penalties)
        {
            Boolean success = false;
            Player p = new Player(username, password, firstname, lastname, email, admPri, type, number, gamesPlayed, goals, penalties);

            if (pdao.CreatePlayer(p) != -1)
            {
                success = true;
            }

            return success;
        }
    }
}
