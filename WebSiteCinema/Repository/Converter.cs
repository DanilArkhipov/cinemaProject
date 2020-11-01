using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class Converter<TEntity> where TEntity:class
    {
        private static FieldInfo[] GetNotNullFields(TEntity tEntity)
        {
            var type = tEntity.GetType();
            return type.GetFields().Where(x => x.GetValue(tEntity) != null&&x.Name!="id").ToArray();
        }

        public static string[] GetNotNullFieldsNames(TEntity tEntity)
        {
            return GetNotNullFields(tEntity).Select(x => x.Name).ToArray();
        }

        public static string GetNotNullFieldsNamesString(TEntity tEntity)
        {
            var arr = GetNotNullFields(tEntity);
            var sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    sb.AppendFormat("{0},", arr[i].Name);
                }
                else sb.Append(arr[i].Name);
            }
            return sb.ToString();
        }

        public static string GetNotNullFieldsValuesString(TEntity tEntity)
        {
            var arr = GetNotNullFields(tEntity);
            var sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    if (arr[i].FieldType == string.Empty.GetType())
                    {
                        sb.AppendFormat("'{0}',", arr[i].GetValue(tEntity));
                    }
                    else 
                        sb.AppendFormat("{0},", arr[i].GetValue(tEntity));
                }
                else if (arr[i].FieldType == string.Empty.GetType())
                {
                    sb.AppendFormat("'{0}'", arr[i].GetValue(tEntity));
                }
                else 
                    sb.AppendFormat("{0}", arr[i].GetValue(tEntity));
            }
            return sb.ToString();
        }

        public static TEntity CreateEntity(object[] data)
        {
            var type = typeof(TEntity);
            var types = type.GetFields().Select(x => x.FieldType).ToArray();
            var constructor = type.GetConstructor(types);
            var res = (TEntity)constructor.Invoke(data);
            return res;
        }

        public static int GetFieldsCount()
        {
            return typeof(TEntity).GetFields().Length;
        }

        async public static Task<IEnumerable<TEntity>> SqlDataReaderToTEntity(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                var res = new List<TEntity>();
                while (await reader.ReadAsync())
                {
                    var tmp = new object[Converter<TEntity>.GetFieldsCount()];
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (reader.GetValue(i) != DBNull.Value)
                        {
                            tmp[i] = reader.GetValue(i);
                        }
                        else tmp[i] = null;
                    }
                    res.Add(Converter<TEntity>.CreateEntity(tmp));
                }
                await reader.CloseAsync();
                return res;
            }
            else
            {
                reader.CloseAsync();
                return null;
            }
        }
    }
}