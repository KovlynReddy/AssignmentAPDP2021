using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.InternalModels;

namespace WebTemplate02.Models
{
    public class ConversationAdmin
    {
        public string UserName { get; set; } // agent id
        public List<DM> Conversation { get; set; } = new List<DM>();
        public string Message { get; set; }
        public string UserId { get; set; } //  client id
        public string ClientName { get; set; } // client email
    }
}
