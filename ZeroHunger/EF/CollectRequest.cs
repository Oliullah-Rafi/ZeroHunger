//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroHunger.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class CollectRequest
    {
        public int RequestId { get; set; }
        public int RestaurantUserId { get; set; }
        public System.DateTime MaxPreserveTime { get; set; }
        public string Status { get; set; }
        public string CollectionAddress { get; set; }
        public Nullable<int> AssignedEmployeeId { get; set; }
        public Nullable<System.DateTime> CollectionTime { get; set; }
        public Nullable<System.DateTime> CompletionTime { get; set; }
    }
}
