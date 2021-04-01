using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mazindlu.Model
{
    public class User
    {
        public User()
        {
            Console.WriteLine("Say it laaaud");
        }

        [Key]
        public ushort Id { get; set; }

        public string Name{ get; set; }

        public string  Surname{ get; set; }

        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string ShortBio { get; set; }

        //public Picture ProfilePic { get; set; }
        







    }
}
