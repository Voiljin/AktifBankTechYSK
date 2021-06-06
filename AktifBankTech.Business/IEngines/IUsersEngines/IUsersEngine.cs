using AktifBankTech.Business.Commons.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.IEngines.IUsersEngines
{
    public interface IUsersEngine
    {
        UserResponse Authenticate(string tcNo, string password, bool isAdminPage);
        UserResponse GetUserWithTcNo(string tcNo);
        UserResponse InsertUser(string firstName, string lastName, string tcNo, string taxNumber);
        bool UpdateUser(int userId, string taxNumber);
    }
}
