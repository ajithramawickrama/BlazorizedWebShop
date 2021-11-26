

namespace MyStore.Application.DbRepositories;

public  interface IProductDataRepository
{
    Task<Product> GetProduct(int id);

    Task<List<Product>> GetAllProductsAsync();

    Task  BulkSaveAsync(List<Product> products);

    Task<ProductSearchResult> SearchProduct(ProductSearchParameters parameters);
}

