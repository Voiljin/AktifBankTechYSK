using AktifBankTech.Business.Commons.Models.CommonModels;
using AktifBankTech.Business.Commons.Models.UserModels;
using AktifBankTech.Business.IEngines.IUsersEngines;
using AktifBankTech.Web.Api.Core.Authorizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AktifBankTech.Web.Api.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUsersEngine _usersEngine;

        public UserController(IUsersEngine usersEngine)
        {
            _usersEngine = usersEngine;
        }

        [Route("Login")]
        [HttpPost]
        public IHttpActionResult Login(RequestToken<UserAuthenticationRequest> userRequest)
        {
            try
            {
                var result = _usersEngine.Authenticate(userRequest.Filter.TCNo, userRequest.Filter.Password, userRequest.Filter.IsAdminPage);
                if (result != null && result.IsActive == true)
                {
                    string authToken = AuthorizationProvider.GenerateOAuthToken(result);
                    return Ok(Token<UserResponse>.Instance.Login(result, authToken));
                }
                else
                {
                    return Ok(Token<UserResponse>.Instance.FailResult("403", "TCNo ya da Şifre Hatalı"));
                }
            }
            catch (Exception ex)
            {
                return Ok(Token<UserResponse>.Instance.FailResult("001", "Login olunamadı, hata detayı: " + ex.Message));
            }
        }
    }
}
