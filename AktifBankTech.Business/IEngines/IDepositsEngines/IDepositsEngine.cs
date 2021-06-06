using AktifBankTech.Business.Commons.Models.DepositModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.IEngines.IDepositsEngines
{
    public interface IDepositsEngine
    {
        bool InsertDeposit(int subsId);
        void ReturnDeposits(int subscriptionId);
    }
}
