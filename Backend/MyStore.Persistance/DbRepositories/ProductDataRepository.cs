using Microsoft.EntityFrameworkCore;
using MyStore.Application.DbRepositories;
using MyStore.Domain.Models;
using MyStore.Persistance.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Persistance.DbRepositories
{
    public class ProductDataRepository : IProductDataRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductDataRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Product>> GetAllProducts(int storeId)
        {
            var result= await _applicationDbContext.Products.AsNoTracking().Where(t => t.StoreId == storeId).ToListAsync();
            return result;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _applicationDbContext.Products.AsNoTracking().Where(t => t.Id == id).FirstOrDefaultAsync();
        }
    }
}
