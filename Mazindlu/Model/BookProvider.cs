using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mazindlu.Model
{
    public class BookProvider: User
    {
        public BookProvider()
        {
            books = new LinkedList<Book>();
        }
        private LinkedList<Book> books;

        public LinkedList<Book> Books
        {
            get { return books; }
            set { books = value; }
        }
        
        private LinkedList<BookProviderPicture> bookProviderPictures;

        public LinkedList<BookProviderPicture> BookProviderPictures
        {
            get { return bookProviderPictures; }
            set { bookProviderPictures = value; }
        }


    }
}
