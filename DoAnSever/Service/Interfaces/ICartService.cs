using DoAnSever.Dto;
using DoAnSever.Dto.Cart;
using DoAnSever.Entities;

namespace DoAnSever.Service.Interfaces
{
    public interface ICartService
    {
        void AddOrUpdateCartItem(AddToCartRequest cartItem);
        List<Cart> GetProductInCart(int userId);
        
    }
}
