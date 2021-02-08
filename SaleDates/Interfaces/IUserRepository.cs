using SaleDates.Models;
using System.Collections.Generic;

namespace SaleDates.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers();
    }
}
