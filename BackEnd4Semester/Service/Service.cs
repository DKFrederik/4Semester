using System;
using System.Collections.Generic;
using System.ServiceModel;
using Model;
using Controller;

namespace Service
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class Service : IService 
    {
        public Player FindPlayer(String email)
        {
            return new UserCtr().FindPlayer(email);
        }

        public Boolean DeletePlayer(string email)
        {
            return new UserCtr().DeletePlayer(email);
        }

        public Boolean CreatePlayer(string username, string password, string firstname, string lastname, string email, int admPri, string type, int number, int gamesplayed, int goals, int penalties)
        {
            return new UserCtr().CreatePlayer(username, password, firstname, lastname, email, admPri, type, number, gamesplayed, goals, penalties);
        }

        public Boolean CreateUser(string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            return new UserCtr().CreateUser(username, password, firstname, lastname, email, admPri, type);
        }

        public Boolean CreateNews(string title, User author, DateTime date, string content, Boolean isPublic, string contentType, string picture)
        {
            ContentCtr cCtr = new ContentCtr();
            return cCtr.CreateNews(title, author, date, content, isPublic, contentType, picture);
        }

        public Boolean CreateMatch(string title, User author, DateTime date, string content, Boolean isPublic, string contentType,
                    DateTime startTime, DateTime endTime, string eventType, string opponent, int homegoals, int awaygoals, Team team)
        {
            ContentCtr cCtr = new ContentCtr();
            return cCtr.CreateMatch(title, author, date, content, isPublic, contentType, startTime, endTime, eventType, opponent, homegoals, awaygoals, team);
        }

        public Boolean DeleteUser(string email)
        {
            return new UserCtr().DeleteUser(email);
        }

        public User FindUser(string email)
        {
            return new UserCtr().FindUser(email);
        }

        public Boolean UpdateUser(string oldFn, string oldLn, string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            return new UserCtr().UpdateUser(oldFn, oldLn, username, password, firstname, lastname, email, admPri, type);
        }

        public Boolean CreateTrainingSession(string title, string authorEmail, DateTime date, string content, Boolean isPublic, string contentType,
            DateTime startTime, DateTime endTime, string eventType, string trainer)
        {
            ContentCtr cCtr = new ContentCtr();
            return cCtr.CreateTrainingSession(title, authorEmail, date, content, isPublic, contentType, startTime, endTime, eventType, trainer);
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


        public Team FindTeamWithId(int id, Boolean retrieveAssoc)
        {

            return new TeamCtr().GetTeam(id, retrieveAssoc);
        }

        public Team FindTeamWithName(string name, Boolean retrieveAssoc)
        {
            return new TeamCtr().GetTeam(name, retrieveAssoc);
        }
    }
}
