
using MyStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Interfaces
{
    public  interface IProductService
    {
        Task<ProductDTO> GetProduct(int id);

        Task<List<ProductDTO>> GetAllProducts(int storeId);
    }
}
