using System;
using System.Collections.Generic;
using System.ServiceModel;
using Model;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBSIService
    {
        [OperationContract]
        int GetRolesForUser(string username);

        [OperationContract]
        bool ValidateUser(String username, string password);

        [OperationContract]
        Player FindPlayer(String email);

        [OperationContract]
        Boolean DeletePlayer(string email);

        [OperationContract]
        Boolean CreatePlayer(string username, string password, string firstname, string lastname, string email, int admPri, string type, int number, int gamesplayed, int goals, int penalties);
        [OperationContract]
        Boolean CreateUser(string username, string password, string firstname, string lastname, string email, int admPri, string type);

        [OperationContract]
        Boolean CreateNews(string title, User author, DateTime date, string content, Boolean isPublic, string contentType, string picture);
        
        [OperationContract]
        Boolean CreateMatch(string title, User author, DateTime date, string content, Boolean isPublic, string contentType,
            DateTime startTime, DateTime endTime, string eventType, string opponent, int homegoals, int awaygoals, Team team);

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
        Team FindTeamWithId(int id, Boolean retrieveAssoc);

        [OperationContract]
        Team FindTeam(string name, Boolean retrieveAssoc);
    }
}
