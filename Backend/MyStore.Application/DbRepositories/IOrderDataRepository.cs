using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.DbRepositories
{
    public interface IOrderDataRepository
    {
        Task<int> CreateOrder(OrderHeader orderHeader);
        Task<OrderHeader> GetOrder(int id);
    }
}
