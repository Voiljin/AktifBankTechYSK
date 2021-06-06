using AktifBankTech.Business.Commons.Models.RoleModels;
using AktifBankTech.Business.Commons.Models.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Commons.Models.UserModels
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCNo { get; set; }
        public string TaxNumber { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }




        public RoleResponse Role { get; set; }
        public List<SubscriptionResponse> Subscriptions { get; set; }
    }
}
