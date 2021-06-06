using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCNo { get; set; }
        public string TaxNumber { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }





        //userRole admin-user
        public virtual Role Role { get; set; }

        //Abonelikler
        public virtual ICollection<Subscription> Subscriptions { get; set; }



    }
}
