using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.BookingModels;

namespace WebTemplate02.Models
{
    public class AddActivityToBaseBookingViewModel
    {
        public BookingPackage baseModel { get; set; }
        public string BookingId { get; set; }
        public List<AActivity> Days { get; set; } = new List<AActivity>();
        public string[  ] DaysActivities { get; set; }
        public List<AActivity> ListActivity { get; set; } 
        public double Total { get; set; }

        public DateTime DateFlightOut { get; set; }
    }
}
