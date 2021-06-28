using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.InternalModels
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public string ReservationId { get; set; }
        public string TransactionId { get; set; }
        public string UserProfileId { get; set; }
        public string BookingId { get; set; }

        public string StartLocationId { get; set; }
        public string EndLocationId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
