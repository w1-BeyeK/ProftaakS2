using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Attributes;
using Webapp.Models.Data;
using Webapp.Models.Enums;

namespace Webapp.Parsers
{
    public class DataRowParser : IParser
    {
        protected T GetObject<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public object Parse<T>(object raw) where T : Entity
        {
            T result = GetObject<T>();

            DataRow dr = (raw as DataRow);
            foreach (DataColumn col in dr.Table.Columns)
            {
                if (result.HasProperty(col.ColumnName))
                {
                    if (dr[col] is DBNull)
                        continue;

                    Property[] prop = (Property[])Attribute.GetCustomAttributes(result.GetPropertyByName(col.ColumnName), typeof(Property));

                    if (result.HasProperty(col.ColumnName) || prop?[0].PropertyName == col.ColumnName)
                    {
                        DataType type = prop.Length > 0 ? prop[0].DataType : DataType.Character;
                        object value;
                        switch (type)
                        {
                            case DataType.DateTime:
                                value = DateTime.Parse(dr[col].ToString());
                                break;
                            default:
                                value = dr[col];
                                break;
                        }
                        result.SetPropertyByName(col.ColumnName, value);
                    }
                }
            }

            return result;
        }

        public bool TryParse<T>(object raw, out T result) where T : Entity
        {
            try
            {
                result = (T)Parse<T>(raw);
                return true;
            }
            catch (Exception e)
            {
                result = null;
                return false;
            }
        }
    }
}
