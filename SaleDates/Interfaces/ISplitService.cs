using SaleDates.Models;
using System.Threading.Tasks;

namespace SaleDates.Interfaces
{
    public interface ISplitService
    {
        Task<bool> IsTodayASaleDayForTheUser(User user);
    }
}
