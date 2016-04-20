using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    public class TrainingSession : Events
    {
        public string Trainer { get; set; }

        public TrainingSession()
        {

        }

        public TrainingSession(string title, string author, DateTime date, string content, bool isPublic, DateTime startTime, DateTime endTime, string trainer)
        {
            Title = title;
            Author = author;
            Date = date;
            Content = content;
            IsPublic = isPublic;
            StartTime = startTime;
            EndTime = endTime;
            Trainer = trainer; 
        }
    }
}
