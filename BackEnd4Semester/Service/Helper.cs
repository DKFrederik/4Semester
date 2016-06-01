using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Service
{
    public static class Helper
    {
        public static T Deserialize<T>(this String s)
        {
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            T input = json_serializer.Deserialize<T>(s);
            return input;
        }

        public static String Serializer(this Object s)
        {
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            return json_serializer.Serialize(s);
        }
    }
}
