using AktifBankTech.Business.Commons.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AktifBankTech.Web.Client.Helper.Server
{
    public class AuthSessionManager
    {
        public AuthenticatUserModel GetAuthenticatUserModel()
        {
            if (HttpContext.Current.Session["authenticationToken"] != null && HttpContext.Current.Session["user"] != null)
            {
                return new AuthenticatUserModel
                {
                    AuthenticationToken = HttpContext.Current.Session["authenticationToken"].ToString(),
                    AuthenticatUser = (UserResponse)HttpContext.Current.Session["user"]
                };
            }

            return null;
        }

        public UserResponse GetAuthenticatUser()
        {
            if (GetAuthenticatUserModel() != null)
            {
                return GetAuthenticatUserModel().AuthenticatUser;
            }

            return null;
        }

        public string FullName()
        {
            var authenticatUser = GetAuthenticatUser();
            return authenticatUser.FirstName + " " + authenticatUser.LastName;
        }

        public int GetUserId()
        {
            return GetAuthenticatUserModel().AuthenticatUser.Id;
        }

        public void DeleteAuthenticatUserModel()
        {
            HttpContext.Current.Session["authenticationToken"] = null;
            HttpContext.Current.Session["user"] = null;
        }
    }
}