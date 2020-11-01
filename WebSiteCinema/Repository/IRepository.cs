using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task InsertAsync(TEntity tEntity);
        Task InsertAsync(IEnumerable<TEntity> tEntity);
        
        Task<IEnumerable<TEntity>> GetByIdAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task UpdateAsync(long id,TEntity tEtity);

        Task DeleteAsync(long id);
    }
}