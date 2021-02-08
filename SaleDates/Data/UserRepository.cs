using SaleDates.Interfaces;
using SaleDates.Models;
using System.Collections.Generic;

namespace SaleDates.Data
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetUsers()
        {
            var jane = new User()
            {
                ID = "12345",
                Name = "Jane Doe",
            };

            var john = new User()
            {
                ID = "12346",
                Name = "John Smith",
            };

            return new List<User>() { jane, john };
            
        }
    }
}
