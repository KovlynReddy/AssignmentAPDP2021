using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.Social
{
    public class AlphaPost
    {
        public int Id { get; set; }
        public string PostId { get; set; }
        public string ItemId { get; set; }
        public string UserId { get; set; }
        public string ImagePath { get; set; }
        public string Message { get; set; }
        public DateTime DatePosted { get; set; }
        public List<AlphaUser> Read { get; set; }
        public List<DateTime> TimeRead { get; set; }

    }
}
