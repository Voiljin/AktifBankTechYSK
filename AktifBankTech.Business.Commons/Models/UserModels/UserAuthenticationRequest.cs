using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Commons.Models.UserModels
{
    public class UserAuthenticationRequest
    {
        public string TCNo { get; set; }
        public string Password { get; set; }
        public bool IsAdminPage { get; set; }
    }
}
