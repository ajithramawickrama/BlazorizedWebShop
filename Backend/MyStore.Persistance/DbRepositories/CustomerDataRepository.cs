using Microsoft.EntityFrameworkCore;
using MyStore.Application.Repositories;
using MyStore.Domain.Models;
using MyStore.Persistance.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Persistance.DbRepositories
{
    public class CustomerDataRepository : ICustomerDataRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerDataRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
       

        public async Task<Customer> GetCustomer(int id)
        {
           return await _applicationDbContext.Customers.AsNoTracking<Customer>().Where(t => t.Id == id).FirstOrDefaultAsync();
             
        }

        public async Task<ICollection<Customer>> GetRandom(int numberOfRecords,int from)
        {
            return await _applicationDbContext.Customers.Where(t=>t.Id> from && t.Id<= from+numberOfRecords).OrderBy(t=>t.Id).AsNoTracking<Customer>().ToListAsync();

        }

        public async Task<ICollection<Customer>> GetRange(int stardIndex, int numberOfRecords)
        {
            
            var result= await _applicationDbContext.Customers.Skip(stardIndex).Take(numberOfRecords).ToListAsync();
            return result;

        }
    }
}
