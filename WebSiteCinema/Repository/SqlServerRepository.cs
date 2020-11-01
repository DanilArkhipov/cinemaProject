using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository
{
    public class SqlServerRepository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        private string connectionString = "Server=LAPTOP-CJH5JFI4\\SQLEXPRESS;Database=CinemaDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        
        async public void Create(TEntity tEntity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var type = tEntity.GetType();
                var fields = type.GetFields();
                var command = new StringBuilder();
                command.Append("INSERT INTO " + type.Name + "(");
                for (int i = 0; i < fields.Length; i++)
                {
                    command.Append(fields[i].Name);
                    if (i != fields.Length - 1) command.Append(",");
                    else command.Append(")");
                }

                command.Append("VALUES(");
                for (int i = 0; i < fields.Length; i++)
                {
                    if (fields[i].FieldType == string.Empty.GetType())
                    {
                        command.Append("'" + fields[i].GetValue(tEntity) + "'");
                    }
                    else command.Append(fields[i].GetValue(tEntity));

                    if (i != fields.Length - 1) command.Append(",");
                    else command.Append(");");
                }

                await connection.OpenAsync();
                SqlCommand cmd = new SqlCommand(command.ToString(),connection);
                cmd.ExecuteNonQuery();
            }
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