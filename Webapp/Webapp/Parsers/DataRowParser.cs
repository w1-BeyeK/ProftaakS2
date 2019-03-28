using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

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
                    result.SetPropertyByName(col.ColumnName, dr[col]);
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
