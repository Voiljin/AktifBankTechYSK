using AktifBankTech.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Interfaces.RolesInterfaces
{
    public interface IRolesRepository : IRepositoryBase<Role>
    {
        IQueryable<Role> GetAllRoles();
    }
}
