using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.ProfileModels
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string NationalId { get; set; }
        public string PassportId { get; set; }
        public string ImagePath { get; set; }


    }
}
