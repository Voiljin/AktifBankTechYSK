using AktifBankTech.Business.Commons.Models.InvoiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.IEngines.IInvoicesEngines
{
    public interface IInvoicesEngine
    {
        InvoiceResponse PayInvoice(UpdateInvoiceRequest request);
        List<InvoiceResponse> GetInvoicesFilter(int subscriptionId, string invoiceStatus);
    }
}
