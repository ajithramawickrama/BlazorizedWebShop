using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string?  ImageUrl { get; set; }
        public int StoreId { get; set; }
        public decimal? StockInHand { get; set; }
        public decimal? MinOrderQry { get; set; }
        public string? Unit { get; set; }
        public int? ReorderLevel { get; set; }
        public Store Store { get; set; }

    }
}
