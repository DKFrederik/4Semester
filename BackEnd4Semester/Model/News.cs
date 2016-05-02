using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class News : ContentInfo
    {
        public string Picture { get; set; }
        public News(string title, User author, DateTime date, string content, Boolean isPublic, string picture)
            : base(title, author, date, content, isPublic)
        {
            this.Picture = picture;
        }

        public News() { }
    }
}
