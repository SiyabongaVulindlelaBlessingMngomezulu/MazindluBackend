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

namespace Mazindlu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //IRepo repo = new MSQLRepo();
            //Book b = GetBook(354);
        }


        public static Book GetBook(int id)
        {
            //var book = _context.Books.FirstOrDefault(b => b.Id == id);
            Book book = new Book();
            var bookPictures = new LinkedList<BookPicture>();
            string connectionString = "Server=(LocalDB)\\Gloire;Database=PropertyDatabase;Integrated Security=true;";//Configuration.GetConnectionString("PropertyConnection");


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                 connection.Open();


                string query = "select*from BookPictures"; //where BookId ={0}
                string sql = query;//string.Format(query, id);
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);

                Console.WriteLine(sql);
                Console.WriteLine(da);
                Console.WriteLine(da);
                //da.SelectCommand = command;
                DataSet bookPics = new DataSet();

                da.Fill(bookPics);
                Console.WriteLine("Get ready...");
                Console.WriteLine(bookPics.Tables[0].Rows);
                Console.WriteLine(bookPics.Tables[0].Rows);
                //Console.WriteLine(bookPics.Tables["BookPictures"].Rows);
                Console.WriteLine(bookPics.Tables);
                Console.WriteLine(bookPics.Tables);
                Console.WriteLine(bookPics.ToString());

                
                        foreach (DataRow bookPic in bookPics.Tables["BookPictures"].Rows)
                        {
                            Console.WriteLine(bookPic[0]);
                            Console.WriteLine(bookPic[1]);
                            Console.WriteLine(bookPic[2]);
                    /*
                    bookPictures.AddFirst(new BookPicture()
                    {
                        Id = (ushort)(bookPic["Id"]),
                        URI = "" + bookPic["URI"]
                    });
                    */
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
            Console.WriteLine(book);
            Console.WriteLine(book);
            Console.WriteLine(book);
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
