using System;

namespace Model
{
    public abstract class Events : ContentInfo
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EventType { get; set; }

        protected Events(string title, User author, DateTime date, string content, Boolean isPublic, string contentType, DateTime startTime, DateTime endTime, string eventType)
            : base(title, author, date, content, isPublic, contentType)
        {
            StartTime = startTime;
            EndTime = endTime;
            EventType = eventType;
        }

        protected Events()
        {

        }
    }
}
