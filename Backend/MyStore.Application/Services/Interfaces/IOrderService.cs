using MyStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<GetOrderDTO> GetOrder(int id);

        Task<int> CreateOrder(CreateOrderDTO createOrderDTO);
    }
}
