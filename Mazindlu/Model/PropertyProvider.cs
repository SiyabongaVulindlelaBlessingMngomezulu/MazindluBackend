using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Mazindlu.Model
{
    public class PropertyProvider//: User
    {
        private LinkedList<Property> properties;


       // [BsonElement("Properties")]
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

        public PropertyProvider() //: base()       
        {    
            properties = new LinkedList<Property>();
            propertyProviderPictures = new LinkedList<PropertyProviderPicture>();
        }
        //[BsonId()]
        public ushort Id { get; set; }

        //[BsonElement("Name")]
        public string Name { get; set; }
        //[BsonElement("Surname")]
        public string Surname { get; set; }
        //[BsonElement("Email")]
        public string Email { get; set; }
        [Required]
        //[BsonElement("Password")]
        public string Password { get; set; }
        //[BsonElement("ShortBio")]
        public string ShortBio { get; set; }


    }
}
