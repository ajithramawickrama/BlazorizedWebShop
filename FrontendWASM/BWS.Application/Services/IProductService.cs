


namespace BWS.Application.Services;

public  interface IProductService
{
    Task<Product> GetProduct(int id);

    Task<List<Product>> GetAllProductsAsync();

    Task<List<Product>> GetProductsFromAPI(int storeId);

    Task BulkSaveAsync(List<Product> products);
    Task<ProductSearchResult> SearchProduct(ProductSearchParameters parameters);

}

