using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models.Tools
{
    public class QimingModel
    {
        public string FirstName { get; set; }
        public string[] Words { get; set; }
        public bool Gender { get; set; }
        public bool TimeType { get; set; }
        public DateTime Birthday { get; set; }
        public bool AllowReduplication { get; set; }
        public string result { get; set; }
        public int numWord { get; set; }
    }
}
