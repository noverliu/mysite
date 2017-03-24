using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.qiming.Class
{
    public class BasicInfo
    {
        public int WordNum { get; set; }
        public bool AllowReduplication { get; set; }
        public string[] Words { get; set; }
        public TimeType IsLunar { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public string FirstName { get; set; }
    }
}
