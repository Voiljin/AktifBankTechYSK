using AktifBankTech.Business.Commons.Models.SubscriptionModels;
using AktifBankTech.Web.Client.Agents.SubscriberAgents;
using AktifBankTech.Web.Client.Helper.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AktifBankTech.Web.Client.Controllers
{
    public class SubscriberController : Controller
    {
        public AuthSessionManager authManager;

        public SubscriberController()
        {
            authManager = new AuthSessionManager();
        }

        #region User
        [LoginControl]
        public ActionResult UserSubscriptions()
        {
            var request = new SubscriptionRequest()
            {
                UserId = authManager.GetAuthenticatUser().Id
            };

            var result = SubscriberAgent.GetUserSubscriptions(request);

            return View(result.Result);
        }
        #endregion


        #region Admin - Gişe Görevlisi
        [LoginControl]
        public ActionResult CreateSubscriber()
        {
            return View();
        }

        [LoginControl]
        [HttpPost]
        public ActionResult CreateSubscriber(InsertSubscriptionRequest request)
        {
            var result = SubscriberAgent.CreateSubscriber(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [LoginControl]
        public ActionResult GetSubscriberWithFilter()
        {
            return View();
        }

        [LoginControl]
        public ActionResult GetSubscriberWithFilterList(SubscriptionRequest request)
        {
            var result = SubscriberAgent.GetSubscriberWithFilter(request);

            return View(result.Result);
        }

        [LoginControl]
        [HttpPost]
        public ActionResult TurnOffSubscription(UpdateSubscriptionRequest request)
        {
            var result = SubscriberAgent.TurnOffSubscription(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}