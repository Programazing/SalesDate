using SaleDates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleDates.Splits
{
    public abstract class SplitCalls : ISplitCall
    {
        public string Key { get; set; }
        public string Feature { get; set; }
        public Dictionary<string, object> Attributes { get; set; }

        public ISplitService SplitService { get; set; }

        protected SplitCalls(ISplitService splitService)
        {
            SplitService = splitService;
        }
    }
}
