using AktifBankTech.Web.Client.Helper.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AktifBankTech.Web.Client.Controllers
{
    public class HomeController : Controller
    {
        [LoginControl]
        public ActionResult Index()
        {
            return View();
        }

        [LoginControl]
        public ActionResult Header()
        {
            return View();
        }

        [LoginControl]
        public ActionResult LeftMenu()
        {
            return View();
        }

        [LoginControl]
        public ActionResult ErrorPage()
        {
            return View();
        }
    }
}