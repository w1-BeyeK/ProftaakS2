using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Enums;

namespace Webapp.Models.Attributes
{
    public class Property : Attribute
    {
        public string PropertyName { get; set; }
        public DataType DataType { get; set; }
        public Property(string propName = null, DataType type = DataType.Character)
        {
            PropertyName = propName;
            DataType = type;

        }
        public string GetValue()
        {
            return PropertyName;
        }
    }
}
