using AktifBankTech.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Interfaces.SubscriptionsInterfaces
{
    public interface ISubscriptionsRepository : IRepositoryBase<Subscription>
    {   
        IQueryable<Subscription> GetUserSubscriptions(int userId);
        IQueryable<Subscription> GetSubscriberWithFilter(string searchKeyword, string type);
    }
}
