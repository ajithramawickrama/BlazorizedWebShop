

namespace MyStore.Application.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductDataRepository _productDataRepository;
    private readonly HttpClient _httpClient;


    public ProductService(IProductDataRepository productDataRepository, HttpClient httpClient)
    {
        _productDataRepository = productDataRepository;
        _httpClient = httpClient;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        var products = await _productDataRepository.GetAllProductsAsync();
        return products;
    }

    public async Task<Product> GetProduct(int id)
    {
        var product = await _productDataRepository.GetProduct(id);
        return product;

    }

    public async Task<List<Product>> GetProductsFromAPI(int storeId)
    {
        //Get All the product from backend API
         return await _httpClient.GetFromJsonAsync<List<Product>>($"/api/Product/getall?storeid={storeId}");
    }

    public async Task BulkSaveAsync(List<Product> products)
    {
        await _productDataRepository.BulkSaveAsync(products);
    }

    public async Task<ProductSearchResult> SearchProduct(ProductSearchParameters parameters)
    {
        return await _productDataRepository.SearchProduct(parameters);
    }
}

