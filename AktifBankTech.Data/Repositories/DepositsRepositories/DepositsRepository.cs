using AktifBankTech.Data.Entities;
using AktifBankTech.Data.Interfaces.DepositsInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Repositories.DepositsRepositories
{
    public class DepositsRepository : RepositoryBase<Deposit>, IDepositsRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Deposit> _dbSet;

        public DepositsRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Deposit>();
        }

        public IQueryable<Deposit> GetSubscriptionDeposits(int subsId)
        {
            return _dbSet.Where(x => x.SubscriptionId == subsId);
        }
    }
}
