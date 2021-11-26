

namespace BWS.Application.DbRepositories;

public class ProductDataRepository : IProductDataRepository
{

    private readonly DBInitializer _dBInitializer;

    public ProductDataRepository(DBInitializer dBInitializer)
    {
        _dBInitializer = dBInitializer;
    }

    public async Task BulkSaveAsync(List<Product> products)
    {
        using var dbContext = await _dBInitializer.GetPreparedDbContextAsync();
        dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
        dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        using var dbConnection = dbContext.Database.GetDbConnection();
        dbConnection.Open();

        using var transaction = dbConnection.BeginTransaction();

        var dbCommand = dbConnection.CreateCommand();
        var id = AddDbParameter(dbCommand, "$Id");
        var code = AddDbParameter(dbCommand, "$Code");
        var description = AddDbParameter(dbCommand, "$Description");
        var unitPrice = AddDbParameter(dbCommand, "$UnitPrice");
        var discount = AddDbParameter(dbCommand, "$DiscountPrice");
        var sih = AddDbParameter(dbCommand, "$StockInHand");

        dbCommand.CommandText =
            $"INSERT OR REPLACE INTO Products (Id, Code, Description, UnitPrice, DiscountPrice, StockInHand)" +
            $"VALUES ({id.ParameterName}, {code.ParameterName}, {description.ParameterName}, {unitPrice.ParameterName}, {discount.ParameterName},{sih.ParameterName})";
        foreach (var product in products)
        {
            id.Value = product.Id;
            code.Value = product.Code;
            description.Value = product.Description;
            unitPrice.Value = product.UnitPrice;
            discount.Value = product.DiscountPrice;
            sih.Value = product.StockInHand;
            dbCommand.ExecuteNonQuery();
        }

        transaction.Commit();

    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        using var dbContext = await _dBInitializer.GetPreparedDbContextAsync();
        var result= await dbContext.Products.AsNoTracking().ToListAsync();
        return result;
    }

    public async Task<Product> GetProduct(int id)
    {
        using var dbContext = await _dBInitializer.GetPreparedDbContextAsync();
        return await dbContext.Products.AsNoTracking().Where(t => t.Id == id).FirstOrDefaultAsync();
    }

    static DbParameter AddDbParameter(DbCommand command, string name)
    {
        var parameter = command.CreateParameter();
        parameter.ParameterName = name;
        command.Parameters.Add(parameter);
        return parameter;
    }

    public async Task<ProductSearchResult> SearchProduct(ProductSearchParameters parameters)
    {
        using var context =await _dBInitializer.GetPreparedDbContextAsync();
        var products = await context.Products.Where(t => parameters.Description != null ? EF.Functions.Like(t.Description, parameters.Description.Replace("%", "\\%") + "%", "\\") : t.Description==t.Description)
                                       .ToListAsync();
        var filteredProducts=products.Skip(parameters.StartIndex).Take(parameters.PageSize).ToList();
        return new ProductSearchResult
        {
            Total = products.Count,
            Products = filteredProducts
        };
    }
}

