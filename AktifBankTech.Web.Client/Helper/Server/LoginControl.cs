using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AktifBankTech.Web.Client.Helper.Server
{
    public class LoginControl : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var backUrl = HttpContext.Current.Request.Url.ToString();

            var redirectPath = "~/Account/UserLogin";

            try
            {
                AuthSessionManager authManager = new AuthSessionManager();
                var userModel = authManager.GetAuthenticatUserModel();

                if (userModel == null || userModel.AuthenticationToken == null || userModel.AuthenticatUser == null)
                {
                    if (!String.IsNullOrEmpty(backUrl))
                    {
                        if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                        {
                            filterContext.Result = new HttpStatusCodeResult(403, "Return login page.");
                        }
                        else
                        {
                            filterContext.Result = new RedirectResult(redirectPath);
                        }
                    }
                    else
                    {
                        if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                        {
                            filterContext.Result = new HttpStatusCodeResult(403, "Return login page.");
                        }
                        else
                        {
                            filterContext.Result = new RedirectResult(redirectPath);
                        }
                    }
                }
            }
            catch (Exception)
            {
                if (!String.IsNullOrEmpty(backUrl))
                {
                    if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.Result = new HttpStatusCodeResult(403, "Return login page.");
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult(redirectPath);
                    }

                }
                else
                {
                    if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.Result = new HttpStatusCodeResult(403, "Return login page.");
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult(redirectPath);
                    }

                }
            }
        }
    }
}