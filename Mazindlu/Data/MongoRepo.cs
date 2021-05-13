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
        public IMongoCollection<BsonDocument> BookProviders;
        public IMongoCollection<BsonDocument> PropertyProviders;
        public IAsyncCursor<BsonDocument>[] cursorz;
        private readonly IConfiguration Configuration;
        public MongoRepo(IConfiguration Configuration)
        {
            cursorz = new IAsyncCursor<BsonDocument>[100];
            this.Configuration = Configuration;
            //PropertyProviders
            db = ConnectToMongo("PropertyDatabase");
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

                BookProviders = db.GetCollection<BsonDocument>("BookProvider");
                PropertyProviders = db.GetCollection<BsonDocument>("PropertyProvider");
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
            Console.WriteLine("Here we go");
            try
            {
                BsonDocument b = new BsonDocument {
                    {"PropertyProviderID", user.Id},
                    {"Name" , user.Name },
                    {"Surname", user.Surname},
                    {"Email", user.Email},
                    {"Password", user.Password},
                   // {"Properties", new BsonArray{ } },
                    {"ShortBio", user.ShortBio},
                    //{"PropertyProviderPictures", new BsonArray()}
                };
                
                BsonArray properties = new BsonArray();
                foreach (var property in user.Properties)
                {
                    var prop = new BsonDocument{
                        {"PropertyId", property.Id},
                        {"Name", property.Name},
                        //{"pictures", new BsonArray()},
                        { "Description", property.Description},
                        {"price", property.Price}
                    };
                    BsonArray pictures = new BsonArray();
                    foreach (var picture in property.Pictures)
                    {
                        var pic = new BsonDocument {
                            {"PropertyPictureId", picture.Id},
                            {"URI", picture.URI}
                        };
                        pictures.Add(pic);

                    }
                    prop.Add("pictures", pictures);
                    properties.Add(prop);
                }
                b.Add("Properties",properties);
                

                var propertyProviderPictures = new BsonArray();
                foreach (var propertyProviderPicture in user.PropertyProviderPictures)
                {
                    propertyProviderPictures.Add(
                        new BsonDocument {
                            {"PropertyProviderPictureId", propertyProviderPicture.Id},
                            {"URI", propertyProviderPicture.URI}
                        }
                    );
                }
                //b.Add(propertyProviderPictures);
                b.Add("propertyProviderPictures", propertyProviderPictures);
                PropertyProviders.InsertOne(b);
                Console.WriteLine("Success !" + b);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("Failure");
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
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("Email", username); //& builder.Eq("Password", password);
                var result1 = PropertyProviders.Find(filter);
                var filitaz = new BsonDocument { { "Email", username } };

                var myBee = PropertyProviders.Find(filitaz);
                Console.WriteLine(myBee);
                Console.WriteLine(myBee);
                Console.WriteLine(myBee);

                Console.WriteLine(result1);
                Console.WriteLine(result1);
                cursorz[++count] = result1.ToCursor();

                Console.WriteLine(cursorz);
                Console.WriteLine(cursorz);

                Console.WriteLine(username);
                Console.WriteLine(username);
                Console.WriteLine(password);
                Console.WriteLine(password);

                var property_Provider = cursorz[count].First<BsonDocument>();
                propertyProvider = new PropertyProvider()
                {
                    Id = (UInt16)(property_Provider.GetElement("PropertProviderID").Value),
                    Name = property_Provider.GetElement("Name").Value.ToString(),
                    Surname = property_Provider.GetElement("Surname").Value.ToString(),
                    Email = property_Provider.GetElement("Email").Value.ToString(),
                    Password = property_Provider.GetElement("Password").Value.ToString(),
                    ShortBio = property_Provider.GetElement("ShortBio").Value.ToString(),
                    //Properties = (LinkedList<Properties>)(property_Provider.GetElement("Properties").Value.AsBsonArray.AsEnumerable())
                };
                var diswan = property_Provider.GetElement("Properties").Value.AsBsonArray;
                Console.WriteLine(diswan);
                Console.WriteLine(diswan);
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
