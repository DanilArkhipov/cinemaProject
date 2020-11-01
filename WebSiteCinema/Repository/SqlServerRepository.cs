using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        async public void Insert(IEnumerable<TEntity> tEntity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var tEntityArr = tEntity.ToArray();
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("INSERT INTO {0}({1})VALUES"
                    ,tEntityArr[0].GetType().Name,
                    Converter<TEntity>.GetNotNullFieldsNamesString(tEntityArr[0]));
                for (int i = 0; i < tEntityArr.Length; i++)
                {
                    if (i != tEntityArr.Length - 1)
                    {
                        sb.AppendFormat("({0}),", Converter<TEntity>.GetNotNullFieldsValuesString(tEntityArr[i]));
                    }
                    else sb.AppendFormat("({0});", Converter<TEntity>.GetNotNullFieldsValuesString(tEntityArr[i]));
                }

                var command = sb.ToString();
                await connection.OpenAsync();
                SqlCommand cmd = new SqlCommand(command.ToString(),connection);
                await cmd.ExecuteNonQueryAsync();
            }
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