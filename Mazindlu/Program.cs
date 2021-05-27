using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Mazindlu.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization;

namespace Mazindlu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MapModels();
            CreateHostBuilder(args).Build().Run();
        }

        public static void MapModels() {
            /*
            BsonClassMap.RegisterClassMap<User>(cm => { 
                
            });
            */
           
           




            BsonClassMap.RegisterClassMap<BookProvider>(cm => {
                /*
                cm.MapProperty(user => user.BookProviderPictures).SetElementName("BookProviderPicture");
                cm.MapProperty(user => user.Books).SetElementName("Books");                 
                cm.MapIdProperty(user => user.Books).SetElementName(" Books");
                cm.MapProperty(user => user.Id).SetElementName("Id");
                cm.MapProperty(user => user.Name).SetElementName("Name");
                cm.MapProperty(user => user.Surname).SetElementName("Surname");
                cm.MapProperty(user => user.Email).SetElementName("Email");
                cm.MapProperty(user => user.Password).SetElementName("Password");
                cm.MapProperty(user => user.ShortBio).SetElementName("ShortBio");
                */               
            });
        }


        public static Book GetBook(int id)
        {
            Book book = new Book();
            var bookPictures = new LinkedList<BookPicture>();
            string connectionString = "Server=(LocalDB)\\Gloire;Database=PropertyDatabase;Integrated Security=true;";//Configuration.GetConnectionString("PropertyConnection");


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                 connection.Open();


                string query = "select*from BookPictures"; 
                string sql = query;
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);

                Console.WriteLine(sql);
                Console.WriteLine(da);
                Console.WriteLine(da);
                DataSet bookPics = new DataSet();

                da.Fill(bookPics);
                Console.WriteLine("Get ready...");
                Console.WriteLine(bookPics.Tables[0].Rows);
                Console.WriteLine(bookPics.Tables[0].Rows);
                Console.WriteLine(bookPics.Tables);
                Console.WriteLine(bookPics.Tables);
                Console.WriteLine(bookPics.ToString());

                
                        foreach (DataRow bookPic in bookPics.Tables["BookPictures"].Rows)
                        {
                            Console.WriteLine(bookPic[0]);
                            Console.WriteLine(bookPic[1]);
                            Console.WriteLine(bookPic[2]);                  
                        }

                using (SqlCommand command = new SqlCommand("spGetBookPictures", connection))
                {
                    
                   /*
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter BookId = new SqlParameter();
                    BookId.ParameterName = "@BookId";
                    BookId.SqlDbType = System.Data.SqlDbType.Int;
                    BookId.Value = id;
                    command.Parameters.Add(BookId);
                    */
                    
                }
            }
            book.BookPictures = bookPictures;
            return book;

        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
