using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Entities
{
    public class SubscriptionType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
