using AktifBankTech.Business.IEngines.IRolesEngines;
using AktifBankTech.Data.Interfaces.RolesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Engines.RolesEngines
{
    public class RolesEngine : BusinessEngineBase, IRolesEngine
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesEngine(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
    }
}
