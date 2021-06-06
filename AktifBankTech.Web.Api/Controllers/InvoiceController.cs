using AktifBankTech.Business.Commons.Models.CommonModels;
using AktifBankTech.Business.Commons.Models.InvoiceModels;
using AktifBankTech.Business.IEngines.IInvoicesEngines;
using AktifBankTech.Business.IEngines.ISubscriptionsEngines;
using AktifBankTech.Web.Api.Core.Authorizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AktifBankTech.Web.Api.Controllers
{
    [RoutePrefix("api/invoice")]
    public class InvoiceController : ApiController
    {
        private readonly IInvoicesEngine _invoicesEngine;
        private readonly ISubscriptionsEngine _subscriptionsEngine;

        public InvoiceController(IInvoicesEngine invoicesEngine, ISubscriptionsEngine subscriptionsEngine)
        {
            _invoicesEngine = invoicesEngine;
            _subscriptionsEngine = subscriptionsEngine;
        }

        /// <summary>
        /// Fatura ödeme
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("PayInvoice")]
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IHttpActionResult PayInvoice(RequestToken<UpdateInvoiceRequest> request)
        {
            var response = Token<InvoiceResponse>.Instance;

            try
            {
                var payInvoice = _invoicesEngine.PayInvoice(request.Filter);

                response.SuccessResult(payInvoice);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(response.FailResult("Fatura ödeme işlemi gerçekleştirilemedi", "Hata detayı: " + ex.Message));
            }
        }


        [Route("GetSubscriberInvoices")]
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IHttpActionResult GetSubscriberInvoices(RequestToken<InvoiceRequest> request)
        {
            var response = Token<List<InvoiceResponse>>.Instance;

            try
            {                
                var getTokenRole = AuthorizationProvider.GetUserRole(User);
                var getTokenUserId = AuthorizationProvider.GetUserId(User);
                var getSubs = _subscriptionsEngine.GetSingleSubscription(request.Filter.SubscriptionId);

                if (getTokenRole == "User" && getTokenUserId != getSubs.UserId)
                    throw new Exception("User rolüne sahip bir kullanıcı sadece kendi faturalarını görüntüleyebilir. Yetkisiz işlem");

                var getInvoices = _invoicesEngine.GetInvoicesFilter(request.Filter.SubscriptionId, request.Filter.Status);

                response.SuccessResult(getInvoices);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(response.FailResult("Aboneliğe ait faturalar getirilemedi", "Hata detayı: " + ex.Message));
            }
        }
    }
}
