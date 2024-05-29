using DoAnSever.Dto;
using DoAnSever.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnSever.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost]
        public IActionResult AddOrUpdateCartItem(AddToCartRequest cartItem)
        {
            try
            {
                cartService.AddOrUpdateCartItem(cartItem);
                return Ok("Cart item added/updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        public IActionResult GetCartItem(int userId)
        {
            try
            {
                return Ok(cartService.GetProductInCart(userId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
