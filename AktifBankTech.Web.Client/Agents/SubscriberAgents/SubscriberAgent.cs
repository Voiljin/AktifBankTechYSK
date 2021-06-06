using AktifBankTech.Business.Commons.Models.CommonModels;
using AktifBankTech.Business.Commons.Models.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AktifBankTech.Web.Client.Agents.SubscriberAgents
{
    public class SubscriberAgent
    {
        public static Token<List<SubscriptionResponse>> GetUserSubscriptions(SubscriptionRequest model)
        {
            return Agent<List<SubscriptionResponse>, SubscriptionRequest>.Instance.CallApi(new RequestToken<SubscriptionRequest> { Filter = model }, "POST", "subscription/GetUserSubscriptions", true);
        }

        public static Token<bool> CreateSubscriber(InsertSubscriptionRequest model)
        {
            return Agent<bool, InsertSubscriptionRequest>.Instance.CallApi(new RequestToken<InsertSubscriptionRequest> { Filter = model }, "POST", "subscription/CreateSubscriber", true);
        }

        public static Token<List<SubscriptionResponse>> GetSubscriberWithFilter(SubscriptionRequest model)
        {
            return Agent<List<SubscriptionResponse>, SubscriptionRequest>.Instance.CallApi(new RequestToken<SubscriptionRequest> { Filter = model }, "POST", "subscription/GetSubscriberWithFilter", true);
        }

        public static Token<bool> TurnOffSubscription(UpdateSubscriptionRequest model)
        {
            return Agent<bool, UpdateSubscriptionRequest>.Instance.CallApi(new RequestToken<UpdateSubscriptionRequest> { Filter = model }, "POST", "subscription/TurnOffSubscription", true);
        }
    }
}