using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.ProfileModels
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string GroupId { get; set; }
        public string StringGroupName { get; set; }
        public string GroupMemberId { get; set; }
        public string GroupStarter { get; set; }
        public string GroupDescription { get; set; }
    }
}
