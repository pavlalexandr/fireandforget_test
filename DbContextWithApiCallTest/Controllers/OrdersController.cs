using DbContextWithApiCallTest.Dto;
using DbContextWithApiCallTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbContextWithApiCallTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _ordersService.GetOrderByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderRequest model)
        {
            if (ModelState.IsValid)
            {
                await _ordersService.UpdateOrder(model.Id, model.Status);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpPost("Process")]
        public async Task<IActionResult> Proccess()
        {
            await _ordersService.ProcessTask();
            return Ok();
        }
    }
}
