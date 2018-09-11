using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

      // GET: api/User/5
      public List<KeyValuePair<string, string>> Get(int id)
      {
         List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();
         using (OMDBEntities dbEntity = new OMDBEntities())
         {
            IEnumerable<Order> orderList = dbEntity.Orders.Where(X => X.userID == id);

            //orders.orderID
            foreach (Order order in orderList)
            {
               keyValuePairs.Add(new KeyValuePair<string, string>("OrderID", order.orderID.ToString()));
               IEnumerable<OrderItem> itemsList = dbEntity.OrderItems.Where(b => b.orderID == order.orderID);
               foreach (OrderItem item in itemsList)
               {
                  Product product = dbEntity.Products.SingleOrDefault(X => X.productID == item.productID);
                  if (product != null)
                  {
                     keyValuePairs.Add(new KeyValuePair<string, string>("Product", product.pname));
                     keyValuePairs.Add(new KeyValuePair<string, string>("Quantity", item.quantity.ToString()));
                     keyValuePairs.Add(new KeyValuePair<string, string>("Status", item.ostatus));
                  }
               }
            }
         }
         return keyValuePairs;
      }

      // POST: api/User
      public HttpResponseMessage Post([FromBody]User value)
      {
         try
         {
            if (ModelState.IsValid)
            {
               using (OMDBEntities Userdetails = new OMDBEntities())
               {
                  Userdetails.Users.Add(value);
                  Userdetails.SaveChanges();
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

      // PUT: api/User/5
      public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
