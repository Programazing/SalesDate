using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleDates.Interfaces;
using SaleDates.Models;

namespace SaleDates.Splits
{
    public class SaleDates : SplitCalls
    {
        public SaleDates(ISplitService splitService) : base(splitService)
        {

        }

        public Task<bool> IsTodayASaleDayForTheUser(User user)
        {
            var treatment = SplitService.GetTreatment(user.Name, "SaleDays", user.Attributes());

            if (treatment.Result == "on")
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
