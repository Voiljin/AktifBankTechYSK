using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public int Value { get; set; }
        public string Status { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceDueDate { get; set; }



        public virtual Subscription Subscription { get; set; }


        //abonelik
    }
}
