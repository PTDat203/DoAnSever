using System;
using System.Linq;
using System.Threading.Tasks;
using DoAnSever.DbContexts;
using DoAnSever.Dto;
using DoAnSever.Dto.Cart;
using DoAnSever.Entities;
using DoAnSever.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CartService:ICartService
{
    private readonly MyDbContext dbContext;

    public CartService(MyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void AddOrUpdateCartItem(AddToCartRequest cartItem)
    {
        var existingCartItem = dbContext.Carts.FirstOrDefault(c => c.IdUser == cartItem.UserId && c.IdProduct== cartItem.ProductId);
        var product = dbContext.Products.FirstOrDefault(p=>p.IdProduct== cartItem.ProductId);

        if (existingCartItem != null)
        {
            existingCartItem.Quantity += cartItem.Quantity;
            existingCartItem.Price += cartItem.Quantity * product.Price;
        }
        else
        {
            var newCartItem = new Cart
            {
                IdUser = cartItem.UserId,
                IdProduct = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                Price=product.Price*cartItem.Quantity,
            };
            dbContext.Carts.Add(newCartItem);
        }

        dbContext.SaveChanges();
    }
    public List<Cart> GetProductInCart(int userId)
    {
        var cart = dbContext.Carts.FirstOrDefault(p=>p.IdUser == userId);
        if (cart == null)
        {
            throw new Exception();
        }
        var c = dbContext.Carts.Where(p => p.IdUser == userId).Select(s => new Cart
        {
            IdUser = s.IdUser,
            IdProduct = s.IdProduct,
            Quantity = s.Quantity,
            Price = s.Price,
        }).ToList();
        return c;
    }


}
