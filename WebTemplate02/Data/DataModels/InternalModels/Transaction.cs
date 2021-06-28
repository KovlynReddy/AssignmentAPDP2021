using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.InternalModels
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public string ContractorId { get; set; } // not the User implem
        public string UserProfileId { get; set; } //  the User implem
        public string RecipientId { get; set; }
        [Column("Sender_id")]
        public string SenderId { get; set; }
        public DateTime TimePayment { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public double Amount { get; set; }

    }
}
