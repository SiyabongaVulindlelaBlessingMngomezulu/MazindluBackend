using System;
//using DataAnnotationsExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mazindlu.Model
{
    public class Book
    {
        [Key]
        public ushort Id{ get; set; }
        [Required]
        public string Title { get; set; }
       [Required]
        public string Format { get; set; }

        private LinkedList<BookPicture> bookPictures;

        public LinkedList<BookPicture> BookPictures 
        {
            get { return bookPictures; }
            set { bookPictures = value; }
        }

        public string  Author{ get; set; }

        public string  ISBN{ get; set; }
        [Required]
        public float Price { get; set; }

        public string ContactNo{ get; set; }
    }
}
