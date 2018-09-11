using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public HttpResponseMessage Post([FromBody]Product value)
      {
         try
         {
            if (ModelState.IsValid)
            {
               using (OMDBEntities Productdetails = new OMDBEntities())
               {
                  Productdetails.Products.Add(value);
                  Productdetails.SaveChanges();
                  return Request.CreateResponse(HttpStatusCode.OK);
               }
            }
            else
            {
               return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
            }
         }
         catch (Exception ex)
         {
            return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
         }
      }

      // PUT: api/Product/5
      public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
