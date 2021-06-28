using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.BookingModels
{
    public class BookingPackage
    {
        [Key]
        public int Id { get; set; }
        public string BookingId { get; set; }
        public string UserId { get; set; }
        public string OutFlightId { get; set; }
        public string InFlightId { get; set; }
        public string HotelId { get; set; }

        public int DurationDays { get; set; }

    }
}
