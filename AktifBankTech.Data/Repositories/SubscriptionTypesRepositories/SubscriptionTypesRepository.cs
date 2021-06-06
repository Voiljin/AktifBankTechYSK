using AktifBankTech.Data.Entities;
using AktifBankTech.Data.Interfaces.SubscriptionTypesInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Repositories.SubscriptionTypesRepositories
{
    public class SubscriptionTypesRepository : RepositoryBase<SubscriptionType>, ISubscriptionTypesRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<SubscriptionType> _dbSet;

        public SubscriptionTypesRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<SubscriptionType>();
        }

        public IQueryable<SubscriptionType> GetAllSubscriptionTypes()
        {
            return _dbSet.Where(x => x.Id > 0);
        }
    }
}
