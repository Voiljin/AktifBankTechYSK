using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Commons.Models.UserModels
{
    public class AuthenticatUserModel
    {
        public string AuthenticationToken { get; set; }
        public string UserNameType { get; set; }
        public UserResponse AuthenticatUser { get; set; }
    }
}
