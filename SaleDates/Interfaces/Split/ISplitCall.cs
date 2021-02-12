using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleDates.Interfaces
{
    public interface ISplitCall
    {
        public string Key { get; set; }
        public string Feature { get; set; }
        public Dictionary<string, object> Attributes { get; set; }

        public ISplitService SplitService { get; set; }
    }
}
