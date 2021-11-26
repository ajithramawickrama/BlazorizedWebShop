

namespace BWS.Application.Services;

    public interface ISaleService
    {
        Task<int> SaveSaleAsync(SaleHeader saleHeader);
    }

