using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubscriptionTypeId { get; set; }
        public bool IsActive { get; set; }



        //User
        public virtual User User { get; set; }
        
        //aboneliğe ait fatura
        public virtual ICollection<Invoice> Invoices { get; set; }
        
        //aboneliğe ait depozito bilgileri
        public virtual ICollection<Deposit> Deposits { get; set; }

        //Abonelik tipi, bireysel - tüzel
        public virtual SubscriptionType SubscriptionType { get; set; }
    }
}
