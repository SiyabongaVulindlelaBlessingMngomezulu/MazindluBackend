//using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mazindlu.Model
{
    public class Message
    {
        [Key]
        public ushort Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        //[Email]
        public string Email{ get; set; }
    }
}
