using DAO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class TeamCtr
    {
        TeamDao tDao;

        public TeamCtr()
        {
            tDao = new TeamDao();
        }

        public bool CreateTeam(string name, string type)
        {
            Boolean succes = false;
            Team t = new Team(name, type);

            if(0 < tDao.CreateTeam(t))
            {
                succes = true;
            }
            return succes;
        }

        public Team GetTeam(string name)
        {
            return tDao.FindTeam(name);
        }

        public bool UpdateTeam()
        {
            return false;
        }

        public bool DeleteTeam()
        {
            return false;

        }
    }
}
