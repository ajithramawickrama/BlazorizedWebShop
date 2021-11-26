using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Application.DTOs
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string TransactionDate { get; set; }
        public string Time { get; set; }
        public int StoreId { get; set; }
        public int CashierId { get; set; }
        public decimal InvoiceValue { get; set; }
        public decimal TotalDiscount { get; set; }
        public CustomerDTO Customer { get; set; }
        public StoreDTO Store { get; set; }
        public ICollection<GetOrderDetailDTO> OrderDetails { get; set; }
    }

    public class GetOrderDetailDTO
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public ProductDTO Product { get; set; }

    }
}
