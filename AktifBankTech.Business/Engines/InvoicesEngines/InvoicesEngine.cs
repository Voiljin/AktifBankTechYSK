using AktifBankTech.Business.Commons.Models.CommonModels;
using AktifBankTech.Business.Commons.Models.InvoiceModels;
using AktifBankTech.Business.IEngines.IInvoicesEngines;
using AktifBankTech.Data.Interfaces.InvoicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Engines.InvoicesEngines
{
    public class InvoicesEngine : BusinessEngineBase, IInvoicesEngine
    {
        private readonly IInvoicesRepository _invoicesRepository;

        public InvoicesEngine(IInvoicesRepository invoicesRepository)
        {
            _invoicesRepository = invoicesRepository;
        }

        //Fatura ödeme işlemi, status update ediliyor.
        public InvoiceResponse PayInvoice(UpdateInvoiceRequest request)
        {
            var getInvoice = _invoicesRepository.Get(request.Id);
            if (getInvoice == null) throw new Exception("Ödenmek istenen fatura bilgisi bulunamadı");
            if (getInvoice.Status != StaticParameters.InvoiceStatusActive) throw new Exception("Aktif olmayan bir faturanın ödeme işlemi yapılamaz.");

            getInvoice.Status = StaticParameters.InvoiceStatusInActive;
            _invoicesRepository.Update(getInvoice);
            _invoicesRepository.SaveChanges();

            return Mapper.Map<InvoiceResponse>(getInvoice);
        }

        //Ödenmemiş faturaları getir (Aboneliğe ait - Admin sorgulama yapıyor)
        public List<InvoiceResponse> GetInvoicesFilter(int subscriptionId, string invoiceStatus)
        {
            var getInvoices = _invoicesRepository.GetInvoicesFilter(subscriptionId, invoiceStatus);

            return Mapper.Map<List<InvoiceResponse>>(getInvoices);
        }
    }
}
