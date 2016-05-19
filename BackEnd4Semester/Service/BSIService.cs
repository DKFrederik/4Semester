using System;
using System.Collections.Generic;
using System.ServiceModel;
using Model;
using Controller;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;

namespace Service
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class BSIService : IBSIService, ISecureBSIService
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
            string hostID = WindowsIdentity.GetCurrent().Name;
            string primaryIdentity = ServiceSecurityContext.Current.PrimaryIdentity.AuthenticationType;
            string windowsId = ServiceSecurityContext.Current.WindowsIdentity.Name;
            string threadId = Thread.CurrentPrincipal.Identity.Name;
            bool isAdmin = Thread.CurrentPrincipal.IsInRole("Admin");
            return new UserCtr().FindUser(email);
        }

        public Boolean UpdateUser(string oldFn, string oldLn, string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            return new UserCtr().UpdateUser(oldFn, oldLn, username, password, firstname, lastname, email, admPri, type);
        }

        public Boolean CreateTrainingSession(string title, string authorEmail, DateTime date, string content, bool isPublic, string contentType, DateTime startTime, DateTime endTime, string eventType, string trainer)
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

        public Team FindTeam(string name, Boolean retrieveAssoc)
        {
            return new TeamCtr().GetTeam(name, retrieveAssoc);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public Player FindPlayerSecure(String email)
        {
            return new UserCtr().FindPlayer(email);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public Boolean DeletePlayerSecure(string email)
        {
            return new UserCtr().DeletePlayer(email);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public Boolean CreatePlayerSecure(string username, string password, string firstname, string lastname, string email, int admPri, string type, int number, int gamesplayed, int goals, int penalties)
        {
            return new UserCtr().CreatePlayer(username, password, firstname, lastname, email, admPri, type, number, gamesplayed, goals, penalties);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public Boolean CreateUserSecure(string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            return new UserCtr().CreateUser(username, password, firstname, lastname, email, admPri, type);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public Boolean CreateNewsSecure(string title, User author, DateTime date, string content, Boolean isPublic, string contentType, string picture)
        {
            ContentCtr cCtr = new ContentCtr();
            return cCtr.CreateNews(title, author, date, content, isPublic, contentType, picture);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public Boolean CreateMatchSecure(string title, User author, DateTime date, string content, Boolean isPublic, string contentType,
            DateTime startTime, DateTime endTime, string eventType, string opponent, int homegoals, int awaygoals, Team team)
        {
            ContentCtr cCtr = new ContentCtr();
            return cCtr.CreateMatch(title, author, date, content, isPublic, contentType, startTime, endTime, eventType, opponent, homegoals, awaygoals, team);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public Boolean DeleteUserSecure(string email)
        {
            return new UserCtr().DeleteUser(email);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "2")]
        public User FindUserSecure(string email)
        {
            //string hostID = WindowsIdentity.GetCurrent().Name;
            //string primaryIdentity = ServiceSecurityContext.Current.PrimaryIdentity.AuthenticationType;
            //string windowsId = ServiceSecurityContext.Current.WindowsIdentity.Name;
            //string threadId = Thread.CurrentPrincipal.Identity.Name;
            //bool isAdmin = Thread.CurrentPrincipal.IsInRole("Admin");
            return new UserCtr().FindUser(email);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public Boolean UpdateUserSecure(string oldFn, string oldLn, string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            return new UserCtr().UpdateUser(oldFn, oldLn, username, password, firstname, lastname, email, admPri, type);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public Boolean CreateTrainingSessionSecure(string title, string authorEmail, DateTime date, string content, bool isPublic, string contentType, DateTime startTime, DateTime endTime, string eventType, string trainer)
        {
            ContentCtr cCtr = new ContentCtr();
            return cCtr.CreateTrainingSession(title, authorEmail, date, content, isPublic, contentType, startTime, endTime, eventType, trainer);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public List<Match> FindMatchesSecure(DateTime date)
        {
            return new ContentCtr().FindMatches(date);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public List<TrainingSession> FindTrainingSessionsSecure(DateTime date)
        {
            return new ContentCtr().FindTrainingSessions(date);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public List<News> FindNewsSecure(DateTime date)
        {
            return new ContentCtr().FindNews(date);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public Team FindTeamWithIdSecure(int id, Boolean retrieveAssoc)
        {
            return new TeamCtr().GetTeam(id, retrieveAssoc);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "1")]
        public Team FindTeamSecure(string name, Boolean retrieveAssoc)
        {
            return new TeamCtr().GetTeam(name, retrieveAssoc);
        }

        public bool ValidateUser(string username, string password)
        {
            return new UserCtr().ValidateUser(username, password);
        }

        public bool ValidateUserSecure(string username, string password)
        {
            return new UserCtr().ValidateUser(username, password);
        }

        public int GetRolesForUser(string username)
        {
            return new UserCtr().GetUserRole(username);
        }

        public int GetRolesForUserSecure(string username)
        {
            return new UserCtr().GetUserRole(username);
        }
    }
}
