using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Webapp.Models.Attributes;

namespace Webapp.Models.Data
{
    public class Entity
    {
        public PropertyInfo GetPropertyByName(string propName, bool checkProperty = false)
        {
            var props = GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                if (prop.Name.ToLower() == propName.ToLower() ||
                    (checkProperty && Attribute.IsDefined(prop, typeof(Property)) &&
                    ((Property)Attribute.GetCustomAttributes(prop, typeof(Property))[0]).PropertyName == propName))
                    return prop;
            }
            return null;
        }

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
