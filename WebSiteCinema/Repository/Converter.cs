using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Repository
{
    public static class Converter<TEntity> where TEntity:class
    {
        private static FieldInfo[] GetNotNullFields(TEntity tEntity)
        {
            var type = tEntity.GetType();
            return type.GetFields().Where(x => x.GetValue(tEntity) != null).ToArray();
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
    }
}