using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MyStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _customerService.GetCustomer(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetRandom")]
        public async Task<IActionResult> GetRandom(int numberOfRecords)
        {
            try
            {
                var result = await _customerService.GetRandom(numberOfRecords);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetRange")]
        public async Task<IActionResult> GetRange(int stardIndex, int numberOfRecords)
        {
            try
            {
                var result = await _customerService.GetRange(stardIndex,numberOfRecords);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
