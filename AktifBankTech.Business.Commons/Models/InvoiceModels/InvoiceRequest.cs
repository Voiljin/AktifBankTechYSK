using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Commons.Models.InvoiceModels
{
    public class InvoiceRequest
    {
        public int SubscriptionId { get; set; }
        public string Status { get; set; }
        public int AuthUserId { get; set; }
    }
}
