﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;


namespace Controller
{
    public class ContentCtr
    {
        UserCtr uCtr;
        public ContentCtr()
        {
            uCtr = new UserCtr();
        }
        public Boolean CreateNews(string title, User author, DateTime date, string content, Boolean isPublic, string picture)
        {
            Boolean succes = false;
            News n = new News(title, author, date, content, isPublic, picture);

            if (0 < new NewsDao().CreateNews(n))
            {
                succes = true;
            }
            return succes;
        }

        public Boolean CreateTrainingSession(string title, string authorEmail, DateTime date, string content, bool isPulic, DateTime startTime, DateTime endTime, string trainer){
            User author = uCtr.FindUser(authorEmail);
            TrainingSession newTs = new TrainingSession(title, author, date, content, isPulic, startTime, endTime, trainer);
            return new TrainingSessionDao().CreateTrainingSession(newTs);
        }

        public List<TrainingSession> FindTrainingSessions(DateTime date)
        {
            return new TrainingSessionDao().FindTrainingSessions(date);
        }

        public bool UpdateTrainingSession(string oldTitle, string newTitle, string newAuthor, DateTime newDate, string newContent, bool newIsPulic, DateTime newStartTime, DateTime newEndTime, string newTrainer)
        {
            return true;
        }

        public Boolean CreateMatch(string title, User author, DateTime date, string content, Boolean isPublic,
            DateTime startTime, DateTime endTime, string opponent, int homegoals, int awaygoals, Team team)
        {

            Boolean succes = false;
            MatchDao mDao = new MatchDao();
            Match m = new Match()
            {
                Title = title,
                Author = author,
                Date = date,
                Content = content,
                IsPublic = isPublic,
                StartTime = startTime,
                EndTime = endTime,
                Opponent = opponent,
                HomeGoal = homegoals,
                AwayGoal = awaygoals,
                Team = team
            };

            if (0 < mDao.CreateMatch(m))
            {
                succes = true;
            }
            return succes;
        }
        public bool DeleteTrainingSession(string title)
        {
            Boolean success = false;
            int rc = new TrainingSessionDao().DeleteTrainingSession(title);
            if(rc > 0)
            {
                success = true;
            }
            return success;
        }

        public List<News> FindNews(DateTime date)
        {
            return new NewsDao().FindNews(date);
        }

        public List<Match> FindMatches(DateTime date)
        {
            return new MatchDao().FindMatches(date);
        }

        public Boolean updateNews()
        {
            return true;
        }


        public Boolean updateMatch()
        {
            return true;
        }

        public Boolean updateContentInfo()
        {
            return true;
        }
    }
}
