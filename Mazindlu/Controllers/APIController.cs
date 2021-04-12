using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Mazindlu.Model;
using System.Collections.Specialized;
using Microsoft.AspNetCore.JsonPatch;
using Mazindlu.Data;
using Microsoft.AspNetCore.Cors;
using System.Net;
using System.Web;
// 
/**
 * Note ! BookProviderPicture and PropertyProviderPicture POCOs/entities/models are not created, read, updated or deleted 
 * directly, but they are created, accessed, changed and deleted via their aggregate relationships with 
 * BookProvider and PropertyProvider respectively.
 * i.e in this controller class there are api endpoints for BookProvider and PropertyProvider
 * which provide crud operations for BookProviderPicture and PropertyProviderPicture respectively at the data access layer
 * **/
namespace Mazindlu.Controllers
{
    [Route("jeff/bezos/")]
    [ApiController]
    public class APIController : ControllerBase
    {    
        private readonly IRepo mur;
        public APIController(IRepo _mur)
        {
            mur = _mur;
        }

        [EnableCors("MyPolicy")]
        //BookProvider RESTful API endpoints       
        [Route("bp/i")]
        #region
        [HttpGet()]
        public ActionResult<BookProvider> GetBookProvider(string username, string password) {
            Console.WriteLine();
            Console.WriteLine();
            var bp = mur.GetBookProvider(username, password);
            if (bp != null) {  
                
                return Ok(bp);
            }
            else {
                return NotFound();
            }
        }

        [EnableCors("MyPolicy")]
        [Route("bp/")]
        [HttpGet]
        public ActionResult<List<BookProvider>> GetBookProviders() {
            


            var bookProviderDictionary = mur.GetBookProviders();
            List<BookProvider> bookProvidersIncomplete = bookProviderDictionary.Values.ToList();
            List<BookProvider> bookProviders = new List<BookProvider>();
            // IEnumerable<BookProviderPicture> bookproviderPictures = mur.GetBookProviderPictures().Values.ToList();
            Console.WriteLine(bookProviders);
            Console.WriteLine(bookProviders);


            foreach (var b in bookProvidersIncomplete) {
                //mur.GetBookProviderPictureofUser(b);
                bookProviders.Add(mur.GetBookProvider(b.Email,  b.Password));
            }
            Console.WriteLine(bookProviders);                                                          
            Console.WriteLine(bookProviders);
            return Ok(
               //mur.BookProviders.Values.ToList<User>()
               bookProviders
            ) ;


        }


        [EnableCors("MyPolicy")]
        [Route("bp/")]
        [HttpPost]
        public ActionResult CreateBookProviders(BookProvider bp) {

            Console.WriteLine(bp);
            Console.WriteLine(bp);
            if (mur.CreateBookProvider(bp))
            {
                return Created("https://localhost:5001/jeff/bezos/bp/", bp);
            }
            else
            {
                return NotFound();
            }

            /*
            var formData = HttpContext.Request.Form.AsEnumerable();

            //var response = formData.
            var id = formData.ElementAt(0).Value;
            var email = formData.ElementAt(1).Value;
            var password = formData.ElementAt(2).Value;
            var shortBio = formData.ElementAt(3).Value;
            var profilePic = formData.ElementAt(4).Value;

            var bp = new BookProvider()
            {
                Id = (ushort)(Int32.Parse(id.ToString())),
                Email = email.ToString(),
                Password = password.ToString(),
                ShortBio = shortBio.ToString(),
                ProfilePic = new Picture() { Id = 123, URI = profilePic.ToString() }
            };
            */
        }
        
        [EnableCors("MyPolicy")]
        [Route("bp/{id}")]
        [HttpPatch(/*"{id}"*/)]
        public ActionResult UpdateBookProvider(BookProvider bp)
        {

            bool isUpdated = mur.UpdateBookProvider(bp);
            if (isUpdated)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }


        [EnableCors("MyPolicy")]
        [Route("bp/{id}")]
        [HttpDelete(/*"{id}"*/)]
        public ActionResult DeleteBookProvider(int id) {
            if (mur.DeleteBookProvider(id)) {
                return Ok();
            }
            else {
                return BadRequest();
            }
        }
        #endregion


        //PropertyProvider RESTful API endpoints 
        [Route("pp/i/")]
        #region
        [HttpGet()]
        public ActionResult<PropertyProvider> GetPropertyProvider(string username, string password)
        {
            HttpContext context = Request.HttpContext;
            // var url = context.Request.G
            string url = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(context.Request);
            if (username == null || password == null)
            {
                return NotFound();
            }
            string[] parts = url.Split('?');
            string pathString = parts[0];


            string queryString = parts[1];
            string[] queryParameters = queryString.Split('=');
            PropertyProvider pp = null;
            pp = mur.GetPropertyProvider(username,password);
            Console.WriteLine(queryParameters);
            if (pp == null) {
                return NotFound();
            }
            else {
                return Ok(pp);
            }

        }

        
        [Route("pp/")]
        [HttpGet()]
        public ActionResult<List<PropertyProvider>> GetPropertyProviders()
        {

            HttpContext context = Request.HttpContext;
            // var url = context.Request.G
            string url = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(context.Request);
            Console.WriteLine("Yes !!!\n" + url);
            string relativeURI = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedPathAndQuery(Request);

            string[] parts = relativeURI.Split('?');
            Console.WriteLine(url);
            Console.WriteLine(url);
            Console.WriteLine(relativeURI);
            Console.WriteLine(relativeURI);

            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }

            string[] queryParameters = null;
            //queryParameters = parts[1].Split('&');

            if (!(relativeURI.Contains('?')) || !(relativeURI.Contains('&')))
            {
                IEnumerable<PropertyProvider> propertyprovidersList = mur.GetPropertyProviders();
                Console.WriteLine(propertyprovidersList);
                return Ok(propertyprovidersList);
            }
            else
            {
                return NotFound();
            }
           

            /*
            if ((queryParameters.Length > 0) && (parts.Length > 0))
            {
                return NotFound();
            }

            foreach (var qp in queryParameters)
            {
                Console.WriteLine(qp);
            }
            */

            //Microsoft.AspNetCore.Http.HttpRequest //request = new Microsoft.AspNetCore.Http.HttpRequest();
            /*
            using Microsoft.AspNetCore.Mvc;
            using Mazindlu.Model;
            using System.Collections.Specialized;
            using Microsoft.AspNetCore.JsonPatch;
            using Mazindlu.Data;
            */
            //Console.WriteLine(Request.Path);
           
        }

        [Route("pp/")]
        [HttpPost]
        public ActionResult CreatePropertyProvider(PropertyProvider pp) 
        {
            Console.WriteLine(Request.Path);
            Console.WriteLine(pp);
            Console.WriteLine(pp);
            Random rand = new Random();
           // pp.Id = (ushort)(rand.Next()/1000);
            mur.CreatePropertyProvider(pp);
            Console.WriteLine(pp);
            Console.WriteLine(pp);
            /*
            foreach (var prop in pp.Properties) {
                mur.CreateProperty(prop);
            }

            foreach (var ppic in pp.PropertyProviderPictures)
            {
                mur.CreatePropertyProviderPicture(ppic);
            }
            */
            //return Ok(pp);
            Console.WriteLine("Wohoo");
            return Created("https://localhost:5001/jeff/bezos/pp/", pp);
        }

        [Route("pp/{id}")]
        [HttpPatch()]
        public ActionResult UpdatePropertyProvider(PropertyProvider pp) {

            bool isUpdated = mur.UpdatePropertyProvider(pp);
            if (isUpdated) {
                return Ok();
            }
            else {

                return NotFound();
            }

        }
        
        [Route("pp/{id}")]
        [HttpDelete()]
        public ActionResult DeletePropertyProvider(ushort id)
        {
            bool isDeleted = mur.DeletePropertyProvider(id);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        #endregion
        //Property RESTful API endpoints
        [Route("p/{id}")]
        #region
        [HttpGet()]
        public ActionResult<Property> GetProperty(int id) {
            var property = mur.GetProperty(id);

            if (property == null)
            {
                return NotFound();
            }
            else {
                return Ok(property);
            }
        }

       
        [Route("ps/{id}")]
        [HttpGet()]
        public ActionResult<LinkedList<Property>> GetProperties(int id)
        {
            // return Ok(mur.GetProperties().Values.ToList());
            PropertyProvider pp = new PropertyProvider() { 
                Id = (ushort)(id)
            };

            
            LinkedList<Property> ppList = mur.GetPropertiesOfPropertyProvider(pp);
            return Ok(ppList);
        }


        [Route("p/")]
        [HttpPost()]
        public ActionResult CreateProperty(Property prop)
        {

            Console.WriteLine(prop);
            Console.WriteLine(prop);
            if (mur.CreateProperty(prop))
            {
                return Ok(prop);
            }
            else
            {
                return NotFound();
            }
        }


        [Route("p/{id}")]
        [HttpPatch()]
        public ActionResult UpdateProperty(Property prop)
        {
            var property = mur.GetProperty(prop.Id);
            bool success = false;

            if (property == null)
            {
                return NotFound();
                
            }
            else
            {
                mur.DeleteProperty(prop.Id);
                mur.CreateProperty(prop);
                return NoContent();
            }
        }


        [Route("p/{id}")]
        [HttpDelete()]
        public ActionResult DeleteProperty(int id)
        {
            var property = mur.GetProperty(id);
           

            if (property == null)
            {
                return NotFound();
            }
            else
            {
                mur.DeleteProperty(id);
                return NoContent();
            }
        }
        #endregion
        //Book RESTful API endpoints
        [Route("b/{id}")]
        #region
        [HttpGet()]
        public ActionResult<Book> GetBook(int id)
        {
            var book = mur.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }
        }

        [Route("b/")]
        [HttpGet()]
        public ActionResult<List<Book>> GetBooks()
        {
            return Ok(mur.GetBooks().Values.ToList());
        }


        [Route("b/")]
        [HttpPost()]
        public ActionResult CreateBook(Book book)
        {
           

            if (mur.CreateBook(book))
            {
                return Created("https://localhost:5001/jeff/bezos/b/", book);
            }
            else
            {
                return NotFound();
            }
        }


        [Route("b/{id}")]
        [HttpPatch()]
        public ActionResult UpdateBook(Book book)
        {
            var b = mur.GetBook(book.Id);
            Console.WriteLine(b);

            if (b == null)
            {
                 
                return NotFound();

            }
            else
            {
                // var gone = mur.DeleteBook(book.Id);
                //var getIt = mur.CreateBook(book);
                bool good = false;

                good = mur.UpdateBook(book);
                Console.WriteLine(good);
                //Console.WriteLine(gone);
                //Console.WriteLine(getIt);
                return NoContent();
            }
        }


        [Route("b/{id}")]
        [HttpDelete()]
        public ActionResult DeleteBook(int id)
        {
            var book = mur.GetBook(id);
            

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                mur.DeleteBook(id);
                return NoContent();
            }
        }
        #endregion

        
        [Route("bpi/{id}")]
        [HttpGet()]
        public ActionResult<BookProviderPicture> GetBookProviderPicture(int id)
        {
            var picture = mur.GetBookProviderPicture(id);
            if (picture == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(picture);
            }
        }

        [Route("bpi/")]
        [HttpGet()]
        public ActionResult<List<BookProviderPicture>> GetBookProviderPictures()
        {
            return Ok(mur.GetBookProviderPictures().Values.ToList());
        }


        [Route("bpi/")]
        [HttpPost()]
        public ActionResult CreateBookProviderPicture(BookProviderPicture picture)
        {
            Console.WriteLine(picture);
            Console.WriteLine(picture);
            if (mur.CreateBookProviderPicture(picture))
            {
                return Created("https://localhost:5001/jeff/bezos/bpi/", picture);
            }
            else
            {
                return NotFound();
            }
        }


        [Route("bpi/{id}")]
        [HttpPatch()]
        public ActionResult UpdateBookProviderPicture(BookProviderPicture picture)
        {
            var p = mur.GetBookProviderPicture(picture.Id);
            if (p == null)
            {
                return NotFound();
            }
            else
            {
                mur.DeleteBookProviderPicture(picture.Id);
                mur.CreateBookProviderPicture(picture);
                return NoContent();
            }
        }


        [Route("bpi/{id}")]
        [HttpDelete()]
        public ActionResult DeleteBookProviderPicture(int id)
        {
            Console.WriteLine(8345);
           // var picture = mur.GetPicture(id);
            Console.WriteLine(8345);
            Console.WriteLine(8345);
            bool success = mur.DeleteBookPicture(id);
            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();              
            }
        }
       
    }
}
