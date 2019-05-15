using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Entity
    {
        public Type GetPropertyType(string propName)
        {
            PropertyInfo prop = GetPropertyByName(propName);
            return prop.PropertyType;
        }

        public void SetPropertyByName(string propName, object value)
        {
            PropertyInfo prop = GetPropertyByName(propName);
            prop.SetValue(this, value);
        }

        public bool HasProperty(string propName)
        {
            PropertyInfo prop = GetPropertyByName(propName);

            return prop != null;
        }

        private PropertyInfo GetPropertyByName(string propName)
        {
            var props = GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                if (prop.Name.ToLower() == propName.ToLower())
                    return prop;
            }
            return null;
        }
    }
}
