using System;

namespace Model
{
    public class Match : Events
    {
        public Team Team { get; set; }
        public string Opponent { get; set; }
        public int HomeGoal { get; set; }
        public int AwayGoal { get; set; }

        public Match(string title, User author, DateTime date, string content, Boolean isPublic, string contentType, DateTime startTime, DateTime endTime, string eventType, Team team, string opponent, int homeGoal, int awayGoal)
            : base(title, author, date, content, isPublic, contentType, startTime, endTime, eventType)
        {
            Team = team;
            Opponent = opponent;
            HomeGoal = homeGoal;
            AwayGoal = AwayGoal;
        }

        public Match()
        {

        }
    }
}
