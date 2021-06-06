using AktifBankTech.Business.Commons.Models.InvoiceModels;
using AktifBankTech.Business.Commons.Models.SubscriptionModels;
using AktifBankTech.Web.Client.Agents.InvoiceAgents;
using AktifBankTech.Web.Client.Helper.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AktifBankTech.Web.Client.Controllers
{
    public class InvoiceController : Controller
    {
        public AuthSessionManager authManager;

        public InvoiceController()
        {
            authManager = new AuthSessionManager();
        }

        [LoginControl]
        public ActionResult SubscriptionInvoice(int subscriptionId)
        {
            return View(subscriptionId);
        }

        [LoginControl]
        public ActionResult SubscriptionInvoiceList(int subscriptionId, string status)
        {
            var request = new InvoiceRequest()
            {
                SubscriptionId = subscriptionId, 
                Status = status,
                AuthUserId = authManager.GetAuthenticatUser().Id
            };

            var result = InvoiceAgent.GetSubscriberInvoices(request);

            return View(result.Result);
        }

        [LoginControl]
        [HttpPost]
        public ActionResult PayInvoice(UpdateInvoiceRequest request)
        {
            var result = InvoiceAgent.PayInvoice(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}