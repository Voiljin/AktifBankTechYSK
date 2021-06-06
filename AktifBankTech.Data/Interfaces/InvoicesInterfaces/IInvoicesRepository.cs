using AktifBankTech.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Interfaces.InvoicesInterfaces
{
    public interface IInvoicesRepository : IRepositoryBase<Invoice>
    {
        IQueryable<Invoice> GetInvoicesFilter(int subscriptionId, string invoiceStatus);
    }
}
