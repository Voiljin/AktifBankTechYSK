using AktifBankTech.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Interfaces.UsersInterfaces
{
    public interface IUsersRepository : IRepositoryBase<User>
    {
        IQueryable<User> Authenticate(string tcNo, string password, bool isAdminPage);
        User GetUserWithTcNo(string tcNo);
    }
}
