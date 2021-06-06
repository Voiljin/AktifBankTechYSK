using AktifBankTech.Data.Entities;
using AktifBankTech.Data.Interfaces.RolesInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Repositories.RolesRepositories
{
    public class RolesRepository : RepositoryBase<Role>, IRolesRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Role> _dbSet;

        public RolesRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Role>();
        }

        public IQueryable<Role> GetAllRoles()
        {
            return _dbSet.Where(x => x.Id > 0);
        }
    }
}
