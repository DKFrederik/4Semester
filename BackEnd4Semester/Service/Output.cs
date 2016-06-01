using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    [Serializable]
    public class Output
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string InputData { get; set; }
    }
}
