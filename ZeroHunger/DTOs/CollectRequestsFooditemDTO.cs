using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.DTOs
{
    public class CollectRequestsFooditemDTO
    {
        public int CollectRequestsFoodItemId { get; set; }
        public int RequestId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string ExpiryDate { get; set; }
        public string Description { get; set; }
    }
}