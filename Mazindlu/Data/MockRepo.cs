using Mazindlu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// This is a template repo used primarily for testing data access using data structures residing in virtual memory.
namespace Mazindlu.Data
{
    public class MockRepo : IRepo
    {
        private Dictionary<int, BookProvider> bookProviders;
        #region
        public Dictionary<int, BookProvider> BookProviders
        {
            get { return bookProviders; }
            set { bookProviders = value; }
        }

        private Dictionary<int, PropertyProvider> propertyProviders;

        public Dictionary<int, PropertyProvider> PropertyProviders
        {
            get { return propertyProviders; }
            set { propertyProviders = value; }
        }

        private Dictionary<int, Property> properties;

        public Dictionary<int, Property> Properties
        {
            get { return properties; }
            set { properties = value; }
        }


        private Dictionary<int,Book> books;

        public Dictionary<int,Book> Books
        {
            get { return books; }
            set { books = value; }
        }

       

        public MockRepo()
        {          
            bookProviders = new Dictionary<int, BookProvider>();
            propertyProviders = new Dictionary<int, PropertyProvider>();
            properties = new Dictionary<int, Property>();
            books = new Dictionary<int, Book>();
           // pictures = new Dictionary<int, Picture>();
            this.bookProviders.Add(
                65452,

                  new BookProvider()
                  {
                      Id = 65452,
                      Email = "DarkAngel@gmail.com",
                      Password = "Manticore",
                      ShortBio = "I am not a machine",
                      BookProviderPictures = new LinkedList<BookProviderPicture>(),
                      Books = new LinkedList<Book>()
                  });
                  
            this.bookProviders.Add(
                65453, new BookProvider()
                {
                    Id = 65453,
                    Email = "Vee@gmail.com",
                    Password = "pass",
                    ShortBio = "This is me",
                    BookProviderPictures = new LinkedList<BookProviderPicture>(),
                    Books = new LinkedList<Book>()
                }
            );

            this.propertyProviders.Add(
                65452 , new PropertyProvider() { 
                    Id = 65452,
                    Email = "JanDuToit@gmail.com",
                    Password = "farm",
                    ShortBio = "Ek is n Boer",
                    PropertyProviderPictures = new LinkedList<PropertyProviderPicture>(),
                    Properties = new LinkedList<Property>()

                });

            this.propertyProviders.Add(
               7885, new PropertyProvider()
               {
                   Id = 7885,
                   Email = "TanieLouw@gmail.com",
                   Password = "MeinKinders",
                   ShortBio = "Ek is n ou meisie",
                   PropertyProviderPictures = new LinkedList<PropertyProviderPicture>(),
                   Properties = new LinkedList<Property>()
               });

            this.properties.Add(6765, new Property() { 
                Id =6765,
                Name = "Sheriff Hutton",
                Description = "A castle in North Yorkshire",
                Pictures = new LinkedList<PropertyPicture>(),
                Price = 10803.67f
            });

            this.properties.Add(8789, new Property()
            {
                Id = 8789,
                Name = "Bamburgh",
                Description = "A castle in Northumberland",
                Pictures = new LinkedList<PropertyPicture>(),
                Price = 11803.67f
            });

            this.books.Add(4563, new Book()
            {
                Id = 4563,
                Title = "Moby Dick",
                Format = "HardCopy",
                Author = "Herman Melville",
                ISBN = "87674776",
                Price = 58.50f,
                ContactNo = "0815657849"
            });

            this.books.Add(1979, new Book()
            {
                Id = 1979,
                Title = "A Storm of Swords",
                Format = "SoftCopy",
                Author = "George R.R Martin",
                ISBN = "9567567",
                Price = 38.50f,
                ContactNo = "0715657849"
            });

           /* this.pictures.Add(
                6557, new Picture(){Id = 6557, URI=@"Believe\me"}     
            );
            this.pictures.Add(
                8345, new Picture() { Id = 8345, URI = @"Believe\us" }
            );*/
        }

        public bool CreateBookProvider(BookProvider user)
        {
            bool result = false;
            var userType = user.GetType().ToString();            
            try
            {
                switch (userType)
                {
                    case "Mazindlu.Model.BookProvider":
                        bookProviders.Add(user.Id, user);
                        result = true;
                        break;

                    case "Mazindlu.Model.PropertyProvider":
                        bookProviders.Add(user.Id, user);
                        result = true;
                        break;

                    default: break;


                }
            }
            catch (Exception e)
            {
                return false;
            }
            return result;
        }

        public BookProvider GetBookProvider(string user_name, string pass_word)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBookProvider(int id)
        {
            bool success = false;
            if (bookProviders.ContainsKey(id))
            {
                bookProviders.Remove(id);
                success = true;
            }
            else{ 
                
            }
            return success;
        }

        public Dictionary<int, BookProvider> GetBookProviders()
        {
            
            return bookProviders;
        }

        public BookProvider GetBookProvider(int id)
        {
            BookProvider bp = null;
            ushort Id = (ushort)(id);

            bookProviders.TryGetValue(Id, out bp);
            return bp;            
        }

        public bool UpdateBookProvider(BookProvider user)
        {
            bool success = false;            
            var userType = user.GetType().ToString();           
            switch (userType)
            {
                case "Mazindlu.Model.BookProvider":
                    if (bookProviders.ContainsKey(user.Id))
                    {
                        bookProviders.Remove(user.Id);
                        bookProviders.Add(user.Id, user);
                        success = true;
                    }
                    break;

                case "Mazindlu.Model.PropertyProvider":
                    /*if (users.ContainsKey(user.Id))
                    {
                        users.Remove(user.Id);
                        users.Add(user.Id, user);
                        return true;
                    }
                    */
                    break;
                default:
                    break;
            }
            return success;
        }

        public Dictionary<int, Property> GetProperties()
        {
            return properties;
        }




        public PropertyProvider GetPropertyProvider(int id)
        {
            PropertyProvider pp = null;
            ushort Id = (ushort)(id);

            propertyProviders.TryGetValue(Id, out pp);
            return pp;
        }

       

        public void CreatePropertyProvider(PropertyProvider user)
        {
            propertyProviders.Add(user.Id,user);
        }

        public bool UpdatePropertyProvider(PropertyProvider user)
        {
            bool success = false;
            var userType = user.GetType().ToString();
            switch (userType)
            {

                case "Mazindlu.Model.PropertyProvider":
                    if (propertyProviders.ContainsKey(user.Id))
                    {
                        propertyProviders.Remove(user.Id);
                        propertyProviders.Add(user.Id, user);
                        return true;
                    }
                    
                    break;
                default:
                    break;
            }
            return success;
        }

        public bool DeletePropertyProvider(ushort id)
        {
            bool success = false;
            if (propertyProviders.ContainsKey(id))
            {
                propertyProviders.Remove(id);
                success = true;
            }
            else
            {

            }
            return success;
        }
        #endregion
        public Property GetProperty(int id)
        {
            Property prop = null;
            bool success = properties.TryGetValue(id, out prop);

            return prop;

        }

        public Dictionary<int, PropertyProvider> GetPropertyProviders()
        {
            return propertyProviders;
        }

        public bool CreateProperty(Property prop)
        {
           return properties.TryAdd(prop.Id, prop);
           
        }

        public bool UpdateProperty(Property prop)
        {
            bool success = false;
            Property p = null;
            if (properties.TryGetValue(prop.Id, out p)) {
                properties.Remove(prop.Id);
                properties.Add(prop.Id,prop);
                success = true;
            }
            return success; 
        }

        public bool DeleteProperty(int id)
        {
            bool success = false;
            Property p = null;
            if (properties.TryGetValue(id, out p))
            {
                properties.Remove(id);
                success = true;
            }
            return success; 
        }


        public Book GetBook(int id)
        {
            Book book = null;
            bool success = books.TryGetValue(id, out book);

            return book;

        }

        public Dictionary<int, Book> GetBooks()
        {
            return books;
        }

        public bool CreateBook(int id,Book book)
        {
            return books.TryAdd(book.Id, book);
        }

        public bool UpdateBook(int BookProviderId, Book book) {

            var result = ((book == null) || (BookProviderId  < 0))? false : true;
            return result;
        
        }

        public bool CreateBook(Book book)
        {
            // return books.TryAdd(book.Id, book);
            return true;
        }

        public bool UpdateBook(Book book)
        {
            bool success = false;
            Book b = null;
            if (books.TryGetValue(book.Id, out b))
            {
                books.Remove(book.Id);
                books.Add(book.Id, book);
                success = true;
            }
            return success;
        }

        public bool DeleteBook(int id)
        {
            bool success = false;
            Book b = null;
            if (books.TryGetValue(id, out b))
            {
                books.Remove(id);
                success = true;
            }
            return success;
        }

        BookPicture IRepo.GetBookPicture(int id)
        {
            throw new NotImplementedException();
        }

        Dictionary<int, BookPicture> IRepo.GetBookPictures()
        {
            throw new NotImplementedException();
        }

        bool IRepo.CreateBookPicture(int BookProviderId, BookPicture bookPicture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.UpdateBookPicture(BookPicture bookPicture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.DeleteBookPicture(int id)
        {
            throw new NotImplementedException();
        }

        PropertyPicture IRepo.GetPropertyPicture(int id)
        {
            throw new NotImplementedException();
        }

        Dictionary<int, PropertyPicture> IRepo.GetPropertyPictures()
        {
            throw new NotImplementedException();
        }

        bool IRepo.CreatePropertyPicture(PropertyPicture picture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.UpdatePropertyPicture(PropertyPicture picture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.DeletePropertyPicture(int id)
        {
            throw new NotImplementedException();
        }

        PropertyProviderPicture IRepo.GetPropertyProviderPicture(int id)
        {
            throw new NotImplementedException();
        }

        Dictionary<int, PropertyProviderPicture> IRepo.GetPropertyProviderPictures()
        {
            throw new NotImplementedException();
        }

        bool IRepo.CreatePropertyProviderPicture(PropertyProviderPicture picture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.UpdatePropertyProviderPicture(PropertyProviderPicture picture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.DeletePropertyProviderPicture(int id)
        {
            throw new NotImplementedException();
        }

        BookProviderPicture IRepo.GetBookProviderPicture(int id)
        {
            throw new NotImplementedException();
        }

        Dictionary<int, BookProviderPicture> IRepo.GetBookProviderPictures()
        {
            throw new NotImplementedException();
        }

        bool IRepo.CreateBookProviderPicture(int id, BookProviderPicture picture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.UpdateBookProviderPicture(BookProviderPicture picture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.DeleteBookProviderPicture(int id)
        {
            throw new NotImplementedException();
        }

        void IRepo.GetBookProviderPictureofUser(BookProvider bookProvider)
        {
            throw new NotImplementedException();
        }

        PropertyProvider IRepo.GetPropertyProvider(string username, string password)
        {
            throw new NotImplementedException();
        }

        IEnumerable<PropertyProvider> IRepo.GetPropertyProviders()
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepo.DeleteAllBookPictures(int id)
        {
            throw new NotImplementedException();
        }

        LinkedList<Property> IRepo.GetPropertiesOfPropertyProvider(PropertyProvider pp)
        {
            throw new NotImplementedException();
        }

        bool IRepo.CreatePropertyPicture(int propertyId, PropertyPicture picture)
        {
            throw new NotImplementedException();
        }

        /* 
         * bool IRepo.CreateBookPicture(BookPicture bookPicture)
         {
             throw new NotImplementedException();
         }
        */
    }
}
