using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
