using AutoMapper;
using MyStore.Application.DTOs;
using MyStore.Application.Repositories;
using MyStore.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDataRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerDataRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerDTO> GetCustomer(int id)
        {
            var customer= await _customerRepository.GetCustomer(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<ICollection<CustomerDTO>> GetRandom(int numberOfRecords)
        {
            var randomNumber = new Random().Next(1, 5000000);
            var result = await _customerRepository.GetRandom(numberOfRecords, randomNumber);
            return _mapper.Map<List<CustomerDTO>>(result);
        }

        public async Task<ICollection<CustomerDTO>> GetRange(int stardIndex, int numberOfRecords)
        {
            var result = await _customerRepository.GetRange(stardIndex, numberOfRecords);
            return _mapper.Map<List<CustomerDTO>>(result);

        }
    }
}
