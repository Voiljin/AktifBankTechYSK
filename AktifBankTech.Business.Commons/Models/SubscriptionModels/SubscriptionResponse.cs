using AktifBankTech.Business.Commons.Models.DepositModels;
using AktifBankTech.Business.Commons.Models.InvoiceModels;
using AktifBankTech.Business.Commons.Models.SubscriptionTypeModels;
using AktifBankTech.Business.Commons.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Commons.Models.SubscriptionModels
{
    public class SubscriptionResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubscriptionTypeId { get; set; }
        public bool IsActive { get; set; }



        public UserResponse User { get; set; }

        public List<InvoiceResponse> Invoices { get; set; }

        public List<DepositResponse> Deposits { get; set; }

        public SubscriptionTypeResponse SubscriptionType { get; set; }
    }
}
