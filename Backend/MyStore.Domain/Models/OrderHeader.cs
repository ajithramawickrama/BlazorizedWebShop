
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string TransactionDate { get; set; }
        public string Time { get; set; }
        public  int StoreId { get; set; }
        public int CashierId { get; set; }
        public decimal InvoiceValue { get; set; }
        public decimal TotalDiscount { get; set; }
        public Customer Customer { get; set; }
        public Store Store { get; set; } 
        public ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
