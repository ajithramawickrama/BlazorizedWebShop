

namespace BWS.Domain.Models;

public class SaleDTO
{
    public SaleDTO()
    {
        Customer=new SaleCustomer();
        SaleDetails = new List<SaleDetailsDTO>();
    }
    public int Id { get; set; }
    public int StoreId { get; set; }
    public int CashierId { get; set; }
    public SaleCustomer Customer { get; set; }
    public List<SaleDetailsDTO> SaleDetails { get; set; }
    public int RewardsEarned { get; set; } 
}

public class SaleDetailsDTO
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ProductCode { get; set; }
    public string ProductDescription { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Qty { get; set; }
    public decimal Discount { get; set; } 

}

public class SaleCustomer
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string  Name { get; set; }
    public string MobileNumber { get; set; }
    public string City { get; set; }  
}

