


namespace BWS.Application.DbRepositories;
public  interface ICustomerDataRepository
{
    Task<Customer> GetCustomer(int id);

    Task BulkSaveAsync(List<Customer> customers);

    Task<IQueryable<Customer>> GetCustomerQueryble(); 
}

