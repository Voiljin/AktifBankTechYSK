using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Commons.Models.SubscriptionModels
{
    public class SubscriptionRequest
    {
        public int UserId { get; set; }
        public string SearchKeyword { get; set; }
        public string Type { get; set; }
    }
}
