using System;
using DAO;
using Model;

namespace Controller
{
    public class UserCtr
    {
        private UserDAO udao;
        private PlayerDao pDao;

        public UserCtr()
        {
            udao = new UserDAO();
            pDao = new PlayerDao();
        }

        public Boolean CreateUser(string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            Boolean success = false;

            if(udao.CreateUser(username, password, firstname, lastname, email, admPri, type) != -1)
            {
                success = true;
            }

            return success;
        }

        public Boolean CreatePlayer(string username, string password, string firstname, string lastname, string email, int admPri, string type, int number, int gamesplayed, int goals, int penalties)
        {
            bool success = false;

            if (pDao.CreatePlayer(username, password, firstname, lastname, email, admPri, type, number, gamesplayed, goals, penalties) > 0)
            {
                success = true;
            }

            return success;

        }

        public bool DeletePlayer(string email)
        {
            bool suc = false;

            if (pDao.DeletePlayer(email) > 0)
            {
                suc = true;
            }

            return suc;
        }

        public Boolean DeleteUser(string email)
        {
            Boolean success = false;
            if(udao.DeleteUser(email) != 0)
            {
                success = true;
            }

            return success;
        }

        public User FindUser(string email)
        {
            return udao.FindUser(email);
        }

        public Boolean UpdateUser(string oldFn, string oldLn, string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            Boolean success = false;
            User u = new User(username, password, firstname, lastname, email, admPri, type);
            if(udao.UpdateUser(u, oldFn, oldLn) > 0)
            {
                success = true;
            }

            return success;
        }

        public Player FindPlayer(string email)
        {
            return pDao.FindPlayer(email);
        }

        public bool ValidateUser(string username, string password)
        {
            return new UserDAO().ValidateUser(username, password);
        }
    }
}
