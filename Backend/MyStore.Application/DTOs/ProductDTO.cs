using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Application.DTOs
{
    public  class ProductDTO
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Unit { get; set; }
    }
}
