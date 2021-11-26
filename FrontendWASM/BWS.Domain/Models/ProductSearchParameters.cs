

namespace BWS.Domain.Models;
public class ProductSearchParameters
{
    public int StartIndex { get; set; }
    public int PageSize { get; set; }

    public int? Code { get; set; }
    public string? Description { get; set; }
    public int? MinUnitPrice { get; set; }
    public int? MaxUnitPrice { get; set; }

}


