using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformChallenge.Objects
{
    public class ParsedRecord
    {
        public string date_utc { get; set; }
        public string event_type { get; set; }
        public string resource { get; set; }
        public RecordData data { get; set; }
    }
}
