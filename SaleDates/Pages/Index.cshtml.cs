using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SaleDates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleDates.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISplitService _split;
        private readonly IUserRepository _userRepository;

        public List<string> SaleDayMessage { get; set; } = new List<string>();

        public IndexModel(ILogger<IndexModel> logger, ISplitService split, IUserRepository userRepository)
        {
            _logger = logger;
            _split = split;
            _userRepository = userRepository;
        }

        public void OnGet()
        {

            var users = _userRepository.GetUsers();

            foreach (var user in users)
            {
                var TodayIsASaleDay = _split.IsTodayASaleDayForTheUser(user);

                if (TodayIsASaleDay.Result is true)
                {
                    SaleDayMessage.Add($"Today is a Sale day for {user.Name}!");
                }
                else
                {
                    SaleDayMessage.Add($"Today is not a Sale day for {user.Name}.");
                }
            }

            
        }
    }
}
