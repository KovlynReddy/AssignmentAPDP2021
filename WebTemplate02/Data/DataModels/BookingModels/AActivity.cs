using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.ProfileModels;

namespace WebTemplate02.Data.DataModels.BookingModels
{
    public class AActivity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ActivityId { get; set; }
        public string ReservationId { get; set; }
        public string TourGuideId { get; set; }
        public string BookingId { get; set; }

        public string ActivityDesciption { get; set; }

    }
}
