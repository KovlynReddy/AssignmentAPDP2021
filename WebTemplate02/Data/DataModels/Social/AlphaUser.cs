using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.Social
{
    [Table("AlphaUsers")]
    public class AlphaUser
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string UserId { get; set; }
        public string UserName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string Password { get; set; }

        public AlphaUser()
        {
            this.UserId = Guid.NewGuid().ToString();
        }
    }
}
