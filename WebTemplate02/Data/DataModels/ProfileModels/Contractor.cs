using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.ProfileModels
{
    public class Contractor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ContractorId { get; set; }
        public string AccountId { get; set; }
       
        public string ContractorName { get; set; }
        public double Duration { get; set; } // implem
        public string ReservationId { get; set; }
        public int Post { get; set; }
        [MaxLength(500)]
        public string PostDescription { get; set; }
    }
}
