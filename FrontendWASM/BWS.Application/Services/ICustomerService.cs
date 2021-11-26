
namespace BWS.Application.Services;

public interface ICustomerService
{
    Task<Customer> GetCustomer(int id);
    Task<ICollection<Customer>> GetRange(int startIndex,int numberOfRecords);
    Task SaveBulk(List<Customer> customers);
    Task<IQueryable<Customer>> GetCustomerQueryble();
}

