using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Controller
{
    class ContentCtr
    {
        Boolean createNews(){
            return true;
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
