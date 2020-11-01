using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository
{
    public class SqlServerRepository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        private string connectionString = "Server=LAPTOP-CJH5JFI4\\SQLEXPRESS;Database=CinemaDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        
        async public void Insert(TEntity tEntity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = string.Format("INSERT INTO {0}({1})VALUES ({2});",
                    tEntity.GetType().Name,
                    Converter<TEntity>.GetNotNullFieldsNamesString(tEntity),
                    Converter<TEntity>.GetNotNullFieldsValuesString(tEntity));

                await connection.OpenAsync();
                SqlCommand cmd = new SqlCommand(command.ToString(),connection);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public void Insert(IEnumerable<TEntity> tEntity)
        {
            throw new System.NotImplementedException();
        }

        public TEntity GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
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