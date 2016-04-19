using System;
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
        NewsDao nDao;
        public ContentCtr()
        {
            nDao = new NewsDao();
        }
        public Boolean CreateNews(string title, User author, DateTime date, string content, Boolean isPublic, string picture)
        {
            Boolean succes = false;
            News n = new News(title, author, date, content, isPublic, picture);

            if (0 < nDao.CreateNews(n))
            {
                succes = true;
            }
            return succes;
        }

        Boolean createTraningSession(){
            return true;
        }

        Boolean createMatch(){
            return true;
        }

        List<Events> getEvents(DateTime rangeStart, DateTime rangeStop)
        {
            return new List<Events>();
        }

        List<News> getNews(DateTime rangeStart, DateTime rangeStop)
        {
            return new List<News>();
        }

        Boolean updateNews(){
            return true;
        }

        Boolean updateTrainingSession(){
            return true;
        }

        Boolean updateMatch(){
            return true;
        }
        
        Boolean updateContentInfo(){
            return true;
        }
    }
}
