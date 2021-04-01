using Mazindlu.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mazindlu.Data
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> opt) :base(opt) 
        {
           
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        */

        /*
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)
        {

        }
        */

        public ApplicationContext() : base()
        {

        }

        public DbSet<BookProvider> BookProviders { get; set; }

        public DbSet<PropertyProvider> PropertyProviders{ get; set; }

        public DbSet<Property>  Properties{ get; set; }

        public DbSet<Book>  Books{ get; set; }

        public DbSet<PropertyPicture> PropertyPictures{ get; set; }

        public DbSet<BookPicture> BookPictures{ get; set; }

        public DbSet<PropertyProviderPicture> PropertyProviderPictures { get; set; }

        public DbSet<BookProviderPicture> BookProviderPictures{ get; set; }

    }

}
