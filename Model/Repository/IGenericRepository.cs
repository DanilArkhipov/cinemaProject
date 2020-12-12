using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Models;

namespace Model.Repository
{
    public interface IGenericRepository<TEntity> where TEntity:Entity
    {
        void Insert(TEntity tEntity);

        IEnumerable<TEntity> GetById(long id);
        IEnumerable<TEntity> GetAll();

        void Update(long id,TEntity tEntity);

        void Delete(long id);
    }
}