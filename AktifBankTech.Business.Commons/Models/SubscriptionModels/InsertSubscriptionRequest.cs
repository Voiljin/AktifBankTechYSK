using AktifBankTech.Business.Commons.Models.DepositModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Commons.Models.SubscriptionModels
{
    public class InsertSubscriptionRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCNo { get; set; }
        public string TaxNumber { get; set; }


        public int UserId { get; set; }
        public int SubscriptionTypeId { get; set; }
        public int DepositId { get; set; }
        public bool IsActive { get; set; }

        public InsertDepositRequest Deposit { get; set; }
    }
}
