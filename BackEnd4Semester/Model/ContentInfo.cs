using System;

namespace Model
{
    public abstract class ContentInfo
    {
        public string Title { get; set; }
        public User Author { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public Boolean IsPublic { get; set; }
        public string ContentType { get; set; }

        protected ContentInfo(string title, User author, DateTime date, string content, Boolean isPublic, string contentType)
        { 
            Title = title;
            Author = author;
            Date = date;
            Content = content;
            IsPublic = isPublic;
            ContentType = contentType;
        }

        protected ContentInfo() { }
    }
}
