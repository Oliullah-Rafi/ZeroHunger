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
    
    public partial class DeliveryConfirmation
    {
        public int ConfirmationId { get; set; }
        public int ConfirmingEmployeeId { get; set; }
        public int RequestId { get; set; }
        public System.DateTime ConfirmationTime { get; set; }
        public string DetailsComments { get; set; }
    }
}