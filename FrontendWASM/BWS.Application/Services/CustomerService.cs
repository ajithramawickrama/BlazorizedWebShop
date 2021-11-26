


namespace MyStore.Application.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDataRepository _customerDataRepository;
        private readonly HttpClient _httpClient;

        public CustomerService(ICustomerDataRepository customerRepository, HttpClient httpClient)
        {
            _customerDataRepository = customerRepository;
            _httpClient = httpClient;
        }
        public async Task<Customer> GetCustomer(int id)
        {
            var customer= await _customerDataRepository.GetCustomer(id);
            return customer;
        }

        public async Task<IQueryable<Customer>> GetCustomerQueryble()
        {
            return await _customerDataRepository.GetCustomerQueryble(); 
        }

        public async Task<ICollection<Customer>> GetRange(int startIndex, int numberOfRecords)
        {
            var products = await _httpClient.GetFromJsonAsync<List<Customer>>($"/api/customer/GetRange?stardIndex={startIndex}&numberOfRecords={numberOfRecords}");
            return products;

        }

        public async Task SaveBulk(List<Customer> customers)
        {
            await _customerDataRepository.BulkSaveAsync(customers);
        }
    }
}
