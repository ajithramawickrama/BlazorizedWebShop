using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Application.DTOs;
using MyStore.Application.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MyStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _orderService.GetOrder(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderDTO createOrderDTO)
        {
            try
            {
                var result = await _orderService.CreateOrder(createOrderDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
