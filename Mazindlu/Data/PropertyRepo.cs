using Mazindlu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mazindlu.Data
{
    public class PropertyRepo //: IPropertyRepo
    {
        private Dictionary<int, Property> properties;

        public Dictionary<int, Property> Properties
        {
            get { return properties; }
            set { properties = value; }
        }


        public PropertyRepo()
        {
            properties = new Dictionary<int, Property>();
        }
        
        bool CreateProperty()
        {
            throw new NotImplementedException();
        }

        bool DeleteProperty(int id)
        {
            throw new NotImplementedException();
        }

        Dictionary<int, Property> GetProperties()
        {
            throw new NotImplementedException();
        }

        Property GetProperty(int id)
        {
            throw new NotImplementedException();
        }

        bool UpdateProperty()
        {
            throw new NotImplementedException();
        }
    }
}
