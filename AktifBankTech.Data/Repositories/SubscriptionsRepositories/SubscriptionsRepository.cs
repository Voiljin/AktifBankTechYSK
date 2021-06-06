using AktifBankTech.Business.Commons.Models.CommonModels;
using AktifBankTech.Data.Entities;
using AktifBankTech.Data.Interfaces.SubscriptionsInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Repositories.SubscriptionsRepositories
{
    public class SubscriptionsRepository : RepositoryBase<Subscription>, ISubscriptionsRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Subscription> _dbSet;

        public SubscriptionsRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Subscription>();
        }


        #region User Ekranı
        //Kullanıcı ekranı abone bilgileri
        public IQueryable<Subscription> GetUserSubscriptions(int userId)
        {
            return _dbSet.Where(x => x.UserId == userId);
        }
        #endregion

        #region Admin Ekranı
        public IQueryable<Subscription> GetSubscriberWithFilter(string searchKeyword, string type)
        {
            switch (type)
            {
                case StaticParameters.SubscribeTypeBireysel:
                    return _dbSet.Where(x => x.User.TCNo == searchKeyword && x.SubscriptionType.TypeName == type);
                case StaticParameters.SubscribeTypeTuzel:
                    return _dbSet.Where(x => x.User.TaxNumber == searchKeyword && x.SubscriptionType.TypeName == type);
                default:
                    return _dbSet.Where(x => x.Id > 0);
            }
        }
        #endregion

    }
}
