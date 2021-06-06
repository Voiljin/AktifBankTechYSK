using AktifBankTech.Business.Commons.Models.SubscriptionTypeModels;
using AktifBankTech.Business.IEngines.ISubscriptionTypesEngines;
using AktifBankTech.Data.Interfaces.SubscriptionTypesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Engines.SubscriptionTypesEngines
{
    public class SubscriptionTypesEngine : BusinessEngineBase, ISubscriptionTypesEngine
    {
        private readonly ISubscriptionTypesRepository _subscriptionTypesRepository;

        public SubscriptionTypesEngine(ISubscriptionTypesRepository subscriptionTypesRepository)
        {
            _subscriptionTypesRepository = subscriptionTypesRepository;
        }

        public List<SubscriptionTypeResponse> GetAllSubscriptionTypes()
        {
            var getTypes = _subscriptionTypesRepository.GetAllSubscriptionTypes();

            return Mapper.Map<List<SubscriptionTypeResponse>>(getTypes);
        }
    }
}
