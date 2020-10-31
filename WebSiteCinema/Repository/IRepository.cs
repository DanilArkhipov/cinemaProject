using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        void Create(TEntity tEntity);
        void Create(IEnumerable<TEntity> tEntity);
        
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAllById(long id);

        void Update(long id);

        void Delete(long id);
    }
}