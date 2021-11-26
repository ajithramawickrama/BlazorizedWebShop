using AutoMapper;
using MyStore.Application.DTOs;
using MyStore.Domain.Models;

namespace MyStore.API
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
