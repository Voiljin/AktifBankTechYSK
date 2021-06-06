using AktifBankTech.Business.Commons.Models.CommonModels;
using AktifBankTech.Data.Entities;
using AktifBankTech.Data.Interfaces.UsersInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Repositories.UsersRepositories
{
    public class UsersRepository : RepositoryBase<User>, IUsersRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<User> _dbSet;

        public UsersRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<User>();
        }

        public IQueryable<User> Authenticate(string tcNo, string password, bool isAdminPage)
        {
            if (isAdminPage)
            {
                return _dbSet.Where(c => c.TCNo == tcNo && c.Password == password && c.IsActive == true && c.Role.RoleName == StaticParameters.RoleAdmin);
            }
            else
            {
                return _dbSet.Where(c => c.TCNo == tcNo && c.Password == password && c.IsActive == true && c.Role.RoleName == StaticParameters.RoleUser);
            } 
        }

        public User GetUserWithTcNo(string tcNo)
        {
            return _dbSet.Where(c => c.TCNo == tcNo).FirstOrDefault();
        }
    }
}
