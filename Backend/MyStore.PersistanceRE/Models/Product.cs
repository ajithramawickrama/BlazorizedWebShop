using System;
using System.Collections.Generic;

namespace MyStore.PersistanceRE.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string? ImgeUrl { get; set; }
        public int? StoreId { get; set; }
        public decimal? StockInHand { get; set; }
        public decimal? MinOrderQry { get; set; }
        public string? Unit { get; set; }
        public int? ReorderLevel { get; set; }
        public Store Store { get; set; } 
    }
}
