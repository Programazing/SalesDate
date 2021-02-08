using System;
using System.Collections.Generic;

namespace SaleDates.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }

        internal Dictionary<string, object> Attributes()
        {
            var date = DateTime.Now;

            if (Name == "John Smith")
                date = MoveUserOutsideValidDateRange();

            return new Dictionary<string, object>
            {
                {"Date", date.ToShortDateString() }
            };
        }

        private static DateTime MoveUserOutsideValidDateRange()
        {
            return DateTime.Now.AddDays(-5);
        }
    }
}
