using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.BookingModels
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string HotelLocationId { get; set; }
        public string HotelId { get; set; }
        public string HotelReservationId { get; set; }
        public string HotelAccountId { get; set; }

        public int HotelRoomCode { get; set; }
        public string HotelName { get; set; }
    }
}
