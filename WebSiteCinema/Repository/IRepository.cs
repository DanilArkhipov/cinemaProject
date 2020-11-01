using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        void Insert(TEntity tEntity);
        void Insert(IEnumerable<TEntity> tEntity);
        
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();

        void Update(long id);

        void Delete(long id);
    }
}