using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.DTOs
{
    public class CollectRequestDTO
    {
        public int RequestId { get; set; }
        public int RestaurantUserId { get; set; }
        public System.DateTime MaxPreserveTime { get; set; }
        public string Status { get; set; }
        public string CollectionAddress { get; set; }
        public Nullable<int> AssignedEmployeeId { get; set; }
        public Nullable<System.DateTime> CollectionTime { get; set; }
        public Nullable<System.DateTime> CompletionTime { get; set; }

       
        public CollectRequestDTO()
        {
            CollectRequestsFooditem = new List<CollectRequestsFooditemDTO>();
        }

        public List<CollectRequestsFooditemDTO> CollectRequestsFooditem { get; set; }
    }
}