using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.InternalModels
{
    public class Location
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string LocationId { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string LocationName { get; set; }

        public string LocationString { get; set; }
        public string SpacingCharacter { get; set; }

    }
}
