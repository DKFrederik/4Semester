﻿using Controller;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        //Not Android
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


        public Team FindTeam(int id, Boolean retrieveAssoc)
        {

            return new TeamCtr().GetTeam(id, retrieveAssoc);
        }

        public Team FindTeam(string name, Boolean retrieveAssoc)
        {
            return new TeamCtr().GetTeam(name, retrieveAssoc);
        }
    }
}