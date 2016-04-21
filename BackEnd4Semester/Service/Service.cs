using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using Controller;

namespace Service
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class Service : IService 
    {
        public Player FindPlayer(String email)
        {
            UserCtr uCtr = new UserCtr();
            return uCtr.FindPlayer(email);
        }

        public Boolean DeletePlayer(string email)
        {
            UserCtr uCtr = new UserCtr();
            return uCtr.DeletePlayer(email);
        }

        public Boolean CreatePlayer(string username, string password, string firstname, string lastname, string email, int admPri, string type, int number, int gamesplayed, int goals, int penalties)
        {
            UserCtr uCtr = new UserCtr();
            return uCtr.CreatePlayer(username, password, firstname, lastname, email, admPri, type, number, gamesplayed, goals, penalties);
        }

        public Boolean CreateUser(string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            UserCtr uCtr = new UserCtr();
            return uCtr.CreateUser(username, password, firstname, lastname, email, admPri, type);
        }

        public Boolean CreateNews(string title, User author, DateTime date, string content, Boolean isPublic, string picture)
        {
            ContentCtr cCtr = new ContentCtr();
            return cCtr.CreateNews(title, author, date, content, isPublic, picture);
        }

        public Boolean CreateMatch(string title, User author, DateTime date, string content, Boolean isPublic,
                    DateTime startTime, DateTime endTime, string opponent, int homegoals, int awaygoals, Team team)
        {
            ContentCtr cCtr = new ContentCtr();
            return cCtr.CreateMatch(title, author, date, content, isPublic, startTime, endTime, opponent, homegoals, awaygoals, team);
        }

        public Boolean DeleteUser(string email)
        {
            UserCtr uCtr = new UserCtr();
            return uCtr.DeleteUser(email);
        }

        public Boolean UpdateUser(string oldFn, string oldLn, string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            UserCtr uCtr = new UserCtr();
            return uCtr.UpdateUser(oldFn, oldLn, username, password, firstname, lastname, email, admPri, type);
        }

        public Boolean CreateTrainingSession(string title, string authorEmail, DateTime date, string content, Boolean isPublic,
            DateTime startTime, DateTime endTime, string trainer)
        {
            ContentCtr cCtr = new ContentCtr();
            return cCtr.CreateTrainingSession(title, authorEmail, date, content, isPublic, startTime, endTime, trainer);
        }

        public List<Match> FindMatches(DateTime date)
        {
            return new ContentCtr().FindMatches(date);
        }

        public List<TrainingSession> FindTrainingSessions(DateTime date)
        {
            return new ContentCtr().FindTrainingSessions(date);
        }

        public List<News> FindNews(DateTime date)
        {
            return new ContentCtr().FindNews(date);
        }


        public User FindUser(string email)
        {
            throw new NotImplementedException();
        }
    }
}
