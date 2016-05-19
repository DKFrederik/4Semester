using System;

namespace Model
{
    public class News : ContentInfo
    {
        public string Picture { get; set; }
        public News(string title, User author, DateTime date, string content, Boolean isPublic, string contentType, string picture)
            : base(title, author, date, content, isPublic, contentType)
        {
            this.Picture = picture;
        }

        public News() { }
    }
}
