using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.InternalModels;

namespace WebTemplate02.Models
{
    public class AgentChatModel
    {
        public string Image { get; set; }
        public string UserId { get; set; }
        public string AgentName { get; set; }
        public int UnreadMessages { get; set; }
        public List<DM> Conversation { get; set; } = new List<DM>();
        public string Message { get; set; }
        public IFormFile Attatchment { get; set; }
        public DateTime TimeSent { get; set; }
    }
}
