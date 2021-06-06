using AktifBankTech.Business.Commons.Models.UserModels;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace AktifBankTech.Web.Api.Core.Authorizations
{
    public static class AuthorizationProvider
    {
        public static string GenerateOAuthToken(UserResponse userResponse)
        {
            var identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
            identity.AddClaim(new Claim("UserId", userResponse.Id.ToString()));
            identity.AddClaim(new Claim("TcNo", userResponse.TCNo));
            
            if (userResponse.Role != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, userResponse.Role.RoleName));
            }
            else
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
            }

            AuthenticationTicket ticket = new AuthenticationTicket(identity, CreateProperties(userResponse.TCNo));
            ticket.Properties.ExpiresUtc = DateTime.Now.AddDays(1);
            return Startup.OAuthServerOptions.AccessTokenFormat.Protect(ticket);
        }

        public static int GetUserId(IPrincipal user)
        {
            int userId = 0;
            if (user.Identity.IsAuthenticated)
            {
                var data = ((ClaimsIdentity)user.Identity).FindFirst("UserId").Value;
                if (int.TryParse(data, out userId))
                {
                    return userId;
                }
                throw new Exception("UserId değeri rakam olmalı");
            }
            else
            {
                throw new Exception("UserId değeri bulunamıyor. Kullanıcı login değil");
            }
        }

        public static string GetUserRole(IPrincipal user)
        {
            string userRole = "";
            if (user.Identity.IsAuthenticated)
            {
                return ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.Role).Value;
            }
            else
            {
                throw new Exception("UserRole değeri bulunamıyor. Kullanıcı login değil");
            }
        }

        private static AuthenticationProperties CreateProperties(string tcNo)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "TCNo", tcNo }
            };
            return new AuthenticationProperties(data);
        }
    }
}