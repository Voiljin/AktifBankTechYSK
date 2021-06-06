using AktifBankTech.Business.Commons.Models.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Commons.Models.SubscriptionTypeModels
{
    public class SubscriptionTypeResponse
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public List<SubscriptionResponse> Subscriptions { get; set; }
    }
}
