using AktifBankTech.Business.Commons.Models.DepositModels;
using AktifBankTech.Business.Commons.Models.SubscriptionModels;
using AktifBankTech.Business.IEngines.ISubscriptionsEngines;
using AktifBankTech.Data.Entities;
using AktifBankTech.Data.Interfaces.SubscriptionsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Engines.SubscriptionsEngines
{
    public class SubscriptionsEngine : BusinessEngineBase, ISubscriptionsEngine
    {
        private readonly ISubscriptionsRepository _subscriptionsRepository;

        public SubscriptionsEngine(ISubscriptionsRepository subscriptionsRepository)
        {
            _subscriptionsRepository = subscriptionsRepository;
        }

        #region Admin Ekranı
        //Yeni abonelik oluşturma
        public SubscriptionResponse CreateSubscriber(InsertSubscriptionRequest request)
        {
            request.IsActive = true;

            var insertSubs = _subscriptionsRepository.Add(Mapper.Map<Subscription>(request));
            _subscriptionsRepository.SaveChanges();

            return Mapper.Map<SubscriptionResponse>(insertSubs);
        }

        //Aboneliği kapat
        public bool TurnOffSubscription(int subscriptionId)
        {
            var getSubscription = _subscriptionsRepository.Get(subscriptionId);
            if (getSubscription == null) throw new Exception("Abonelik bilgisi bulunamadı");

            getSubscription.IsActive = false;
            _subscriptionsRepository.Update(getSubscription);
            _subscriptionsRepository.SaveChanges();

            return true;
        }

        //Abonelik sorgulama
        public List<SubscriptionResponse> GetSubscriberWithFilter(string searchKeyword, string type)
        {
            var getSubs = _subscriptionsRepository.GetSubscriberWithFilter(searchKeyword, type);

            return Mapper.Map<List<SubscriptionResponse>>(getSubs);
        }

        public SubscriptionResponse GetSingleSubscription(int subsId)
        {
            var getSubs = _subscriptionsRepository.Get(subsId);

            return Mapper.Map<SubscriptionResponse>(getSubs);
        }
        #endregion

        #region User ekranı
        //Kullanıcı ekranı abone bilgileri
        public List<SubscriptionResponse> GetUserSubscriptions(int userId)
        {
            var getSubscription = _subscriptionsRepository.GetUserSubscriptions(userId);

            return Mapper.Map<List<SubscriptionResponse>>(getSubscription);
        }
        #endregion
    }
}
