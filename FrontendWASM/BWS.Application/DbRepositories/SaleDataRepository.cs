

namespace BWS.Application.DbRepositories;

public class SaleDataRepository : ISaleDataRepository
{
    private readonly DBInitializer _dBInitializer;

    public SaleDataRepository(DBInitializer dBInitializer)
    {
        _dBInitializer = dBInitializer;
    }

    public async Task<int> SaveSaleAsync(SaleHeader saleHeader)
    {
        using var dbContext = await _dBInitializer.GetPreparedDbContextAsync();
        dbContext.SaleHaders.Add(saleHeader);
        var result=await dbContext.SaveChangesAsync();
        return result;
    }
}

