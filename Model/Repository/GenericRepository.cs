using System.Collections.Generic;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using System.Data.Linq;
using Model.Models;

namespace Model.Repository
{
    public class GenericRepository<TEntity> : DataConnection, IGenericRepository<TEntity> where TEntity: Entity
    {
        
        public GenericRepository(LinqToDbConnectionOptions<AppDataConnection> options)
            :base(options)
        {

        }
        
        public void Insert(TEntity tEntity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TEntity> GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(long id, TEntity tEntity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}