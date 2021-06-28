using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.InternalModels;

namespace WebTemplate02.Models
{
    public class ContractViewModelAdmin
    {
        public string Username { get; set; }
        public string LastMessageSent { get; set; }
        public DateTime TimeLastMessageSent { get; set; }
        public int Id { get; set; }
        public string ContractViewId { get; set; }
        public List<DM> Conversation { get; set; }
    }
}
