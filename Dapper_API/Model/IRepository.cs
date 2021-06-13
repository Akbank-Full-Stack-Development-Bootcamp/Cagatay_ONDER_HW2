using System.Collections.Generic;

namespace DapperAPI.Model
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity t);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Delete(int id);
        void Update(TEntity t);
    }
}