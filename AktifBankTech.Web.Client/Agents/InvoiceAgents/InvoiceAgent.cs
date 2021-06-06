using AktifBankTech.Business.Commons.Models.CommonModels;
using AktifBankTech.Business.Commons.Models.InvoiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AktifBankTech.Web.Client.Agents.InvoiceAgents
{
    public class InvoiceAgent
    {
        public static Token<List<InvoiceResponse>> GetSubscriberInvoices(InvoiceRequest model)
        {
            return Agent<List<InvoiceResponse>, InvoiceRequest>.Instance.CallApi(new RequestToken<InvoiceRequest> { Filter = model }, "POST", "invoice/GetSubscriberInvoices", true);
        }

        public static Token<InvoiceResponse> PayInvoice(UpdateInvoiceRequest model)
        {
            return Agent<InvoiceResponse, UpdateInvoiceRequest>.Instance.CallApi(new RequestToken<UpdateInvoiceRequest> { Filter = model }, "POST", "invoice/PayInvoice", true);
        }
    }
}