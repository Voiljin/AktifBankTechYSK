using AktifBankTech.Business.Commons.Models.CommonModels;
using AktifBankTech.Business.Commons.Models.DepositModels;
using AktifBankTech.Business.IEngines.IDepositsEngines;
using AktifBankTech.Data.Entities;
using AktifBankTech.Data.Interfaces.DepositsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Engines.DepositsEngines
{
    public class DepositsEngine : BusinessEngineBase, IDepositsEngine
    {
        private readonly IDepositsRepository _depositsRepository;

        public DepositsEngine(IDepositsRepository depositsRepository)
        {
            _depositsRepository = depositsRepository;
        }

        //yeni abonelikte depozito alınıyor
        public bool InsertDeposit(int subsId)
        {
            InsertDepositRequest request = new InsertDepositRequest()
            {
                SubscriptionId = subsId,
                Status = StaticParameters.DepositPaid,
                Value = 250
            };

            var insert = _depositsRepository.Add(Mapper.Map<Deposit>(request));
            _depositsRepository.SaveChanges();

            return true;
        }

        //depozitolar müşteriye iade ediliyor.
        public void ReturnDeposits(int subscriptionId)
        {
            _depositsRepository.UpdateAll(x => x.SubscriptionId == subscriptionId, r => new Deposit() { Status = StaticParameters.DepositReturned });
        }
    }
}
