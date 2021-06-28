using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.InternalModels
{
    public class DM
    {
        [Key]
        public int Id { get; set; }
        public string DMId { get; set; }
        public DateTime TimeSend { get; set; }
        public DateTime TimeRecieved { get; set; }
        public DateTime TimeRead { get; set; }
        public string SenderId { get; set; }
        public string RecipientId { get; set; }
        public string Message { get; set; }
        public string Description { get; set; } 
    }


}
