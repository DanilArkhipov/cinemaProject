using System.Collections.Generic;

namespace Repository
{
    public class SqlServerRepository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        public void Create(TEntity tEntity)
        {
            throw new System.NotImplementedException();
        }

        public void Create(IEnumerable<TEntity> tEntity)
        {
            throw new System.NotImplementedException();
        }

        public TEntity GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TEntity> GetAllById(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}