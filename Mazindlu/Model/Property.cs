using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotationsExtensions;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mazindlu.Model
{
    public class Property
    {
        public Property()
        {
            pictures = new LinkedList<PropertyPicture>();
        }
        [Key]
        public ushort Id{ get; set; }

        [Required]
        public string  Name{ get; set; }


        private LinkedList<PropertyPicture> pictures;

        public LinkedList<PropertyPicture> Pictures
        {
            get { return pictures; }
            set { pictures = value; }
        }

        public string  Description{ get; set; }

        public float  Price{ get; set; }







    }
}
