using AktifBankTech.Business.Commons.Models.CommonModels;
using AktifBankTech.Data.Entities;
using AktifBankTech.Data.Interfaces.InvoicesInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Repositories.InvoicesRepositories
{
    public class InvoicesRepository : RepositoryBase<Invoice>, IInvoicesRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Invoice> _dbSet;

        public InvoicesRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Invoice>();
        }

        //Faturaları getir (Aboneliğe ait) 
        public IQueryable<Invoice> GetInvoicesFilter(int subscriptionId, string invoiceStatus)
        {
            var queryPredicate = PredicateBuilder.BaseAnd<Invoice>();

            queryPredicate = queryPredicate.And(x => x.SubscriptionId == subscriptionId);

            if (!String.IsNullOrEmpty(invoiceStatus))
            {
                queryPredicate = queryPredicate.And(x => x.Status == invoiceStatus);
            }

            return _dbSet.Where(queryPredicate);
        }
    }
}
