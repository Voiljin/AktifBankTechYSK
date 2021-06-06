using AktifBankTech.Business.Commons.Models.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.IEngines.ISubscriptionsEngines
{
    public interface ISubscriptionsEngine
    {
        SubscriptionResponse CreateSubscriber(InsertSubscriptionRequest request);
        bool TurnOffSubscription(int subscriptionId);
        List<SubscriptionResponse> GetUserSubscriptions(int userId);
        List<SubscriptionResponse> GetSubscriberWithFilter(string searchKeyword, string type);
        SubscriptionResponse GetSingleSubscription(int subsId);
    }
}
