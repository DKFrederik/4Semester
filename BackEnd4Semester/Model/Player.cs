using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player : User
    {
        public int Number { get; set; }
        public int GamesPlayed { get; set; }
        public int Goals { get; set; }
        public int Penalties { get; set; }

        public Player(int number, int gamesplayed, int goals, int penalties, string username, string password, string firstname, string lastname, string email, int admPri, string type)
            : base(username, password, firstname, lastname, email, admPri, type)
        {
            Number = number;
            GamesPlayed = gamesplayed;
            Goals = goals;
            Penalties = penalties;
        }

        public Player()
        {

        }
    }
}
