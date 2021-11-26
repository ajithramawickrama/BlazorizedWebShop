using AutoMapper;
using MyStore.Application.DbRepositories;
using MyStore.Application.DTOs;
using MyStore.Application.Repositories;
using MyStore.Application.Services.Interfaces;
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Implementations
{
    public class OrderService : IOrderService
    {

        private readonly IOrderDataRepository _orderDataRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderDataRepository orderDataRepository, IMapper mapper)
        {
            _orderDataRepository = orderDataRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateOrder(CreateOrderDTO createOrderDTO)
        {
            var orderHeader = _mapper.Map<OrderHeader>(createOrderDTO);
            int result=await _orderDataRepository.CreateOrder(orderHeader);
            return result;
        }

        public async Task<GetOrderDTO> GetOrder(int id)
        {
            var result = await _orderDataRepository.GetOrder(id);
            var mappedResult =  _mapper.Map<GetOrderDTO>(result);
            return mappedResult;
        }

    }
}
