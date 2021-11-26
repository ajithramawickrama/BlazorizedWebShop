

namespace BWS.Domain.DatabaseModels;
public class SaleHeader
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } 
    public int StoreId { get; set; }
    public int CashierId { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public DateTime TransactionDate { get; set; }
    public List<SaleDetail> SaleDetails { get; set; }
    public int RewardsEarned { get; set; } 
}

