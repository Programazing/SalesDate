using SaleDates.Interfaces;
using SaleDates.Models;
using Splitio.Services.Client.Classes;
using Splitio.Services.Client.Interfaces;
using System;
using System.Collections.Generic;
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

        public Task<string> GetTreatment(string key, string feature, Dictionary<string, object> attributes)
        {
            var treatment = SDK.GetTreatment(key, feature, attributes);

            return Task.FromResult(treatment);
        }
    }
}
