using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.BookingModels;

namespace WebTemplate02.Models
{
    public class FlightViewModel : Flight
    {
        public string ImagePath { get; set; }
    }
}
