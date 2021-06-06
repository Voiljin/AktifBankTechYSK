using AktifBankTech.Business.Commons.Models.CommonModels;
using AktifBankTech.Business.Commons.Models.UserModels;
using AktifBankTech.Business.IEngines.IUsersEngines;
using AktifBankTech.Data.Entities;
using AktifBankTech.Data.Interfaces.RolesInterfaces;
using AktifBankTech.Data.Interfaces.UsersInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.Engines.UsersEngines
{
    public class UsersEngine : BusinessEngineBase, IUsersEngine
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IRolesRepository _rolesRepository;

        public UsersEngine(IUsersRepository userRepository, IRolesRepository rolesRepository)
        {
            _usersRepository = userRepository;
            _rolesRepository = rolesRepository;
        }

        //Login
        public UserResponse Authenticate(string tcNo, string password, bool isAdminPage)
        {
            var user = _usersRepository.Authenticate(tcNo, password, isAdminPage);
            return Mapper.Map<UserResponse>(user.SingleOrDefault());
        }

        //User ekle
        public UserResponse InsertUser(string firstName, string lastName, string tcNo, string taxNumber)
        {
            InsertUserRequest req = new InsertUserRequest()
            {
                FirstName = firstName,
                LastName = lastName,
                TCNo = tcNo,
                TaxNumber = taxNumber,
                Password = "asdf",
                RoleId = _rolesRepository.GetAllRoles().Where(x => x.RoleName == StaticParameters.RoleUser).FirstOrDefault().Id,
                IsActive = true
            };

            var insertUser = _usersRepository.Add(Mapper.Map<User>(req));
            _usersRepository.SaveChanges();

            return Mapper.Map<UserResponse>(insertUser);
        }

        public bool UpdateUser(int userId, string taxNumber)
        {
            var getUser = _usersRepository.Get(userId);
            if (getUser == null) throw new Exception("User bulunamadı");

            getUser.TaxNumber = taxNumber;

            _usersRepository.Update(getUser);
            _usersRepository.SaveChanges();

            return true;
        }

        //TC Numarasına göre useri getir
        public UserResponse GetUserWithTcNo(string tcNo)
        {
            var user = _usersRepository.GetUserWithTcNo(tcNo);
            return Mapper.Map<UserResponse>(user);
        }


    }
}
