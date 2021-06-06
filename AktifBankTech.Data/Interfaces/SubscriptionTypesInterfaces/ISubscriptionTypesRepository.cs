using AktifBankTech.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Interfaces.SubscriptionTypesInterfaces
{
    public interface ISubscriptionTypesRepository : IRepositoryBase<SubscriptionType>
    {
        IQueryable<SubscriptionType> GetAllSubscriptionTypes();
    }
}
