using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF
{
    public class FoodList
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string Location { get; set; }

        public int FoodItemId { get; set; }

        public string ExpiryDate { get; set; }
        public int RequestId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    
        public string Description { get; set; }

        public int ConfirmationId { get; set; }
        public int ConfirmingEmployeeId { get; set; }
       
        public System.DateTime ConfirmationTime { get; set; }
        public string DetailsComments { get; set; }

        public int CollectRequestsFoodItemId { get; set; }
     
        public int RestaurantUserId { get; set; }
        public System.DateTime MaxPreserveTime { get; set; }
        public string Status { get; set; }
        public string CollectionAddress { get; set; }
        public Nullable<int> AssignedEmployeeId { get; set; }
        public Nullable<System.DateTime> CollectionTime { get; set; }
        public Nullable<System.DateTime> CompletionTime { get; set; }
    }
}