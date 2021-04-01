using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mazindlu.Model
{
    public class PropertyProvider: User
    {
        private LinkedList<Property> properties;
       
        public LinkedList<Property> Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        private LinkedList<PropertyProviderPicture> propertyProviderPictures;

        public LinkedList<PropertyProviderPicture> PropertyProviderPictures
        {
            get { return propertyProviderPictures; }
            set { propertyProviderPictures = value; }
        }

        public PropertyProvider() : base()       
        {    
            properties = new LinkedList<Property>();
            propertyProviderPictures = new LinkedList<PropertyProviderPicture>();
        }


    }
}
