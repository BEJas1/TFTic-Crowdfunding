using System;
using System.Collections.Generic;
using System.Linq;
using COMMON.Crowdfunding.Repositories;
using DAL.Crowdfunding.Entities;
using Microsoft.Extensions.Configuration;
using TOOLS.DbConnection;

using static DAL.Crowdfunding.Handler.Mapper;

namespace DAL.Crowdfunding.Services
{
    public class UserService : BaseService, IUserRepository<User, Guid>
    {

        public UserService(IConfiguration config) : base(config)
        {
            
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetByActive()
        {
            throw new NotImplementedException();
        }

        public User? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public User? Login(string email, string password)
        {
            Connection con = new Connection(_InvariantName, _ConnectionString);
            Command com = new Command("SP_User_Login", true);
            com.AddParameter("email", email);
            com.AddParameter("password", password);
            return con.ExecuteReader(com, ToUser).SingleOrDefault();
        }

        public Guid Register(User user, bool isAdmin = false)
        {
            Connection con = new Connection(_InvariantName, _ConnectionString);
            Command com = new Command(isAdmin ? "SP_User_Admin_Insert" : "SP_User_Registered_Insert", true);
            com.AddParameter("email", user.Email);
            com.AddParameter("firstname", user.FirstName);
            com.AddParameter("lastname", user.LastName);
            com.AddParameter("password", user.Password);
            return (Guid)con.ExecuteScalar(com);
        }

        public bool Update(Guid id, string currentPassword, string? newEmail, string? newPassword)
        {
            throw new NotImplementedException();
        }
    }
}