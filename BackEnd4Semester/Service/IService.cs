using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Player getPlayer(String email);

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
        User FindUser(string firstname, string lastname);

        [OperationContract]
        Boolean UpdateUser(string oldFn, string oldLn, string username, string password, string firstname, string lastname, string email, int admPri, string type);
    }
}
