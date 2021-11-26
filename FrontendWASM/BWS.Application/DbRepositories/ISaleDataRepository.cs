

namespace BWS.Application.DbRepositories;

public interface ISaleDataRepository
{
    Task<int> SaveSaleAsync(SaleHeader saleHeader);
}

