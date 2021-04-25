using Mazindlu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mazindlu.Data
{

    public interface IRepo
    {
        public BookProvider GetBookProvider(int id);
        public LinkedList<Property> GetPropertiesOfPropertyProvider(PropertyProvider pp);
        public PropertyProvider GetPropertyProvider(string username, string password);

        public BookProvider GetBookProvider(string user_name, string pass_word);

        public void GetBookProviderPictureofUser(BookProvider bookProvider);
        public Dictionary<int, BookProvider> GetBookProviders();

        public bool CreateBookProvider(BookProvider user);

        public bool UpdateBookProvider(BookProvider user);

        public bool DeleteBookProvider(int id);


        public PropertyProvider GetPropertyProvider(int id);
        public IEnumerable<PropertyProvider> GetPropertyProviders();

        public void CreatePropertyProvider(PropertyProvider user);

        public bool UpdatePropertyProvider(PropertyProvider user);

        public bool DeletePropertyProvider(ushort id);



        public Dictionary<int, Property> GetProperties();

        public Property GetProperty(int id);

        public bool CreateProperty(Property prop);

        public bool UpdateProperty(Property prop);

        public bool DeleteProperty(int id);


        public Book GetBook(int id);


        public Dictionary<int, Book> GetBooks();


        public bool CreateBook(int bookId, Book book);


        public bool CreateBook(Book book);

        public bool UpdateBook(Book book);


        public bool DeleteBook(int id);

        public Task<bool> DeleteAllBookPictures(int id);

        public bool UpdateBook(int BookProviderId, Book book);

        public BookPicture GetBookPicture(int id);


        public Dictionary<int, BookPicture> GetBookPictures();


        public bool CreateBookPicture(int BookProviderId, BookPicture bookPicture);


        public bool UpdateBookPicture(BookPicture bookPicture);


        public bool DeleteBookPicture(int id);




        public PropertyPicture GetPropertyPicture(int id);


        public Dictionary<int, PropertyPicture> GetPropertyPictures();


        public bool CreatePropertyPicture(PropertyPicture picture);

        public bool CreatePropertyPicture(int propertyId, PropertyPicture picture);

        public bool UpdatePropertyPicture(PropertyPicture picture);


        public bool DeletePropertyPicture(int id);



        public PropertyProviderPicture GetPropertyProviderPicture(int id);


        public Dictionary<int, PropertyProviderPicture> GetPropertyProviderPictures();


        public bool CreatePropertyProviderPicture(PropertyProviderPicture picture);

        public bool UpdatePropertyProviderPicture(PropertyProviderPicture picture);


        public bool DeletePropertyProviderPicture(int id);


        public BookProviderPicture GetBookProviderPicture(int id);


        public Dictionary<int, BookProviderPicture> GetBookProviderPictures();


        public bool CreateBookProviderPicture(int id, BookProviderPicture picture);

        public bool UpdateBookProviderPicture(BookProviderPicture picture);


        public bool DeleteBookProviderPicture(int id);
    }
}
