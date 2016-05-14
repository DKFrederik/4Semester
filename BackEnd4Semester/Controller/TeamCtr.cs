using DAO;
using Model;
using System;

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

        public Team GetTeam(string name, Boolean retrieveAssoc)
        {
            return tDao.FindTeam(name, retrieveAssoc);
        }

        public Team GetTeam(int id, Boolean retrieveAssoc)
        {
            return tDao.FindTeam(id, retrieveAssoc);
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
