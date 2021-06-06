using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Entities
{
    public class Deposit
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public int Value { get; set; }
        public string Status { get; set; }

        public virtual Subscription Subscription { get; set; }
    }
}
