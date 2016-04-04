using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Match : Event
    {
        public string Opponent { get; set; }
        public string MatchScore { get; set; }
    }
}
