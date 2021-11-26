using MyStore.Application.DbRepositories;
using MyStore.Domain.Models;
using MyStore.Persistance.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyStore.Persistance.DbRepositories
{
    public class OrderDataRepository : IOrderDataRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderDataRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> CreateOrder(OrderHeader orderHeader)
        {
             _applicationDbContext.OrderHeaders.Add(orderHeader);
            await _applicationDbContext.SaveChangesAsync();
            return orderHeader.Id;
        }

        public async Task<OrderHeader> GetOrder(int id)
        {
            var result=await _applicationDbContext.OrderHeaders.Where(t => t.Id == id)
                .Include(e => e.OrderDetails)
                    .ThenInclude(pr => pr.Product)
                .Include(st => st.Store)
                .Include(cs=>cs.Customer)
                .AsNoTracking().FirstOrDefaultAsync();

            return result;
        }
    }
}
