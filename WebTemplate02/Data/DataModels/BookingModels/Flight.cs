using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.BookingModels
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public string FlightId { get; set; }
        public string FlightReservationId { get; set; }
        public string FlightAccountId { get; set; }

        public int FlightCode { get; set; }
    }
}
