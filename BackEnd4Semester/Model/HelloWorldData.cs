using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class HelloWorldData
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool SayHello { get; set; }


        public HelloWorldData()
        {
            Name = "Hello ";
            SayHello = false;
        }
    }
}
