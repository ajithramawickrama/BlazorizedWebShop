using System;
using System.Collections.Generic;

namespace MyStore.PersistanceRE.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public OrderHeader OrderHeader { get; set; }
        public Product Product { get; set; } 
    }
}
