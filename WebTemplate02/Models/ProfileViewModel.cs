using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.BookingModels;
using WebTemplate02.Data.DataModels.InternalModels;
using WebTemplate02.Data.DataModels.ProfileModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTemplate02.Models
{
    public class ProfileViewModel
    {
        public UserProfile MyProfile { get; set; }
        public UserAccount userAccount { get; set; }
        public List<BookingPackage> BookingHistory { get; set; } = new List<BookingPackage>();
        public List<Flight> FlightHistory { get; set; } = new List<Flight>();
        public List<Location> VisitHistory { get; set; } = new List<Location>();
        public Location HomeTown { get; set; }
        public List<Hotel> HotelHistory { get; set; } = new List<Hotel>();

            [BindProperty]
            public IFormFile MyProperty { get; set; }
    }
}
