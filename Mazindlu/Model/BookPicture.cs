using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mazindlu.Model
{
    public class BookPicture
    {
        [Key]
        public ushort Id { get; set; }

        [Required]
        public string URI { get; set; }
    }
}
