using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Events : ContentInfo
    {
        public Events() { }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
