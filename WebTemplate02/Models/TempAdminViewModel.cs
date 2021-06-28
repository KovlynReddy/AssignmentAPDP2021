using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.BookingModels;
using WebTemplate02.Data.DataModels.InternalModels;
using WebTemplate02.Data.DataModels.ProfileModels;

namespace WebTemplate02.Models
{
    public class TempAdminViewModel
    {
        public string NewSpecial { get; set; }
        public string SpecialDesciption { get; set; }

        public string LocationId { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }

        public bool Drivers { get; set; }
        public bool FirstClass { get; set; }
        public bool Activities { get; set; }

        public List<Data.DataModels.InternalModels.Location> locations { get; set; } = new List<Data.DataModels.InternalModels.Location>();
        public List<Flight> flights { get; set; } = new List<Flight>();
        public List<Hotel> hotels { get; set; } = new List<Hotel>();
        public List<Post> posts { get; set; } = new List<Post>();
        public List<DM> dms { get; set; } = new List<DM>();
        public List<Group> groupss { get; set; } = new List<Group>();
        public List<Contractor> contractors { get; set; } = new List<Contractor>();
        public List<AActivity> activities { get; set; } = new List<AActivity>();
        public List<Reservation> reservations { get; set; } = new List<Reservation>();
        public List<BookingPackage> bookings { get; set; } = new List<BookingPackage>();
        public List<ContractViewModelAdmin> adminDms { get; set; } = new List<ContractViewModelAdmin>();

        public string GetDescription() {

            string Driversstring = Drivers ? "1" : "0";
            string FirstClassstring = FirstClass ? "1" : "0";
            string dActivitiesstring = Activities ? "1" : "0";
            string DurationString = Duration.ToString("00");
            return $"{Driversstring},{FirstClassstring},{dActivitiesstring},{DurationString},{Cost}%{this.SpecialDesciption}";
        }
    }   
}
