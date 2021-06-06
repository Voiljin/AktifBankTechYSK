using AktifBankTech.Business.Commons.Models.UserModels;
using AktifBankTech.Web.Client.Agents.UserAgents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AktifBankTech.Web.Client.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult UserLogin()
        {
            Session["user"] = null;
            Session["authenticationToken"] = null;

            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(UserAuthenticationRequest authenticationRequest)
        {
            authenticationRequest.IsAdminPage = false;
            var result = UserAgent.Login(authenticationRequest);

            if (result == null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (result.HasError == true)
                {
                    Session["authErrorMessage"] = result.ResultMessage;
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["user"] = result.Result;
                    Session["authenticationToken"] = result.AuthenticationToken;

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult AdminLogin()
        {
            Session["user"] = null;
            Session["authenticationToken"] = null;

            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(UserAuthenticationRequest authenticationRequest)
        {
            authenticationRequest.IsAdminPage = true;
            var result = UserAgent.Login(authenticationRequest);

            if (result == null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (result.HasError == true)
                {
                    Session["authErrorMessage"] = result.ResultMessage;
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["user"] = result.Result;
                    Session["authenticationToken"] = result.AuthenticationToken;

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult Logout()
        {
            Session["authenticationToken"] = null;
            Session["user"] = null;
            Session.Clear();

            return RedirectToAction("UserLogin");
        }
    }
}