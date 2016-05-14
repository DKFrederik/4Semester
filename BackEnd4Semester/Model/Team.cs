using System.Collections.Generic;


namespace Model
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Player> Players { get; set; }

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