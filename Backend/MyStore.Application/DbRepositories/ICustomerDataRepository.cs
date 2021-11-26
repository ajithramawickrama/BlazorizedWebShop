
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Repositories
{
    public  interface ICustomerDataRepository
    {
        Task<Customer> GetCustomer(int id);
        Task<ICollection<Customer>> GetRandom(int numberOfRecords, int from);

        Task<ICollection<Customer>> GetRange(int stardIndex, int numberOfRecords); 
    }
}
