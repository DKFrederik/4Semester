using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfAndroid
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AndroidService : IAndroidService
    {
        public string DoWork(string request)
        {
            Input i = request.Deserialize<Input>();

            //Database related task!
            //Using input

            Output o = new Output
            {
                Name = "FireExit",
                Age = "2",
                InputData = i.Father + " " + i.lastName
            };
            return o. Serializer();
        }
    }
}
