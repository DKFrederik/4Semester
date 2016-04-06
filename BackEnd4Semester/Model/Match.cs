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
        public string Opponent { get; set; }
        public string MatchScore { get; set; }
    }
}
