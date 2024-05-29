using DoAnSever.Dto;
using DoAnSever.Dto.Order;
using DoAnSever.Dto.Role;
using DoAnSever.Entities;
using DoAnSever.Service.Implements;
using DoAnSever.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnSever.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_service.GetAll());

        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]CreateOrder input)
        {
            try
            {
                _service.Create(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("update")]
        public IActionResult Update(int id, UpdateOrder input)
        {
            try
            {
                _service.Update(id, input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult AddCartItemToOrder(int OrderId,int userId)
        {
            _service.AddCartItemToOrder(OrderId,userId);
            return Ok();
        }
        [HttpGet("orderId")]
        public IActionResult GetOrderDetail(int id)
        {
            return Ok(_service.GetOrderDetails(id));
        }
    }

            
}
