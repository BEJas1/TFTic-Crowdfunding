using System.Collections.Generic;

namespace COMMON.Crowdfunding.Repositories
{
    public interface IUserRepository<TObject, TId> where TObject : class
    {

        public TObject? Login(string email, string password);

        public TId Register(TObject user, bool isAdmin = false);

        public IEnumerable<TObject> GetByActive();

        public TObject? GetById(TId id);

        public bool Update(TId id, string currentPassword, string? newEmail, string? newPassword);

        public bool Delete(TId id);
        
    }
}