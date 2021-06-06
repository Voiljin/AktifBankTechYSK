using AktifBankTech.Business.Commons.Models.CommonModels;
using AktifBankTech.Business.Commons.Models.SubscriptionModels;
using AktifBankTech.Business.IEngines.IDepositsEngines;
using AktifBankTech.Business.IEngines.IInvoicesEngines;
using AktifBankTech.Business.IEngines.ISubscriptionsEngines;
using AktifBankTech.Business.IEngines.ISubscriptionTypesEngines;
using AktifBankTech.Business.IEngines.IUsersEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web.Http;

namespace AktifBankTech.Web.Api.Controllers
{
    [RoutePrefix("api/subscription")]
    public class SubscriptionController : ApiController
    {
        private readonly ISubscriptionsEngine _subscriptionsEngine;
        private readonly IUsersEngine _usersEngine;
        private readonly IDepositsEngine _depositsEngine;
        private readonly IInvoicesEngine _invoicesEngine;
        private readonly ISubscriptionTypesEngine _subscriptionTypesEngine;

        public SubscriptionController(ISubscriptionsEngine subscriptionsEngine, IUsersEngine usersEngine, IDepositsEngine depositsEngine, IInvoicesEngine invoicesEngine, ISubscriptionTypesEngine subscriptionTypesEngine)
        {
            _subscriptionsEngine = subscriptionsEngine;
            _usersEngine = usersEngine;
            _depositsEngine = depositsEngine;
            _invoicesEngine = invoicesEngine;
            _subscriptionTypesEngine = subscriptionTypesEngine;
        }

        #region Admin Ekranı
        [Route("CreateSubscriber")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult CreateSubscriber(RequestToken<InsertSubscriptionRequest> request)
        {
            var response = Token<bool>.Instance;

            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    //User tablosunda var mı diye bak
                    var user = _usersEngine.GetUserWithTcNo(request.Filter.TCNo);

                    //yoksa user tablosuna ekle
                    if (user == null)
                    {
                        user = _usersEngine.InsertUser(request.Filter.FirstName, request.Filter.LastName, request.Filter.TCNo, request.Filter.TaxNumber);
                    }
                    else
                    {
                        var getSubsTypesTuzelId = _subscriptionTypesEngine.GetAllSubscriptionTypes().Where(x => x.TypeName == StaticParameters.SubscribeTypeTuzel).FirstOrDefault().Id;

                        //yeni abonelik tüzel müşteri ise ve kullanıcı daha önce Bireysel Kayıt olduysa TaxNumber'i update et
                        if (request.Filter.SubscriptionTypeId == getSubsTypesTuzelId && String.IsNullOrEmpty(user.TaxNumber))
                        {
                            var updateTaxNumber = _usersEngine.UpdateUser(user.Id, request.Filter.TaxNumber);
                        }
                    }
                    

                    //ardından yeni abonelik ekle
                    request.Filter.UserId = user.Id;
                    var insertSubs = _subscriptionsEngine.CreateSubscriber(request.Filter);

                    //depozito bilgilerini ekle
                    var insertDeposit = _depositsEngine.InsertDeposit(insertSubs.Id);


                    response.SuccessResult(true);
                    transaction.Complete();
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return Ok(response.FailResult("Abonelik oluşturulamadı", "Hata detayı: " + ex.Message));
            }
        }

        [Route("TurnOffSubscription")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult TurnOffSubscription(RequestToken<UpdateSubscriptionRequest> request)
        {
            var response = Token<bool>.Instance;

            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    //Ödenmemiş fatura kontrol işlemleri
                    var getUnpaidInvoices = _invoicesEngine.GetInvoicesFilter(request.Filter.Id, StaticParameters.InvoiceStatusActive);
                    if (getUnpaidInvoices.Count > 0) throw new Exception("Aboneliğe ait ödenmemiş fatura/lar var, ilk önce ödeme işlemi yapın");

                    //Depozito iade işlemleri
                    _depositsEngine.ReturnDeposits(request.Filter.Id);

                    //Abonelik kapatma işlemleri
                    var turnOffSubs = _subscriptionsEngine.TurnOffSubscription(request.Filter.Id);

                    response.SuccessResult(turnOffSubs);
                    transaction.Complete();
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return Ok(response.FailResult("Abonelik kapatma işlemi gerçekleştirilemedi", "Hata detayı: " + ex.Message));
            }
        }

        [Route("GetSubscriberWithFilter")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetSubscriberWithFilter(RequestToken<SubscriptionRequest> request)
        {
            var response = Token<List<SubscriptionResponse>>.Instance;

            try
            {
                var getSubs = _subscriptionsEngine.GetSubscriberWithFilter(request.Filter.SearchKeyword, request.Filter.Type);

                response.SuccessResult(getSubs);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(response.FailResult("Abonelikler getirilemedi", "Hata detayı: " + ex.Message));
            }
        }


        #endregion

        #region User Ekranı
        [Route("GetUserSubscriptions")]
        [HttpPost]
        [Authorize(Roles ="User")]
        public IHttpActionResult GetUserSubscriptions(RequestToken<SubscriptionRequest> request)
        {
            var response = Token<List<SubscriptionResponse>>.Instance;

            try
            {
                var getSubscriptions = _subscriptionsEngine.GetUserSubscriptions(request.Filter.UserId);

                response.SuccessResult(getSubscriptions);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(response.FailResult("Abonelik bilgileri getirilemedi", "Hata detayı: " + ex.Message));
            }
        }
        #endregion


    }
}
