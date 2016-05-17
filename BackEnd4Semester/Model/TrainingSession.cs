using System;

namespace Model
{
    public class TrainingSession : Events
    {
        public string Trainer { get; set; }

        public TrainingSession(string title, User author, DateTime date, string content, Boolean isPublic, string contentType, DateTime startTime, DateTime endTime, string eventType, string trainer)
            : base(title, author, date, content, isPublic, contentType, startTime, endTime, eventType)
        {
            Trainer = trainer; 
        }

        public TrainingSession()
        {

        }
    }
}
