using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.Models
{
   public class SingleOrderDetails
   {

      public int UserID { get; set; }

      public Dictionary<int, int> ProductQuantityMapping { get; set; }

      public string Address { get; set; }
   }
}