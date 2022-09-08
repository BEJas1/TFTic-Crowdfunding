using BLL.Crowdfunding.Entities;
using COMMON.Crowdfunding.Repositories;
using D = DAL.Crowdfunding.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BLL.Crowdfunding.Handler;

namespace BLL.Crowdfunding.Services
{
    public class UserService : IUserRepository<User, Guid>
    {

        private readonly IUserRepository<D.User, Guid> _repository;

        public UserService(IUserRepository<D.User, Guid> repository)
        {
            _repository = repository;
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
            return _repository.Login(email, password).ToBLL();
        }

        public Guid Register(User user, bool isAdmin = false)
        {
            return _repository.Register(user.ToDAL(), isAdmin);
        }

        public bool Update(Guid id, string currentPassword, string? newEmail, string? newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
