using AktifBankTech.Business.Commons.Models.CommonModels;
using AktifBankTech.Business.Commons.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AktifBankTech.Web.Client.Agents.UserAgents
{
    public class UserAgent
    {
        public static Token<UserResponse> Login(UserAuthenticationRequest model)
        {
            return Agent<UserResponse, UserAuthenticationRequest>.Instance.CallApi(new RequestToken<UserAuthenticationRequest> { Filter = model }, "POST", "user/Login");
        }
    }
}