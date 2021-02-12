using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SaleDates.Interfaces;
using System;
using System.Collections.Generic;

namespace SaleDates.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISplitService _split;
        private readonly IUserRepository _userRepository;
        public IEnumerable<Models.User> Users = new List<Models.User>();

        public IndexModel(ILogger<IndexModel> logger, ISplitService split, IUserRepository userRepository)
        {
            _logger = logger;
            _split = split;
            _userRepository = userRepository;
        }

        public void OnGet()
        {
            var users = _userRepository.GetUsers();
            
            CheckForSaleDates(users);

            Users = users;
        }

        private void CheckForSaleDates(IEnumerable<Models.User> users)
        {
            foreach (var user in users)
            {
                var saleDates = new Splits.SaleDates(_split);
                var TodayIsASaleDay = saleDates.IsTodayASaleDayForTheUser(user);

                if (TodayIsASaleDay.Result is true)
                {
                    user.ItsASaleDay = true;
                }
            }
        }
    }
}
