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
    }
}
