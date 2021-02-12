using SaleDates.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaleDates.Interfaces
{
    public interface ISplitService
    {
        public Task<string> GetTreatment(string key, string feature, Dictionary<string, object> attributes);
    }
}
