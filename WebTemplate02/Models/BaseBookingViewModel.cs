using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.BookingModels;
using WebTemplate02.Data.DataModels.InternalModels;

namespace WebTemplate02.Models
{
    public class BaseBookingViewModel
    {
        public int Id { get; set; }
        public string BookingBaseViewId { get; set; }


        public List<Location> ListLocations { get; set; }
        public List<Hotel> ListHotels { get; set; }
        public List<Flight> ListFlights { get; set; }
        public List<Reservation> ListReservations { get; set; }
        public List<DateTime> ListFlightTime { get; set; }

        public string LocationInId { get; set; }
        [BindProperty, DataType(DataType.Time)]
        public DateTime TimeIn { get; set; }
        public string FlightIn { get; set; }
        public string ReservationIn { get; set; }
        
        public string LocationOutId { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime TimeOut { get; set; }
        public string FlightOut { get; set; }
        public string ReservationOut { get; set; }
        
        public string HotelId { get; set; }
        public int Duration { get; set; }
        public string UserId { get; set; }
    }
}
