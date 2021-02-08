using SaleDates.Interfaces;
using SaleDates.Models;
using Splitio.Services.Client.Classes;
using Splitio.Services.Client.Interfaces;
using System;
using System.Threading.Tasks;

namespace SaleDates.Services
{
    public class SplitService : ISplitService
    {
        readonly ISplitClient SDK;

        public SplitService()
        {
            var config = new ConfigurationOptions();
            var factory = new SplitFactory("6a42eo3nsnm2lldemiid0ri9r01a8d2tvm3p", config);
            SDK = factory.Client();

            try
            {
                SDK.BlockUntilReady(10000);
            }
            catch (Exception ex)
            {
                // log & handle 
            }
        }

        public Task<bool> IsTodayASaleDayForTheUser(User user)
        {
            var treatment = SDK.GetTreatment(user.Name, "SaleDays", user.Attributes());
            
            if(treatment == "on")
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
