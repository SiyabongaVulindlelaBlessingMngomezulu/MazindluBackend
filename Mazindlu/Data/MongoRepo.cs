using Mazindlu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using Microsoft.Extensions.Configuration;

namespace Mazindlu.Data
{
    public class MongoRepo : IRepo
    {
        public ushort count;
        private IMongoDatabase db;
        public IMongoCollection<BookProvider> BookProviders;
        public IMongoCollection<PropertyProvider> PropertyProviders;
        
        public MongoRepo(IConfiguration Configuration)
        {
           
            //PropertyProviders
            db = ConnectToMongo("Mazindlu");
            //PropertyProviders = db.GetCollection<BsonDocument>("PropertyProvider");


    }
        //PropertyConnectionMango

        private IMongoDatabase ConnectToMongo(string database)
        {
            try
            {
                var client = new MongoClient("mongodb://127.0.0.1:27017/"); 
                //var client = new MongoClient("mongodb+srv://user:pass@veecluster5-v8vvu.mongodb.net/<dbname>?retryWrites=true&w=majority");/*atlas*/
                var db = client.GetDatabase(database);

                BookProviders = db.GetCollection<BookProvider>("BookProvider");
                PropertyProviders = db.GetCollection<PropertyProvider>("PropertyProvider");
            }
            catch (Exception)
            {
                Console.WriteLine("Oops ! an exception has occured while trying to connect to mongo");
            }
            
            return db;
        }

        public bool StartToConnect() {
            bool result = false;
            try
            {
                db = ConnectToMongo("PropertyDatabase");
                result = true;
                return result;
            }
            catch (Exception)
            {

                result = false;
                return result;
            }
            
            
        }


        public bool CreateBook(int bookId, Book book)
        {
            bool result = false;
            return result;

            

        }

        bool IRepo.CreateBook(Book book)
        {
            throw new NotImplementedException();
        }

        bool IRepo.CreateBookPicture(int BookProviderId, BookPicture bookPicture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.CreateBookProvider(BookProvider user)
        {
            throw new NotImplementedException();
        }

        bool IRepo.CreateBookProviderPicture(int id, BookProviderPicture picture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.CreateProperty(Property prop)
        {
            throw new NotImplementedException();
        }

        bool IRepo.CreatePropertyPicture(PropertyPicture picture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.CreatePropertyPicture(int propertyId, PropertyPicture picture)
        {
            throw new NotImplementedException();
        }

        public void CreatePropertyProvider(PropertyProvider user)
        {
            try
            {
                PropertyProviders.InsertOne(user);
            }
            catch (Exception e )
            {
                Console.WriteLine("An exception has occured, here are some ");
            }
            
        }

        bool IRepo.CreatePropertyProviderPicture(PropertyProviderPicture picture)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepo.DeleteAllBookPictures(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepo.DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepo.DeleteBookPicture(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepo.DeleteBookProvider(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepo.DeleteBookProviderPicture(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepo.DeleteProperty(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepo.DeletePropertyPicture(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepo.DeletePropertyProvider(ushort id)
        {
            throw new NotImplementedException();
        }

        bool IRepo.DeletePropertyProviderPicture(int id)
        {
            throw new NotImplementedException();
        }

        Book IRepo.GetBook(int id)
        {
            throw new NotImplementedException();
        }

        BookPicture IRepo.GetBookPicture(int id)
        {
            throw new NotImplementedException();
        }

        Dictionary<int, BookPicture> IRepo.GetBookPictures()
        {
            throw new NotImplementedException();
        }

        BookProvider IRepo.GetBookProvider(int id)
        {
            throw new NotImplementedException();
        }

        BookProvider IRepo.GetBookProvider(string user_name, string pass_word)
        {
            throw new NotImplementedException();
        }

        BookProviderPicture IRepo.GetBookProviderPicture(int id)
        {
            throw new NotImplementedException();
        }

        void IRepo.GetBookProviderPictureofUser(BookProvider bookProvider)
        {
            throw new NotImplementedException();
        }

        Dictionary<int, BookProviderPicture> IRepo.GetBookProviderPictures()
        {
            throw new NotImplementedException();
        }

        Dictionary<int, BookProvider> IRepo.GetBookProviders()
        {
            throw new NotImplementedException();
        }

        Dictionary<int, Book> IRepo.GetBooks()
        {
            throw new NotImplementedException();
        }

        Dictionary<int, Property> IRepo.GetProperties()
        {
            throw new NotImplementedException();
        }

        LinkedList<Property> IRepo.GetPropertiesOfPropertyProvider(PropertyProvider pp)
        {
            throw new NotImplementedException();
        }

        Property IRepo.GetProperty(int id)
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

        public PropertyProvider GetPropertyProvider(string username, string password)
        {
            PropertyProvider propertyProvider = null;
            try
            {
                
            }
            catch (KeyNotFoundException knfe) {
                Console.WriteLine("here kay?: " + knfe);
                return propertyProvider;
            }
            catch (Exception e)
            {
                Console.WriteLine("here: " + e);
                return propertyProvider;
            }
            
            

            
            return propertyProvider;
        }

        PropertyProvider IRepo.GetPropertyProvider(int id)
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

        IEnumerable<PropertyProvider> IRepo.GetPropertyProviders()
        {
            throw new NotImplementedException();
        }

        bool IRepo.UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        bool IRepo.UpdateBook(int BookProviderId, Book book)
        {
            throw new NotImplementedException();
        }

        bool IRepo.UpdateBookPicture(BookPicture bookPicture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.UpdateBookProvider(BookProvider user)
        {
            throw new NotImplementedException();
        }

        bool IRepo.UpdateBookProviderPicture(BookProviderPicture picture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.UpdateProperty(Property prop)
        {
            throw new NotImplementedException();
        }

        bool IRepo.UpdatePropertyPicture(PropertyPicture picture)
        {
            throw new NotImplementedException();
        }

        bool IRepo.UpdatePropertyProvider(PropertyProvider user)
        {
            throw new NotImplementedException();
        }

        bool IRepo.UpdatePropertyProviderPicture(PropertyProviderPicture picture)
        {
            throw new NotImplementedException();
        }
    }
}
