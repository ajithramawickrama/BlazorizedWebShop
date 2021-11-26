
using MyStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> GetCustomer(int id);
        Task<ICollection<CustomerDTO>> GetRandom(int numberOfRecords);
        Task<ICollection<CustomerDTO>> GetRange(int stardIndex, int numberOfRecords);
    }
}
