using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class Match : Events
    {
        public Team Team { get; set; }
        public string Opponent { get; set; }
        public int HomeGoal { get; set; }
        public int AwayGoal { get; set; }
    }
}
