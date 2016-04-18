using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;


namespace Controller
{
    class ContentCtr
    {
        TrainingSessionDao trainingSessionDao;

        public ContentCtr()
        {
            trainingSessionDao = new TrainingSessionDao();
        }

        Boolean createNews(){
            return true;
        }

        public bool CreateTrainingSession(string title, string author, DateTime date, string content, bool isPulic, DateTime startTime, DateTime endTime, string trainer){
            TrainingSession newTs = new TrainingSession(title, author, date, content, isPulic, startTime, endTime, trainer);
            return trainingSessionDao.CreateTrainingSession(newTs);
        }

        public TrainingSession FindTrainingSession(string title)
        {
            return trainingSessionDao.FindTrainingSession(title);
        }

        public bool UpdateTrainingSession(string oldTitle, string newTitle, string newAuthor, DateTime newDate, string newContent, bool newIsPulic, DateTime newStartTime, DateTime newEndTime, string newTrainer)
        {
            return true;
        }

        public bool DeleteTrainingSession(string title)
        {
            Boolean success = false;
            int rc = trainingSessionDao.DeleteTrainingSession(title);
            if(rc > 0)
            {
                success = true;
            }
            return success;
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


        Boolean updateMatch(){
            return true;
        }
        
        Boolean updateContentInfo(){
            return true;
        }
    }
}
