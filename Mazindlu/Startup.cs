using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mazindlu.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization;
using Mazindlu.Model;
//using Microsoft.AspNetCore.Cors;

namespace Mazindlu
{
    public class Startup
    {
        private static readonly string policyName = "MyPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public  string ReturnSQLConnectionstring() {
            return Configuration.GetConnectionString("PropertyConnection");
        }

        public string ReturnMongoConnectionString() {
            return "";
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<MSSQLRepo>(Configuration.GetSection("MySettings"));
            //Map Classes to MongoDB Databases 
            BsonClassMap.RegisterClassMap<PropertyProvider>(cm => {
                cm.MapProperty(user => user.PropertyProviderPictures).SetElementName("PropertyProviderPictures");
                cm.MapProperty(user => user.Properties).SetElementName("Properties");
                cm.MapIdProperty(user => user.Id).SetElementName("Id");
                cm.MapProperty(user => user.Name).SetElementName("Name");
                cm.MapProperty(user => user.Surname).SetElementName("Surname");
                cm.MapProperty(user => user.Email).SetElementName("Email");
                cm.MapProperty(user => user.Password).SetElementName("Password");
                cm.MapProperty(user => user.ShortBio).SetElementName("ShortBio");
            });

            /*
            BsonClassMap.RegisterClassMap<Property>(cm => {
                cm.MapIdProperty(property => property.Id).SetElementName("Id");
                cm.MapProperty(property => property.Name).SetElementName("Name");
                cm.MapProperty(property => property.Pictures).SetElementName("Pictures");
                cm.MapProperty(property => property.Description).SetElementName("Description");
                cm.MapProperty(property => property.Price).SetElementName("Price");
            });

            BsonClassMap.RegisterClassMap<PropertyPicture>(cm => {
                cm.MapIdProperty(propertyPicture => propertyPicture.Id).SetElementName("Id");
                cm.MapProperty(propertyPicture => propertyPicture.URI).SetElementName("URI");
            });
            */



            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(
                    Configuration.GetConnectionString("PropertyConnection")
                )); 
            

            //Configuring Cross Origin Resource Sharing so that app can receive browser based JS web requests 
             services.AddCors(options =>
            {
                options.AddPolicy(name: policyName,
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();      
                    });
            });
                        
            services.AddControllers();
            
            //***NB! Dependency injection allows for the use of IRepo interface to represent a concrete implementation  
            services.AddScoped<IRepo, MongoRepo>();
        }

        // This method gets called by the runtime(CLR). Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(policyName);//Between  app.UseRouting() & app.UseAuthorization() for it to work(MS docs)
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
