using AutoMapper;
using MyStore.Application.DbRepositories;
using MyStore.Application.DTOs;
using MyStore.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductDataRepository _productDataRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductDataRepository productDataRepository,IMapper mapper)
        {
            _productDataRepository = productDataRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetAllProducts(int storeId)
        {
            var products = await _productDataRepository.GetAllProducts(storeId);
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            var product = await _productDataRepository.GetProduct(id);
            return _mapper.Map<ProductDTO>(product);

        }
    }
}
