using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class ContentInfo
    {
        public string Title { get; set; }
        public Boolean IsPublic { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
