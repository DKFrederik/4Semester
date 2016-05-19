using System;
using System.Collections.Generic;
using System.ServiceModel;
using Model;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISecureBSIService
    {
        [OperationContract]
        int GetRolesForUserSecure(string username);
        [OperationContract]
        bool ValidateUserSecure(string username, string password);

        [OperationContract]
        Player FindPlayerSecure(String email);

        [OperationContract]
        Boolean DeletePlayerSecure(string email);

        [OperationContract]
        Boolean CreatePlayerSecure(string username, string password, string firstname, string lastname, string email, int admPri, string type, int number, int gamesplayed, int goals, int penalties);
        [OperationContract]
        Boolean CreateUserSecure(string username, string password, string firstname, string lastname, string email, int admPri, string type);

        [OperationContract]
        Boolean CreateNewsSecure(string title, User author, DateTime date, string content, Boolean isPublic, string contentType, string picture);
        
        [OperationContract]
        Boolean CreateMatchSecure(string title, User author, DateTime date, string content, Boolean isPublic, string contentType,
            DateTime startTime, DateTime endTime, string eventType, string opponent, int homegoals, int awaygoals, Team team);

        [OperationContract]
        Boolean DeleteUserSecure(string email);

        [OperationContract]
        User FindUserSecure(string email);

        [OperationContract]
        List<Match> FindMatchesSecure(DateTime date);

        [OperationContract]
        List<TrainingSession> FindTrainingSessionsSecure(DateTime date);

        [OperationContract]
        List<News> FindNewsSecure(DateTime date);

        [OperationContract]
        Boolean UpdateUserSecure(string oldFn, string oldLn, string username, string password, string firstname, string lastname, string email, int admPri, string type);

        [OperationContract]
        Team FindTeamWithIdSecure(int id, Boolean retrieveAssoc);

        [OperationContract]
        Team FindTeamSecure(string name, Boolean retrieveAssoc);
    }
}

