//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PC_Project.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderID { get; set; }
        public Nullable<int> SeatID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public System.DateTime OrderTime { get; set; }
        public Nullable<int> CodeID { get; set; }
        public bool buyed { get; set; }
    
        public virtual Code Code { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual Seat Seat { get; set; }
    }
}
