using System.Collections.Generic;

namespace COMMON.Crowdfunding.Repositories
{
    public interface IRepository<TObject, TId> where TObject : class
    {
        public IEnumerable<TObject> Get();

        public TObject? GetById(TId id);

        public TId Insert(TObject newData);

        public bool Update(TId id, TObject newData);

        public bool Delete(TId id);
    }
}