using System;
using System.Collections.Generic;

namespace MyStore.PersistanceRE.Models
{
    public partial class OrderHeader
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime TransactionDate { get; set; }
        public TimeSpan Time { get; set; }
        public int StoreId { get; set; }
        public int CashierId { get; set; }
        public decimal InvoiceValue { get; set; }
        public decimal TotalDiscount { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Store Store { get; set; }
    }
}
