using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.Models
{
   public class OrderUpdateModel
   {
   public string Status { get; set; }
   public string Address { get; set; }

   public List<OrderItemModel> OrderItemModels { get; set; }

   }

   public class OrderItemModel
   {
   public int ProductID { get; set; }
   public int Quantity { get; set; }

   public string status { get; set; }
   }
}
