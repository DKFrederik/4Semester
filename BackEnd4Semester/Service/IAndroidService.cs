using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAndroidService
    {

 
        [OperationContract]
        string SayHelloTo(string name);

        [OperationContract]
        HelloWorldData GetHelloData(HelloWorldData helloWorldData);


        [OperationContract]
        String DoWork(String request);

        //Not Android

        [OperationContract]
        Player FindPlayer(String email);

        [OperationContract]
        Boolean DeletePlayer(string email);

        [OperationContract]
        Boolean CreatePlayer(string username, string password, string firstname, string lastname, string email, int admPri, string type, int number, int gamesplayed, int goals, int penalties);
        [OperationContract]
        Boolean CreateUser(string username, string password, string firstname, string lastname, string email, int admPri, string type);

        [OperationContract]
        Boolean CreateNews(string title, User author, DateTime date, string content, Boolean isPublic, string picture);

        [OperationContract]
        Boolean CreateMatch(string title, User author, DateTime date, string content, Boolean isPublic,
            DateTime startTime, DateTime endTime, string opponent, int homegoals, int awaygoals, Team team);

        [OperationContract]
        Boolean DeleteUser(string email);

        [OperationContract]
        User FindUser(string email);

        [OperationContract]
        List<Match> FindMatches(DateTime date);

        [OperationContract]
        List<TrainingSession> FindTrainingSessions(DateTime date);

        [OperationContract]
        List<News> FindNews(DateTime date);

        [OperationContract]
        Boolean UpdateUser(string oldFn, string oldLn, string username, string password, string firstname, string lastname, string email, int admPri, string type);

        [OperationContract]
        Team FindTeam(int id, Boolean retrieveAssoc);

        //[OperationContract]
        //Team FindTeam(string name, Boolean retrieveAssoc);
    }
}
