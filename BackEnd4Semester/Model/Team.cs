using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;


namespace Model
{
    public class Team
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Team(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public Team()
        {

        }
    }

}