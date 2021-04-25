using Mazindlu.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Mazindlu.Data
{
    //This class acceses the data access of the .net application into a sql server database using ado.net
    public class MSSQLRepo : IRepo
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration Configuration;

        public MSSQLRepo(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public bool CreateBookProvider(BookProvider user)
        {
            bool result = false;
            try {
                //_context.BookProviders.Add(user);
                string connectionString = Configuration.GetConnectionString("PropertyConnection");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spCreateBookProvider", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter BookProviderId = new SqlParameter();
                        BookProviderId.ParameterName = "@id";
                        BookProviderId.SqlDbType = SqlDbType.Int;
                        BookProviderId.Value = user.Id;

                        SqlParameter Name = new SqlParameter();
                        Name.ParameterName = "@name";
                        Name.SqlDbType = SqlDbType.NVarChar;
                        Name.Value = user.Name;

                        SqlParameter Surname = new SqlParameter();
                        Surname.ParameterName = "@surname";
                        Surname.SqlDbType = SqlDbType.NVarChar;
                        Surname.Value = user.Surname;

                        SqlParameter Password = new SqlParameter();
                        Password.SqlDbType = SqlDbType.NVarChar;
                        Password.ParameterName = "@password";
                        Password.Value = user.Password;

                        SqlParameter ShortBio = new SqlParameter();
                        ShortBio.ParameterName = "@shortBio";
                        ShortBio.SqlDbType = SqlDbType.NVarChar;
                        ShortBio.Value = user.ShortBio;

                        SqlParameter Email = new SqlParameter();
                        Email.ParameterName = "@email";
                        Email.SqlDbType = SqlDbType.NVarChar;
                        Email.Value = user.Email;

                        command.Parameters.Add(BookProviderId);
                        command.Parameters.Add(Name);
                        command.Parameters.Add(Surname);
                        command.Parameters.Add(Password);
                        command.Parameters.Add(ShortBio);
                        command.Parameters.Add(Email);

                        int output = command.ExecuteNonQuery();
                        if (output > 0)
                        {
                            result = true;
                        }
                        
                    }
                }

                Console.WriteLine(user);
                Console.WriteLine(user);
                //_context.SaveChanges();               
                return result;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine(e);
                return result;
            }
        }

        public bool CreateProperty(Property prop)
        {
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            bool output = false;
            try {
                // _context.Properties.Add(prop);
                // _context.SaveChanges();
                Console.WriteLine(prop);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlParameter PropertyId = new SqlParameter();
                    PropertyId.ParameterName = "@id";
                    PropertyId.SqlDbType = System.Data.SqlDbType.Int;
                    PropertyId.Value = prop.Id;

                    SqlParameter Name = new SqlParameter();
                    Name.ParameterName = "@Name";
                    Name.SqlDbType = System.Data.SqlDbType.NVarChar;
                    Name.Value = prop.Name;

                    SqlParameter Description = new SqlParameter();
                    Description.ParameterName = "@Description";
                    Description.SqlDbType = System.Data.SqlDbType.NVarChar;
                    Description.Value = prop.Description;

                    SqlParameter Price = new SqlParameter();
                    Price.ParameterName = "@Price";
                    Price.SqlDbType = System.Data.SqlDbType.Real;
                    Price.Value = prop.Price;

                    /*
                    SqlParameter PropertyProviderId = new SqlParameter();
                    PropertyProviderId.ParameterName = "@PropertyProviderId";
                    PropertyProviderId.SqlDbType = System.Data.SqlDbType.Int;
                    PropertyProviderId.Value = null;
                    */
                   
                    using (SqlCommand command = new SqlCommand("spCreateProperty", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(PropertyId);
                        command.Parameters.Add(Name);
                        command.Parameters.Add(Description);
                        command.Parameters.Add(Price);
                       // command.Parameters.Add(PropertyProviderId);
                        Console.WriteLine(command);
                        Console.WriteLine(command);
                        int result = command.ExecuteNonQuery();
                        Console.WriteLine(command);
                        if (result > 0 )
                        {
                            output = true;
                        }

                    }                    
                   // connection.Open();
                }
                foreach (PropertyPicture picture in prop.Pictures)
                {
                    CreatePropertyPicture(prop.Id, picture);
                }
                return output;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine(e);
                return output;
            }
        }

        public bool CreatePropertyPicture(int propertyId, PropertyPicture picture)
        {
            Console.WriteLine(picture);
            Console.WriteLine(propertyId);
            bool output = false;
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("spCreatePropertyPicture", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter PropertyPictureId = new SqlParameter();
                        PropertyPictureId.ParameterName = "@id";
                        PropertyPictureId.SqlDbType = SqlDbType.Int;
                        PropertyPictureId.Value = picture.Id;

                        SqlParameter URI = new SqlParameter();
                        URI.ParameterName = "@URI";
                        URI.SqlDbType = SqlDbType.NVarChar;
                        URI.Value = picture.URI;

                        SqlParameter PropertyId = new SqlParameter();
                        PropertyId.ParameterName = "@PropertyId";
                        PropertyId.SqlDbType = SqlDbType.Int;
                        PropertyId.Value = propertyId;

                        command.Parameters.Add(PropertyPictureId);
                        command.Parameters.Add(URI);
                        command.Parameters.Add(PropertyId);
                        int result = -2;
                        Console.WriteLine(command);
                        result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            output = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return output;
            }

            return output;
            
        }

        public void CreatePropertyProvider(PropertyProvider user)
        {
            var pp = user;
            //pp.Properties = null;
            //pp.Properties = new LinkedList<Property>();
            //pp.PropertyProviderPictures = null;
            //pp.PropertyProviderPictures = new LinkedList<PropertyProviderPicture>();

            Console.WriteLine(user);
            Console.WriteLine(user);
            Console.WriteLine(pp);
            Console.WriteLine(pp);

            //string connectionString = Configuration.GetConnectionString("PropertyConnection");
            //SqlConnection connection = new SqlConnection(connectionString);
            try {

                Console.WriteLine(user);
                Console.WriteLine(pp);
                Console.WriteLine(pp);
                _context.PropertyProviders.Add(user);            
            foreach (var ppp in user.PropertyProviderPictures) {
                    Console.WriteLine("Done twice");
               // _context.PropertyProviderPictures.Add(ppp);

            }

            foreach (var prop in user.Properties)
            {
                    Console.WriteLine("Done once");
                    // _context.Properties.Add(prop);
                }
                Console.WriteLine(user);
                Console.WriteLine(pp);
                Console.WriteLine(pp);
                _context.SaveChanges();
                Console.WriteLine(user);
                
            }
            
            catch (SqlException sqle) {
                Console.WriteLine(sqle.Message.ToString());
                Console.WriteLine(sqle.Message.ToString());
            }
            catch (Exception e) {
                Console.WriteLine(e.Message.ToString());
                Console.WriteLine(e.Message.ToString());
            }
            
        }

        
        public bool DeleteBookProvider(int id)
        {
            LinkedList<int> books = new LinkedList<int>();

            books = GetBookIDsOfOwner(id);

            foreach (int bookId in books)
            {
                DeleteBook(bookId);
            }

            //var bookProvider = _context.BookProviders.FirstOrDefault(bp => bp.Id == id);
            var bookProvider = GetBookProvider(id);
            if (bookProvider == null)
            {
                return false;
            }
            int result = DeleteBookProviderPictureofUser(bookProvider).Result;
            Console.WriteLine(result);
            Console.WriteLine();
            try {
                string connectionString = Configuration.GetConnectionString("PropertyConnection");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spDeleteBookProvider", connection))
                    {
                        SqlParameter BookProviderId = new SqlParameter();
                        BookProviderId.ParameterName = "@id";
                        BookProviderId.SqlDbType = SqlDbType.Int;
                        BookProviderId.Value = id;

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(BookProviderId);
                        result = -1;
                        result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
                
                return false;
            }
            

        }


        public LinkedList<int> GetBookIDsOfOwner(int bookProviderId) {
            LinkedList<int> bookIDs = new LinkedList<int>();

            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("spGetAllBookIDsOfBookProvider", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter BookProviderId = new SqlParameter();
                    BookProviderId.ParameterName = "@BookProviderId";
                    BookProviderId.SqlDbType = System.Data.SqlDbType.Int;
                    BookProviderId.Value = bookProviderId;
                    command.Parameters.Add(BookProviderId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int anId = 0;
                                anId = (int)(reader.GetValue(0));

                                bookIDs.AddLast(
                                    anId    
                                );                                   
                                
                            }
                        }
                    }
                }
            }
            return bookIDs;
        }

        public bool DeleteProperty(int id)
        {
            bool output = false;
            Console.WriteLine(id);
            var property = _context.Properties.FirstOrDefault(p => p.Id == id);
            Console.WriteLine(property);
            WipePropertyPictures(id);
            Console.WriteLine(property);
            try {
                //_context.Properties.Remove(property);
                //_context.SaveChanges();
                string connectionString = Configuration.GetConnectionString("PropertyConnection");               
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlParameter PropertyId = new SqlParameter();
                    PropertyId.ParameterName = "@id";
                    PropertyId.SqlDbType = SqlDbType.Int;
                    PropertyId.Value = id;

                    using (SqlCommand command = new SqlCommand("spDeleteProperty",connection))
                    {
                        command.Parameters.Add(PropertyId);
                        command.CommandType = CommandType.StoredProcedure;
                        int result = command.ExecuteNonQuery();
                        output = true;
                    }
                }
                return output;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine(e);
                return output;
            }
        }
       

        public bool DeletePropertyProvider(ushort id)
        {
            bool rezult = false;
            //var propertyProvider = _context.PropertyProviders.FirstOrDefault(pp => pp.Id == id);
            int result = DeletePropertyProviderPictureofUser(id).Result;
            Console.WriteLine(id);
            Console.WriteLine(id);
            
            try {
                bool arePropertiesDeleted = DeleteProvidersProperties(id);
                if (true)
                {

                }
                // _context.SaveChanges();
                // _context.PropertyProviders.Remove(propertyProvider);
                bool isPropertyProviderDeleted = DeleteAPropertyProvider(id);
                //_context.SaveChanges();
                Console.WriteLine(result);
                Console.WriteLine(arePropertiesDeleted);
                Console.WriteLine(isPropertyProviderDeleted);
                Console.WriteLine();
                if (isPropertyProviderDeleted)
                {
                    Console.WriteLine();
                    return true;
                }
                Console.WriteLine();
                return false;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine(e);
                return false;
            
            }
        }

        private bool DeleteAPropertyProvider(int id) {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command  = new SqlCommand("DeleteAPropertyProvider", connection))
                {
                    SqlParameter PropertyProviderId = new SqlParameter();
                    PropertyProviderId.ParameterName = "@propertyProviderId";
                    PropertyProviderId.SqlDbType = System.Data.SqlDbType.Int;
                    PropertyProviderId.Value = id;
                    command.Parameters.Add(PropertyProviderId);

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    Console.WriteLine(result);
                    Console.WriteLine(result);
                    result = command.ExecuteNonQuery();
                    Console.WriteLine(result);
                    Console.WriteLine(result);
                   
                    if (result > 0)
                    {
                        return true;
                    }
                    else{
                        return false;
                    }
                    
                }
            }
        }
        /*
        public IEnumerable<Property> GetPicturesOfAProperty(Property property) {
            PropertyPicture[] pp = new PropertyPicture[100];
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            SqlDataReader dataReader = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    dataReader = command.ExecuteReader();
                    using (dataReader)
                    {
                        int i = 0;
                        ushort id = 0;
                        string uri = "";
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                // eyeD = ;
                                id = UInt16.Parse(("" + (int)(dataReader.GetValue(0))));
                                uri = dataReader.GetValue(1).ToString();
                                // property.Pictures.AddLast(new PropertyProviderPicture(){ Id = id, URI = uri });
                                pp[i++] = new PropertyPicture() { Id = id, URI = uri };
                                    //AddLast(new LinkedListNode<PropertyProviderPicture>(new PropertyProviderPicture() { Id = id, URI = uri }));

                            }
                        }
                    }
                }
            }

        }*/




        public LinkedList<Property> GetPropertiesOfPropertyProvider(PropertyProvider pp)
        {
            LinkedList<Property> properties  = new LinkedList<Property>();
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            SqlDataReader dataReader = null;
            SqlParameter PropertyProviderId = new SqlParameter();
            PropertyProviderId.ParameterName = "@PropertyProviderId";
            PropertyProviderId.SqlDbType = System.Data.SqlDbType.Int;
            PropertyProviderId.Value = pp.Id;
            Console.WriteLine(properties);
            Console.WriteLine(properties);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spGetPropertiesOfPropertyProvider", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(PropertyProviderId);
                        Thread.Sleep(100);
                        Console.WriteLine(command);
                        Console.WriteLine(command);
                        dataReader = command.ExecuteReader();
                        using (dataReader)
                        {
                            Console.WriteLine(dataReader);
                            Console.WriteLine(dataReader);
                            int i = 0;
                            //ushort id = 0;
                            string uri = "";
                            if (dataReader.HasRows)
                            {
                                Console.WriteLine(dataReader);
                                Console.WriteLine(dataReader);
                                while (dataReader.Read())
                                {
                                    int id = 0;
                                    string name = "";
                                    string description = "";
                                    float price = 0;

                                    id = (int)(dataReader.GetValue(0));
                                    name = "" + dataReader.GetValue(1);
                                    description = "" + dataReader.GetValue(2);
                                    price = dataReader.GetFloat(3);

                                    Console.WriteLine(id);
                                    Console.WriteLine(name);
                                    Console.WriteLine(description);
                                    Console.WriteLine(price);
                                    Console.WriteLine();
                                    // propertiesArray[i++] = new Property() { Id = id, Name = name, Description = description, Price = price};
                                    // eyeD = ;
                                    //id = UInt16.Parse(("" + (int)(dataReader.GetValue(0))));
                                    //uri = dataReader.GetValue(1).ToString();
                                    // property.Pictures.AddLast(new PropertyProviderPicture(){ Id = id, URI = uri });
                                    //pp[i++] = new PropertyPicture() { Id = id, URI = uri };
                                    //AddLast(new LinkedListNode<PropertyProviderPicture>(new PropertyProviderPicture() { Id = id, URI = uri }));
                                    var newProp = new Property()
                                    {
                                        Id = (ushort)(id),
                                        Name = name,
                                        Description = description,
                                        Price = price,

                                    };
                                    Console.WriteLine(newProp);
                                    Console.WriteLine(newProp);
                                    newProp.Pictures = GetPicturesOfProperties(newProp.Id);
                                    // newProp.Pictures = GetPicturesOfProperties(id);
                                    properties.AddLast(newProp);
                                    //properties.Pictures = GetPicturesOfProperties(id)
                                    Console.WriteLine(properties);
                                    pp.Properties = properties;
                                    Console.WriteLine(pp);
                                    Console.WriteLine(pp);
                                    // Console.WriteLine(propertiesArray);
                                }
                            }

                        }
                    }
                    
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e); ;
            }
            Console.WriteLine(properties);
            return properties;//new LinkedList<Property>(propertiesArray);
        }

        public void  GetAProperty(int id){
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetProperty", connection))
                {
                    SqlParameter PropertyId = new SqlParameter();                   
                    PropertyId.ParameterName = "@PropertyProviderId";
                    PropertyId.SqlDbType = System.Data.SqlDbType.Int;
                    PropertyId.Value = id;
                    command.Parameters.Add(PropertyId);
                    int result = command.ExecuteNonQuery();
                }
            }
        
        }

        public bool WipePropertyPictures(int propertyId) {

            try
            {
                string connectionString = Configuration.GetConnectionString("PropertyConnection");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spDeleteAllPropertyPictures", connection))
                    {
                        Console.WriteLine(propertyId);
                        Console.WriteLine(propertyId);
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter PropertyId = new SqlParameter();
                        PropertyId.ParameterName = "@PropertyId";
                        PropertyId.SqlDbType = System.Data.SqlDbType.Int;
                        PropertyId.Value = propertyId;

                        command.Parameters.Add(PropertyId);
                        Console.WriteLine(command);
                        Console.WriteLine(command);
                        int result = command.ExecuteNonQuery();
                        Console.WriteLine(result);
                        Console.WriteLine(result);

                        if (result > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e);
                return false;
            }
        }



        public BookProvider GetBookProvider(int id)
        {
            var bookProvider = _context.BookProviders.FirstOrDefault(bp => bp.Id == id);
            return bookProvider;
        }

        public bool DeleteProvidersProperties(int id) {
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            Console.WriteLine(connectionString);
            Console.WriteLine(connectionString);
            //Configuration["PropertyConnection"];
            var pp = GetPropertyProvider(id);
            Console.WriteLine(pp);
            Console.WriteLine(pp);
            if (pp.Id == 0) return false;

            DeletePicturesOfProperty(pp);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine(connection);
                    using (SqlCommand command = new SqlCommand("spDeleteOwnersProperties", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter PropertyProviderId = new SqlParameter();
                        PropertyProviderId.ParameterName = "@PropertyProviderId";
                        PropertyProviderId.SqlDbType = System.Data.SqlDbType.Int;
                        PropertyProviderId.Value = id;

                        command.Parameters.Add(PropertyProviderId);
                        int result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                return false;
                Console.WriteLine(e);
                
            }
            return true;
        }

        public void DeletePicturesOfProperty(PropertyProvider pp) {
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            try {
                using (SqlConnection connection = new SqlConnection()) {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    Console.WriteLine(pp);
                    Console.WriteLine(pp);
                    LinkedList<Property> propList = GetPropertiesOfPropertyProvider(pp);

                    foreach (Property p in propList) {
                        using (SqlCommand command = new SqlCommand("spDeleteAllPropertyPictures", connection))
                        {
                            Console.WriteLine(p);
                            Console.WriteLine(p);
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            SqlParameter PropertyId = new SqlParameter();
                            PropertyId.ParameterName = "@PropertyId";
                            PropertyId.SqlDbType = System.Data.SqlDbType.Int;
                            PropertyId.Value = p.Id;

                            command.Parameters.Add(PropertyId);
                            Console.WriteLine(command);
                            Console.WriteLine(command);
                            int result = command.ExecuteNonQuery();
                            Console.WriteLine(result);
                            Console.WriteLine(result);
                        }
                    }

                    
                }
            }
            catch (SqlException sqle) {
                Console.WriteLine("A database exception has occured, here are some details:\n" + sqle);
                
            }
            catch (Exception e) {
                Console.WriteLine("An unexpedcted exception has occured here are some details");
            }
        }

        public  BookProvider GetBookProvider(string user_name, string pass_word)
        {
            BookProvider bookProvider = null;
            try
            {
                bookProvider = _context.BookProviders.FirstOrDefault(bp => bp.Email.Equals(user_name) & bp.Password.Equals(pass_word));
                if (bookProvider == null)
                {
                    return bookProvider;
                }
                //             
                bookProvider.Books = new LinkedList<Book>();
                //
                bookProvider.Books = GetBooksOfBookProvider((int)(bookProvider.Id));
                GetBookProviderPictureofUser(bookProvider);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae);
                Console.WriteLine("Something went wrong\n:" + ae);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Something went wrong\n:" + e);
            }
            Console.WriteLine(bookProvider);
            Console.WriteLine(bookProvider);
            /*
            try
            {
                #region
                using (SqlConnection con = new SqlConnection("Server=(LocalDB)\\Gloire;Database=PropertyDatabase;Integrated Security=true;"))
                {
                    con.Open();
                    SqlDataReader dataReader = null;
                    using (SqlCommand command = new SqlCommand("GetBookproviderPicture", con))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter BookProviderId = new SqlParameter();
                        BookProviderId.ParameterName = "@BookProviderId";
                        BookProviderId.SqlDbType = System.Data.SqlDbType.Int;
                        BookProviderId.Value = bookProvider.Id;
                        command.Parameters.Add(BookProviderId);

                        dataReader = command.ExecuteReader();

                        bookProvider.BookProviderPictures = new LinkedList<BookProviderPicture>();
                        bookProvider.Books = new LinkedList<Book>();
                        // int recordCount = 0;
                        using (dataReader)
                        {
                            int eyeD = 0;
                            ushort uid = 0;
                            string uri = new System.String("");
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    // eyeD = ;
                                     uid = UInt16.Parse(("" + (int)(dataReader.GetValue(0))));
                                    uri = dataReader.GetValue(1).ToString();
                                    bookProvider.BookProviderPictures.AddLast(new LinkedListNode<BookProviderPicture>(new BookProviderPicture() {Id = uid, URI = uri }));

                                }
                            }
                        }
                    }
                }
                #endregion
            }
            catch (SqlException e)
            {               
                Console.WriteLine("An exception occured, here are some details:\n" + e);
            }
            */
            return bookProvider;
        }

        public LinkedList<BookPicture> GetBookPictures(int bookId) {
            string connectionString = Configuration.GetConnectionString("PropertyConnection");

            LinkedList<BookPicture> bookPictures = new LinkedList<BookPicture>();

            SqlParameter BookId = new SqlParameter();
            BookId.ParameterName = "@BookId";
            BookId.SqlDbType = System.Data.SqlDbType.Int;
            BookId.Value = bookId;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("spGetBookPictures", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(BookId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())//iterates row by row
                            {
                                int id;
                                string uri;

                                id = (int)(reader.GetValue(0));
                                uri = "" + reader.GetValue(1);
                                bookPictures.AddLast(
                                    new BookPicture() { 
                                        Id = (ushort)(id),
                                        URI = uri
                                    }    
                                );
                            }
                        }
                    }
                }
            }
            return bookPictures;
        }

        public Dictionary<int, BookProvider> GetBookProviders()
        {
            var bookProviderList = _context.BookProviders.AsEnumerable();
            var bookProviderDictionary = new Dictionary<int, BookProvider>();
            Console.WriteLine();

            foreach (var bp in bookProviderList) {
                bookProviderDictionary.Add(bp.Id, bp);
            }
            return bookProviderDictionary;
        }


        public void GetBookProviderPictureofUser(BookProvider bookProvider) {
            try
            {
                Console.WriteLine(bookProvider);
                #region
                string connectionString = Configuration.GetConnectionString("PropertyConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    Console.WriteLine(bookProvider);
                    con.Open();
                    SqlDataReader dataReader = null;
                    using (SqlCommand command = new SqlCommand("GetBookproviderPicture", con))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        Console.WriteLine(bookProvider);
                        SqlParameter BookProviderId = new SqlParameter();
                        BookProviderId.ParameterName = "@BookProviderId";
                        BookProviderId.SqlDbType = System.Data.SqlDbType.Int;
                        BookProviderId.Value = bookProvider.Id;
                        command.Parameters.Add(BookProviderId);

                        dataReader = command.ExecuteReader();

                        bookProvider.BookProviderPictures = new LinkedList<BookProviderPicture>();
                        //bookProvider.Books = new LinkedList<Book>();
                        // int recordCount = 0;
                        using (dataReader)
                        {
                            int eyeD = 0;
                            ushort uid = 0;
                            string uri = new System.String("");
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    // eyeD = ;
                                    uid = UInt16.Parse(("" + (int)(dataReader.GetValue(0))));
                                    uri = dataReader.GetValue(1).ToString();
                                    bookProvider.BookProviderPictures.AddLast(new LinkedListNode<BookProviderPicture>(new BookProviderPicture() { Id = uid, URI = uri }));

                                }
                            }
                        }
                    }
                }
                #endregion
            }
            catch (SqlException e)
            {
                Console.WriteLine("An exception occured, here are some details:\n" + e);
            }
        }

        public LinkedList<Book> GetBooksOfBookProvider(int bookProviderId) {
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            LinkedList<Book> books = new LinkedList<Book>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spGetAllBooksOfBookProvider", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter BookProviderId = new SqlParameter();
                        BookProviderId.ParameterName = "@BookProviderId";
                        BookProviderId.DbType = System.Data.DbType.Int32;
                        BookProviderId.Value = bookProviderId;

                        command.Parameters.Add(BookProviderId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine();
                            if (reader.HasRows)
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                while (reader.Read())
                                {
                                    int id = 0;
                                    string title;
                                    string format;
                                    string author;
                                    string isbn;
                                    float price;
                                    string contactNo;
                                   
                                    id = (int)(reader.GetValue(0));
                                    title = "" + reader.GetValue(1);
                                    format = "" + reader.GetValue(2);
                                    author = "" + reader.GetValue(3);
                                    isbn = "" + reader.GetValue(4);
                                    price = reader.GetFloat(5);
                                    contactNo = "" + reader.GetValue(6);


                                    Console.WriteLine(id);
                                    Console.WriteLine(title);
                                    Console.WriteLine(format);
                                    Console.WriteLine(author);
                                    Console.WriteLine(isbn);
                                    Console.WriteLine(price);
                                    var myBook = new Book();
                                    if (id > 0)
                                    {
                                        myBook = new Book()
                                        {
                                            Id = (ushort)(id),
                                            Title = title,
                                            Format = format,
                                            ISBN = isbn,
                                            Author = author,
                                            Price = price,
                                            ContactNo = contactNo,
                                            BookPictures = new LinkedList<BookPicture>()
                                        };
                                    }
                                    myBook.BookPictures = GetBookPictures((int)(myBook.Id));
                                    Console.WriteLine(myBook);
                                    Console.WriteLine(myBook);
                                    books.AddLast(
                                        myBook
                                    );
                                    Console.WriteLine(books);
                                    Console.WriteLine(books);
                                }
                            }
                            else {
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {

                Console.WriteLine(e);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            

            
            return books;
        }

        public async Task<int> DeleteBookProviderPictureofUser(BookProvider bookProvider) {
            int result = 0;
            try
            {
                #region
                string connectionString = Configuration.GetConnectionString("PropertyConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    Console.WriteLine(bookProvider.Id);
                    Console.WriteLine(bookProvider.Id);
                    Console.WriteLine(bookProvider.Id);
                    Console.WriteLine(bookProvider.Id);
                    con.Open();
                    using (SqlCommand command = new SqlCommand("DeleteBookproviderPicture", con))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter BookProviderId = new SqlParameter();
                        BookProviderId.ParameterName = "@BookProviderId";
                        BookProviderId.SqlDbType = System.Data.SqlDbType.Int;
                        BookProviderId.Value = (Int32)bookProvider.Id;
                        command.Parameters.Add(BookProviderId);

                        result = await command.ExecuteNonQueryAsync();

                    }
                }
                #endregion
                return result;
            }
            catch (SqlException e)
            {
                Console.WriteLine("An exception occured, here are some details:\n" + e);
                Console.WriteLine("An exception occured, here are some details:\n" + e);
                Console.WriteLine("An exception occured, here are some details:\n" + e);
                return result;
            }
            
                
            
        }



        public async Task<int> DeletePropertyProviderPictureofUser( int propertyProvider_Id)
        {
            int result = 0;
            try
            {
                #region
                string connectionString = Configuration.GetConnectionString("PropertyConnection");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("DeletePropertyProviderPicture", con))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        SqlParameter PropertyProviderId = new SqlParameter();
                        PropertyProviderId.ParameterName = "@PropertyProviderId";
                        PropertyProviderId.SqlDbType = System.Data.SqlDbType.Int;
                        PropertyProviderId.Value = propertyProvider_Id;//propertyProvider.Id;
                        command.Parameters.Add(PropertyProviderId);
                        Console.WriteLine(PropertyProviderId);
                        Console.WriteLine(PropertyProviderId);
                        result = await command.ExecuteNonQueryAsync();
                        Console.WriteLine(result);
                        Console.WriteLine(result);
                        Console.WriteLine(result);
                    }
                }
                #endregion
                return result;
            }
            catch (SqlException e)
            {
                Console.WriteLine("An exception occured, here are some details:\n" + e);
                return result;
            }
        }




        public Dictionary<int, Property> GetProperties()
        {
            LinkedList<Property> propertyList = new LinkedList<Property>();
            var propertyDictionary = new Dictionary<int, Property>();
            foreach (var p in propertyList)
            {
                propertyDictionary.Add(p.Id, p);
            }
            /*
            LinkedList<Property> propertyList = (LinkedList<Property>)(_context.Properties.AsEnumerable());
            
            return propertyDictionary;
            */
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("spGetProperties",connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                for (int k = 0; k < dataTable.Rows.Count; k++)
                {
                    int j = 0;
                    Console.WriteLine(dataTable.Rows);
                    Console.WriteLine(dataTable.Rows);
                    var property = new Property()
                    {
                        Id = UInt16.Parse(dataTable.Rows[k].ItemArray.ElementAt(j++).ToString())//["Id"].ToString()),
                       ,Name = dataTable.Rows[k].ItemArray.ElementAt(j++).ToString()//["Name"].ToString(),
                       ,Description = dataTable.Rows[k].ItemArray.ElementAt(j++).ToString()//["Description"].ToString(),
                       ,Price = System.Single.Parse(dataTable.Rows[k].ItemArray.ElementAt(j++).ToString())
                    };
                    property.Pictures = GetPicturesOfProperties(property.Id);
                    //propertyList.AddLast(
                    //    property
                    //);
                    propertyDictionary.Add(property.Id, property);
                    //property = null;
                }

                

            }

            return propertyDictionary;

        }



        //Entity framework & ADO.Net get book request 
        public Property GetProperty(int id)
        {
            Property property = _context.Properties.FirstOrDefault(p => p.Id == id);
            property.Pictures = GetPicturesOfProperties(id);
            return property;
        }



        public PropertyProvider GetPropertyProvider(int id)
        {
            //var propertyProvider = _context.PropertyProviders.FirstOrDefault(pp => pp.Id == id);
            PropertyProvider propertyProvider = null;
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            using (SqlConnection connection  = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlCommand command = new SqlCommand("spGetPropertyProvider", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter PropertyProviderId = new SqlParameter();
                    PropertyProviderId.ParameterName = "@PropertyProviderId";
                    PropertyProviderId.SqlDbType = System.Data.SqlDbType.Int;
                    PropertyProviderId.Value = (id);
                    command.Parameters.Add(PropertyProviderId);
                    using (SqlDataReader dr = command.ExecuteReader()) {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ushort uniqueIdentifier = (UInt16)(dr.GetInt32(0));
                                string name = "" + dr.GetValue(1);
                                string surname = "" + dr.GetValue(2);
                                string email = "" + dr.GetValue(3);
                                string password = "" + dr.GetValue(4);
                                string shortBio = "" + dr.GetValue(5);
                                propertyProvider = new PropertyProvider()
                                {
                                    Id = uniqueIdentifier,
                                    Name = name,
                                    Surname = surname,
                                    Email = email,
                                    Password = password,
                                    ShortBio = shortBio
                                };
                            }

                        }
                        else {
                            propertyProvider = new PropertyProvider()
                            {
                                Id = 0
                            };
                        }
                    }

                }
            }
                return propertyProvider;
        }

        public PropertyProvider GetPropertyProvider(string username,string password)
        {
            PropertyProvider propertyProvider = null;
            try
            {
                Console.WriteLine(username);
                Console.WriteLine(password);
                propertyProvider = _context.PropertyProviders.FirstOrDefault(pp => pp.Email.Equals(username) & pp.Password.Equals(password));
                if (propertyProvider == null)
                {
                    return propertyProvider;
                }
                int test = propertyProvider.Id; 
                /*The line above is very important because it throws a null pointer exception if the property provider is not found
                 this allows the method to exit gracefully as the exception is caught below */
                Console.WriteLine(propertyProvider);
                Console.WriteLine(propertyProvider);

                GetPropertyProviderPictureofUser(propertyProvider);
                propertyProvider.Properties = GetPropertiesOfPropertyProvider(propertyProvider);
                //var ownerProps = from prop in _context.Properties
                //where /*prop.Id == propertyProvider.Id ||*/ prop.Id >= 5500
                // select prop;
                _context.SaveChanges();
                Console.WriteLine(propertyProvider);
                Console.WriteLine(propertyProvider);
                
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine("This exception was caught !");
                //propertyProvider = new PropertyProvider() { Id = 0};
                return propertyProvider;
            }
            return propertyProvider;
        }


        public void GetPropertyProviderPictureofUser(PropertyProvider propertyProvider)
        {
            Console.WriteLine(propertyProvider.Id);
            Console.WriteLine(propertyProvider.Id);
            Console.WriteLine(propertyProvider.Id);
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataReader dataReader = null;
                    using (SqlCommand command = new SqlCommand("GetPropertyProviderPicture", con))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter PropertyProviderId = new SqlParameter();
                        PropertyProviderId.ParameterName = "@PropertyProviderId";
                        PropertyProviderId.SqlDbType = System.Data.SqlDbType.SmallInt;
                        PropertyProviderId.Value = (short)(propertyProvider.Id);
                        command.Parameters.Add(PropertyProviderId);

                        dataReader = command.ExecuteReader();
                        
                        propertyProvider.PropertyProviderPictures = new LinkedList<PropertyProviderPicture>();
                        propertyProvider.Properties = new LinkedList<Property>();

                        // int recordCount = 0;
                        using (dataReader)
                        {
                            int eyeD = 0;
                            ushort uid = 0;
                            string uri = new System.String("");
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    // eyeD = ;
                                    uid = UInt16.Parse(("" + (int)(dataReader.GetValue(0))));
                                    uri = dataReader.GetValue(1).ToString();
                                    propertyProvider.PropertyProviderPictures.AddLast(new LinkedListNode<PropertyProviderPicture>(new PropertyProviderPicture() { Id = uid, URI = uri }));

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("oops an exception has occured ! here are some details\n" + e);
                Console.WriteLine();
                Console.WriteLine();
            }
        }


        public IEnumerable<PropertyProvider> GetPropertyProviders()
        {
            var propertyProviderList = _context.PropertyProviders.AsEnumerable();
            Console.WriteLine("Hey");
            foreach(var pp in propertyProviderList) {
                GetPropertyProviderPictureofUser(pp);
            }

            foreach (var pp in propertyProviderList)
            {
                GetPropertiesOfPropertyProvider(pp);
            }


            return propertyProviderList;
        }

        public bool UpdateBookProvider(BookProvider user)
        {
            var bookProvider = _context.BookProviders.FirstOrDefault(bp => bp.Id == user.Id);
            int r1, r2, a1, a2 = 0;
            
            try
            {
                // int result = DeleteBookProviderPictureofUser(bookProvider).Result;
                r1 = _context.BookProviders.Count<BookProvider>();
                bool disappear, appear = false;
                disappear = DeleteBookProvider(user.Id);//_context.BookProviders.Remove(bookProvider);               

                
                //_context.BookProviders.Add(user);
                appear = CreateBookProvider(user);
                
                Console.WriteLine(appear);
                Console.WriteLine(disappear);
                
                if (appear && disappear)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateProperty(Property prop)
        {
            var property = _context.Properties.FirstOrDefault(p => p.Id == prop.Id);
            try
            {
                _context.Properties.Remove(property);
                _context.Properties.Add(prop);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdatePropertyProvider(PropertyProvider propertyProvider)
        {
            //var propertyProvider = _context.PropertyProviders.FirstOrDefault(pp => pp.Id == user.Id);
            Console.WriteLine(propertyProvider);
            Console.WriteLine(propertyProvider);
            try
            {

                // _context.PropertyProviders.Remove(propertyProvider);
                DeletePropertyProvider(propertyProvider.Id);
                Console.WriteLine(_context.PropertyProviders);
                _context.SaveChanges();
                //_context.PropertyProviders.Add(user);
                CreatePropertyProvider(propertyProvider);
                Console.WriteLine(_context.PropertyProviders);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                Console.WriteLine(e.Message.ToString());
                Console.WriteLine(e.Message.ToString());
                return false;

            }
            
        }

        public Book GetBook(int id)
        {
            var book = GetBookWithoutPictures(id);//_context.Books.FirstOrDefault(b => b.Id == id);



            if (book == null)
            {
                return book;
            }

            var bookPictures = new LinkedList<BookPicture>();
            string connectionString = Configuration.GetConnectionString("PropertyConnection");


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // connection.Open();
                using (SqlCommand command = new SqlCommand("spGetBookPictures", connection))
                {                   
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter BookId = new SqlParameter();
                    BookId.ParameterName = "@BookId";
                    BookId.SqlDbType = System.Data.SqlDbType.Int;
                    BookId.Value = id;
                    command.Parameters.Add(BookId);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet bookPics = new DataSet();
                    da.Fill(bookPics);

                    int bookID = 0;
                    string uri = "";
                       foreach (DataRow bookPic in bookPics.Tables[0].Rows)
                       {
                           bookID = (int)(bookPic[0]);
                           uri = "" + bookPic[1];
                           bookPictures.AddFirst(new BookPicture()
                           {
                               Id = (ushort)(bookID),
                               URI = uri
                           });
                       }
               
                }
                
                
            }
            book.BookPictures = bookPictures;
            Console.WriteLine(book);
            Console.WriteLine(book);
            Console.WriteLine(book);
            return book;

        }

        private Book GetBookWithoutPictures(int id) {
            Book book = null;
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                

                SqlParameter BookId = new SqlParameter();
                BookId.ParameterName = "@id";
                BookId.SqlDbType = System.Data.SqlDbType.Int;
                BookId.Value = id;
                using (SqlCommand command = new SqlCommand("spGetBook", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(BookId);
                    Console.WriteLine(command);
                    SqlDataReader reader = command.ExecuteReader();
                    Boolean rowsExist = reader.HasRows ? true : false;
                    if (rowsExist)
                    {
                        while (reader.Read()) {
                            book = new Book();
                            book.Id = (UInt16)(reader.GetInt32(0));
                            book.Title = reader.GetValue(1).ToString();
                            book.Format = reader.GetValue(2).ToString();
                            book.Author = reader.GetValue(3).ToString();
                            book.ISBN = reader.GetValue(4).ToString();
                            book.Price = (float)reader.GetValue(5);
                            book.ContactNo = reader.GetValue(6).ToString();


                        }
                    }
                }
            }
            return book;
        }

        public Dictionary<int, Book> GetBooks()
        {
            var bookList = _context.Books.AsEnumerable();
            var bookDictionary = new Dictionary<int, Book>();
            foreach (var b in bookList) {
                bookDictionary.Add(b.Id,b);
            }


            return bookDictionary;
        }

        public bool CreateBook(int id, Book book)
        {
            bool output = false;
            try {
                //_context.Add(book);
                //_context.SaveChanges();
                string connectionString = Configuration.GetConnectionString("PropertyConnection");
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spCreateBook", connection);
                    using (command)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //SqlParameter Id = new SqlParameter();
                        SqlParameter BookId = new SqlParameter();
                        BookId.ParameterName = "@id";
                        BookId.SqlDbType = System.Data.SqlDbType.Int;
                        BookId.Value = book.Id;

                        SqlParameter Title = new SqlParameter();
                        Title.ParameterName = "@Title";
                        Title.SqlDbType = System.Data.SqlDbType.NVarChar; 
                        Title.Value = book.Title;

                        SqlParameter Format = new SqlParameter();
                        Format.ParameterName = "@Format";
                        Format.SqlDbType = System.Data.SqlDbType.NVarChar; 
                        Format.Value = book.Format;

                        SqlParameter Author = new SqlParameter();
                        Author.ParameterName = "@Author";
                        Author.SqlDbType = System.Data.SqlDbType.NVarChar; 
                        Author.Value = book.Author;

                        SqlParameter ISBN = new SqlParameter();
                        ISBN.ParameterName = "@ISBN";
                        ISBN.SqlDbType = System.Data.SqlDbType.NVarChar; 
                        ISBN.Value = book.ISBN;

                        SqlParameter Price = new SqlParameter();
                        Price.ParameterName = "@Price";
                        Price.SqlDbType = System.Data.SqlDbType.Real;
                        Price.Value = book.Price;

                        SqlParameter ContactNo = new SqlParameter();
                        ContactNo.ParameterName = "@ContactNo";
                        ContactNo.SqlDbType = System.Data.SqlDbType.NVarChar;
                        ContactNo.Value = book.ContactNo;

                        
                        SqlParameter BookProviderId = new SqlParameter();
                        BookProviderId.ParameterName = "@BookProviderId";
                        BookProviderId.SqlDbType = System.Data.SqlDbType.Int;
                        BookProviderId.Value = id;
                        


                        command.Parameters.Add(BookId);
                        command.Parameters.Add(Title);
                        command.Parameters.Add(Format);
                        command.Parameters.Add(Author);
                        command.Parameters.Add(ISBN);
                        command.Parameters.Add(Price);
                        command.Parameters.Add(ContactNo);
                        command.Parameters.Add(BookProviderId);

                        Console.WriteLine(command.Parameters);
                        Console.WriteLine(command.Parameters);
                        Console.WriteLine(command.Parameters);
                        byte result = (byte)(command.ExecuteNonQueryAsync().Result);
                        output = (result > 0) ?  true :  false;
                    }
                }
                return output;
            }
            catch (Exception e) {
                Console.WriteLine();
                Console.WriteLine();
                return output;
            }
        }


        public bool CreateBook(Book book)
        {
            bool output = false;
            try
            {
                //_context.Add(book);
                //_context.SaveChanges();
                string connectionString = Configuration.GetConnectionString("PropertyConnection");
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spCreateBook", connection);
                    using (command)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //SqlParameter Id = new SqlParameter();
                        SqlParameter BookId = new SqlParameter();
                        BookId.ParameterName = "@id";
                        BookId.SqlDbType = System.Data.SqlDbType.Int;
                        BookId.Value = book.Id;

                        SqlParameter Title = new SqlParameter();
                        Title.ParameterName = "@Title";
                        Title.SqlDbType = System.Data.SqlDbType.NVarChar;
                        Title.Value = book.Title;

                        SqlParameter Format = new SqlParameter();
                        Format.ParameterName = "@Format";
                        Format.SqlDbType = System.Data.SqlDbType.NVarChar;
                        Format.Value = book.Format;

                        SqlParameter Author = new SqlParameter();
                        Author.ParameterName = "@Author";
                        Author.SqlDbType = System.Data.SqlDbType.NVarChar;
                        Author.Value = book.Author;

                        SqlParameter ISBN = new SqlParameter();
                        ISBN.ParameterName = "@ISBN";
                        ISBN.SqlDbType = System.Data.SqlDbType.NVarChar;
                        ISBN.Value = book.ISBN;

                        SqlParameter Price = new SqlParameter();
                        Price.ParameterName = "@Price";
                        Price.SqlDbType = System.Data.SqlDbType.Real;
                        Price.Value = book.Price;

                        SqlParameter ContactNo = new SqlParameter();
                        ContactNo.ParameterName = "@ContactNo";
                        ContactNo.SqlDbType = System.Data.SqlDbType.NVarChar;
                        ContactNo.Value = book.ContactNo;


                        SqlParameter BookProviderId = new SqlParameter();
                        BookProviderId.ParameterName = "@BookProviderId";
                        BookProviderId.SqlDbType = System.Data.SqlDbType.Int;
                        BookProviderId.Value = null;



                        command.Parameters.Add(BookId);
                        command.Parameters.Add(Title);
                        command.Parameters.Add(Format);
                        command.Parameters.Add(Author);
                        command.Parameters.Add(ISBN);
                        command.Parameters.Add(Price);
                        command.Parameters.Add(ContactNo);
                        command.Parameters.Add(BookProviderId);

                        Console.WriteLine(command.Parameters);
                        Console.WriteLine(command.Parameters);
                        Console.WriteLine(command.Parameters);
                        byte result = (byte)(command.ExecuteNonQuery());
                        output = (result > 0) ? true : false;
                    }
                }
                return output;
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine();
                return output;
            }
        }

        public bool UpdateBook( Book book)
        {
            try
            {
                Book b = GetBook(book.Id);//_context.Books.FirstOrDefault(b => b.Id == book.Id);
                // _context.Books.Remove(b);
                DeleteBook(book.Id);
                //_context.SaveChanges();
                // _context.Books.Add(book);

                CreateBook(book);
                foreach (BookPicture bookPicture in book.BookPictures)
                {
                    CreateBookPicture(book.Id, bookPicture);
                }
                //_context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateBook(int BookProviderId, Book book)
        {
            try
            {
                Book b = GetBook(book.Id);//_context.Books.FirstOrDefault(b => b.Id == book.Id);
                // _context.Books.Remove(b);
                DeleteBook(book.Id);
                //_context.SaveChanges();
                // _context.Books.Add(book);

                CreateBook(BookProviderId, book);
                foreach (BookPicture bookPicture in book.BookPictures)
                {
                    CreateBookPicture(book.Id, bookPicture);
                }
                //_context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteBook(int id)
        {
            int before = _context.Books.Count<Book>();
            try {
                var book = _context.Books.FirstOrDefault(b => b.Id == id);

                if (book == null)
                {
                    return false;
                }


                int b4 = _context.Books.Count<Book>();               

                if (DeleteAllBookPictures(id).Result )
                {
                    // _context.Books.Remove(book);
                    string connectionString = Configuration.GetConnectionString("PropertyConnection");
                    SqlConnection con = new SqlConnection(connectionString);
                    using (con)
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("spDeleteBook", con);
                        command.CommandType = CommandType.StoredProcedure;
                        using (command)
                        {
                            SqlParameter BookId = new SqlParameter();
                            BookId.ParameterName = "@BookId";
                            BookId.SqlDbType = System.Data.SqlDbType.Int;
                            BookId.Value = id;
                            command.Parameters.Add(BookId);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("oops");
                    return false;
                }               
               
                int after = _context.Books.Count<Book>();
                if (b4 + 1 == after)
                {
                    return true;
                }
                else {
                    return false;
                }


                return true;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }
        
        public async Task<bool> DeleteAllBookPictures(int id)
        {
            int rowsAffected = 0;
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                Console.WriteLine();
                using (SqlCommand command = new SqlCommand("DeleteAllBookPictures", connection)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter Id = new SqlParameter();
                    Id.ParameterName = "@BookId";
                    Id.SqlDbType = System.Data.SqlDbType.Int;
                    Id.Value = id;
                    Console.WriteLine();
                    command.Parameters.Add(Id);
                    //opening connecton 
                    try
                    {
                        connection.Open();
                        Console.WriteLine();
                        rowsAffected = await command.ExecuteNonQueryAsync();
                        Console.WriteLine();
                        if (rowsAffected >= -1)
                        {
                            //Task<Boolean> bien = new Task<Boolean>();
                            // bien.Result = 
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (SqlException sqle)
                    {
                        Console.WriteLine();
                        return false;
                    }
                    
                    


                }
            }
        }


        /*
         public bool DeletePicture(int id)
         {
             var picture = _context.Pictures.FirstOrDefault(p => p.Id == id);
             try {
                 Console.WriteLine(_context.Pictures);
                 Console.WriteLine(_context.Pictures);
                 _context.Pictures.Remove(picture);
                 _context.SaveChanges();
                 Console.WriteLine(_context.Pictures);
                 Console.WriteLine(_context.Pictures);
                 return true;
             }
             catch (Exception e) {
                 return false;
             }
         }
         */
        public PropertyPicture GetPropertyPicture(int id)
        {
            var propertyPicture = _context.PropertyPictures.FirstOrDefault(pp => pp.Id == id);
            return propertyPicture;
        }


        public LinkedList<PropertyPicture> GetPicturesOfProperties(int propertyId) {
            LinkedList<PropertyPicture> propertyPictures = new LinkedList<PropertyPicture>();
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlCommand command = new SqlCommand("spGetPicturesOfProperty", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter PropertyId = new SqlParameter();
                    PropertyId.ParameterName = "@PropertyId";
                    PropertyId.SqlDbType = System.Data.SqlDbType.Int;
                    PropertyId.Value = propertyId;

                    command.Parameters.Add(PropertyId);

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                int id = 0;
                                string uri = "";

                                id = (int)(dataReader.GetValue(0));
                                uri = "" + dataReader.GetValue(1);

                                propertyPictures.AddLast(
                                    new PropertyPicture()
                                    {
                                        Id = (ushort)id,
                                        URI = uri
                                    }
                                );

                            }

                        }
                    }
                    
                }
            }
            return propertyPictures;
        }


        public Dictionary<int, PropertyPicture> GetPropertyPictures()
        {
            var propertyPictureDictionary = new Dictionary<int, PropertyPicture>();
            var propertyPictures = _context.PropertyPictures.AsEnumerable();

            foreach (var propertyPicture in propertyPictures) {
                propertyPictureDictionary.Add(propertyPicture.Id,propertyPicture);
            }
            return propertyPictureDictionary;
        }

        public bool CreatePropertyPicture(PropertyPicture picture)
        {
            try {
                _context.PropertyPictures.Add(picture);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
            
        }

        public bool UpdatePropertyPicture(PropertyPicture picture)
        {
            try {
                var oldPicture = _context.PropertyPictures.FirstOrDefault(op=> op.Id == picture.Id);
                _context.PropertyPictures.Remove(oldPicture);
                _context.PropertyPictures.Add(picture);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }

        public bool DeletePropertyPicture(int id)
        {
            try
            {
                var oldPicture = _context.PropertyPictures.FirstOrDefault(op => op.Id == id);
                _context.PropertyPictures.Remove(oldPicture);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public PropertyProviderPicture GetPropertyProviderPicture(int id)
        {
            return _context.PropertyProviderPictures.FirstOrDefault(ppp => ppp.Id == id);
        }

        public Dictionary<int, PropertyProviderPicture> GetPropertyProviderPictures()
        {
            var propertyProviderPicturesDictionary = new Dictionary<int, PropertyProviderPicture>();
            var propertyProviderPictures = _context.PropertyProviderPictures.AsEnumerable();
            foreach (var p in  propertyProviderPictures) {
                propertyProviderPicturesDictionary.Add(p.Id, p);
            }

            return propertyProviderPicturesDictionary;
        }

        public bool CreatePropertyProviderPicture(PropertyProviderPicture picture)
        {
            try
            {
                _context.PropertyProviderPictures.Add(picture);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdatePropertyProviderPicture(PropertyProviderPicture picture)
        {
            try
            {
                var oldPropertyProviderPicture = _context.PropertyProviderPictures.FirstOrDefault(ppp => ppp.Id == picture.Id);
                _context.PropertyProviderPictures.Remove(oldPropertyProviderPicture);
                _context.PropertyProviderPictures.Add(picture);
                _context.SaveChanges();
                return true;

            }
            catch ( Exception e)
            {
                return false;
            }
        }

        public bool DeletePropertyProviderPicture(int id)
        {
            try
            {
                var oldPropertyProviderPicture = _context.PropertyProviderPictures.FirstOrDefault(ppp => ppp.Id == id);
                _context.PropertyProviderPictures.Remove(oldPropertyProviderPicture);
                _context.SaveChanges();
                return true;
            }
            catch ( Exception e)
            {
                return false;
            }
        }

        public BookProviderPicture GetBookProviderPicture(int id)
        {
            return _context.BookProviderPictures.FirstOrDefault(p=> p.Id == id);
        }

        /*public Dictionary<int, PropertyProviderPicture> GetBookProviderPictures()
        {
            var propertyProviderPictureDictionary = new Dictionary<int, PropertyProviderPicture>();
            var propertyProviderPictures = _context.PropertyProviderPicture.AsEnumerable();
           foreach (var p in propertyProviderPictures) {
                propertyProviderPictureDictionary.Add(p.Id, p);
           }
            return propertyProviderPictureDictionary;
        }*/

        public bool CreateBookProviderPicture(int id,BookProviderPicture picture)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            bool result = false;
            try
            {
                //_context.BookProviderPictures.Add(picture);
                //_context.SaveChanges();
                string connectionString = Configuration.GetConnectionString("PropertyConnection");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spCreateBookProvidersPicture", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter BookProviderPictureId = new SqlParameter();
                        BookProviderPictureId.ParameterName = "@id";
                        BookProviderPictureId.SqlDbType = SqlDbType.Int;
                        BookProviderPictureId.Value = picture.Id;

                        SqlParameter URI = new SqlParameter();
                        URI.ParameterName = "@URI";
                        URI.SqlDbType = SqlDbType.NVarChar;
                        URI.Value = picture.URI;

                        SqlParameter BookProviderId = new SqlParameter();
                        BookProviderId.ParameterName = "@BookProviderId";
                        BookProviderId.SqlDbType = SqlDbType.Int;
                        BookProviderId.Value = id;

                        command.Parameters.Add(BookProviderPictureId);
                        command.Parameters.Add(URI);
                        command.Parameters.Add(BookProviderId);

                        int output = command.ExecuteNonQueryAsync().Result;

                        result = output > 0 ? true : false;
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public bool UpdateBookProviderPicture(BookProviderPicture picture)
        {
            try
            {
                var oldPicture = _context.BookProviderPictures.FirstOrDefault(p => p.Id == picture.Id);
                _context.BookProviderPictures.Remove(oldPicture);
                _context.BookProviderPictures.Add(picture);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool DeleteBookProviderPicture(int id)
        {
            try
            {
                var picture = _context.BookProviderPictures.FirstOrDefault(p => p.Id == id);
                _context.BookProviderPictures.Remove(picture);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public BookPicture GetBookPicture(int id)
        {
            return _context.BookPictures.FirstOrDefault(bp=> bp.Id == id);
        }

        public Dictionary<int, BookPicture> GetBookPictures()
        {
            var bookPictures = _context.BookPictures.AsEnumerable();
            Console.WriteLine(bookPictures);
            Console.WriteLine(bookPictures);
            var bookPictureDictionary = new Dictionary<int, BookPicture>();
            Console.WriteLine(bookPictureDictionary);
            Console.WriteLine(bookPictureDictionary);
            foreach (var b in bookPictures) {
                bookPictureDictionary.Add(b.Id, b);
            }


            return bookPictureDictionary;
        }

        public bool CreateBookPicture(int bookId, BookPicture bookPicture)
        {
            try
            {
                //_context.BookPictures.Add(bookPicture);
                //_context.SaveChanges();
                string connectionString = Configuration.GetConnectionString("PropertyConnection");
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("spCreateBookPicture", connection);
                using (connection) {
                    connection.Open();
                    using (command)
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter BookPictureId = new SqlParameter();
                        BookPictureId.ParameterName = "@id";
                        BookPictureId.SqlDbType = SqlDbType.Int;
                        BookPictureId.Value = bookPicture.Id;

                        SqlParameter URI = new SqlParameter();
                        URI.ParameterName = "@uri";
                        URI.SqlDbType = SqlDbType.NVarChar;
                        URI.Value = bookPicture.URI;

                        SqlParameter BookId = new SqlParameter();
                        BookId.ParameterName = "@BookId";
                        BookId.SqlDbType = SqlDbType.Int;
                        BookId.Value = bookId;

                        command.Parameters.Add(BookPictureId);
                        command.Parameters.Add(URI);
                        command.Parameters.Add(BookId);
                        Console.WriteLine("Asiye");
                        Console.WriteLine("Asiye");
                        command.ExecuteNonQuery();
                    }
                }

                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e);
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateBookPicture(BookPicture bookPicture)
        {
            try
            {
                var oldPicture = _context.BookPictures.FirstOrDefault(bp => bp.Id == bookPicture.Id);
                _context.BookPictures.Remove(oldPicture);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }


        public bool DeleteBookPictures(int bookId) {
            bool result;
            int output;
            string connectionString = Configuration.GetConnectionString("PropertyConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("spDeleteBookPictures", connection))
                {
                    SqlParameter BookId = new SqlParameter();
                    BookId.ParameterName = "@BookProviderId";
                    BookId.SqlDbType = System.Data.SqlDbType.Int;
                    BookId.Value = (Int32)bookId;
                    command.Parameters.Add(BookId);

                    output = command.ExecuteNonQuery();
                }
            }
            if (output > 0)
            {
                result = true;
            }
            else {
                result = false;
            }

            return result;
        }

        public bool DeleteBookPicture(int id)
        {
            try
            {
                var bookPicture = _context.BookPictures.FirstOrDefault(bp => bp.Id == id);
                _context.BookPictures.Remove(bookPicture);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false ;
            }
        }

        public Dictionary<int, BookProviderPicture> GetBookProviderPictures()
        {
            var bookProviderPictures = _context.BookProviderPictures.AsEnumerable();
            var bookProviderPictureDictionary = new Dictionary<int, BookProviderPicture>();
            foreach (var b in bookProviderPictures) {
                bookProviderPictureDictionary.Add(b.Id,b);
            }
            return bookProviderPictureDictionary;
        }

        
    }
}
