using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Mazindlu.Model
{
    public class PropertyProviderPicture
    {
        [Key]
        public ushort Id { get; set; }

        [Required]
        public string URI { get; set; }
    }
}
