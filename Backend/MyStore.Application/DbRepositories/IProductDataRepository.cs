
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.DbRepositories 
{
    public  interface IProductDataRepository
    {
        Task<Product> GetProduct(int id);

        Task<List<Product>> GetAllProducts(int storeId);
    }
}
