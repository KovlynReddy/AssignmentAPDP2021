using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.Social
{
    public class AlphaItem
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public int ItemNo { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCode { get; set; }
        public string ImagePath { get; set; }
        public int Status { get; set; }
        public int Quantity { get; set; }
    }
}
