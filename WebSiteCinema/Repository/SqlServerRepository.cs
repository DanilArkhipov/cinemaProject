using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SqlServerRepository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        private string connectionString = "Server=LAPTOP-CJH5JFI4\\SQLEXPRESS;Database=CinemaDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        
        async public Task InsertAsync(TEntity tEntity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = string.Format(
                    "INSERT INTO {0}({1})VALUES ({2});",
                    tEntity.GetType().Name,
                    Converter<TEntity>.GetNotNullFieldsNamesString(tEntity),
                    Converter<TEntity>.GetNotNullFieldsValuesString(tEntity));

                await connection.OpenAsync();
                SqlCommand cmd = new SqlCommand(command.ToString(),connection);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        async public Task InsertAsync(IEnumerable<TEntity> tEntity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var tEntityArr = tEntity.ToArray();
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(
                    "INSERT INTO {0}({1})VALUES"
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

        async public Task<IEnumerable<TEntity>> GetByIdAsync(long id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                TEntity tEntity;
                string command = string.Format(
                    "SELECT * FROM {0} WHERE {0}.id = {1}",
                    typeof(TEntity).Name,
                    id);
                await connection.OpenAsync();
                var cmd = new SqlCommand(command,connection);
                var reader = await cmd.ExecuteReaderAsync();
                return await Converter<TEntity>.SqlDataReaderToTEntity(reader);
            }
        }

        async public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                TEntity tEntity;
                string command = string.Format(
                    "SELECT * FROM {0};",
                    typeof(TEntity).Name);
                await connection.OpenAsync();
                var cmd = new SqlCommand(command,connection);
                var reader = await cmd.ExecuteReaderAsync();
                return await Converter<TEntity>.SqlDataReaderToTEntity(reader);
            }
        }

        async public void UpdateAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        async public Task DeleteAsync(long id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String cmd = string.Format(
                    "DELETE FROM {0} WHERE {0}.id = {1};",
                    typeof(TEntity).Name,
                    id);
                connection.OpenAsync();
                var command = new SqlCommand(cmd,connection);
                command.ExecuteNonQueryAsync();
            }
        }
    }
}