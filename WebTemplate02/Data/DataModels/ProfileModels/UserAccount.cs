using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.ProfileModels
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AccountId { get; set; }
        public string UserId { get; set; }
        public double Balance { get; set; }
    }
}
