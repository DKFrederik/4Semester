using System;

namespace Model
{
    public abstract class Events : ContentInfo
    {
        public Events() { }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
