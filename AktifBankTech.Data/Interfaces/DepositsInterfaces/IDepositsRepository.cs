using AktifBankTech.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Interfaces.DepositsInterfaces
{
    public interface IDepositsRepository : IRepositoryBase<Deposit>
    {
        IQueryable<Deposit> GetSubscriptionDeposits(int subsId);
    }
}
