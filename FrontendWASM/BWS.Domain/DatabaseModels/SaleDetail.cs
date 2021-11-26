
namespace BWS.Domain.DatabaseModels;

public  class SaleDetail
{
    public int Id { get; set; }
    public int SaleHeaderId { get; set; }
    public SaleHeader SaleHeader { get; set; }
    public int  ProductId { get; set; }
    public Product Product { get; set; }
    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }

}

