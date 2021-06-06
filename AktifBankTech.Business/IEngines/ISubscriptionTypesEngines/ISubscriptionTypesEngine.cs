using AktifBankTech.Business.Commons.Models.SubscriptionTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.IEngines.ISubscriptionTypesEngines
{
    public interface ISubscriptionTypesEngine
    {
        List<SubscriptionTypeResponse> GetAllSubscriptionTypes();
    }
}
