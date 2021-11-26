using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Application.DTOs
{
    public class CreateOrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string TransactionDate { get; set; }
        public string Time { get; set; }
        public int StoreId { get; set; }
        public int CashierId { get; set; }
        public decimal InvoiceValue { get; set; }
        public decimal TotalDiscount { get; set; }
        public ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }

    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

    }
}
