

namespace BWS.Application.Services;

public class SaleService : ISaleService
{
    private readonly ISaleDataRepository _saleDataRepository;

    public SaleService(ISaleDataRepository saleDataRepository)
    {
        _saleDataRepository = saleDataRepository;
    }
    public async Task<int> SaveSaleAsync(SaleHeader saleHeader)
    {
        return await _saleDataRepository.SaveSaleAsync(saleHeader);
    }
}

