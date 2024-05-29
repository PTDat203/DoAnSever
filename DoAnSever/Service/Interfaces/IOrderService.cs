using DoAnSever.Dto.Cart;
using DoAnSever.Dto.Order;
using DoAnSever.Dto.Role;
using DoAnSever.Entities;

namespace DoAnSever.Service.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAll();
        void Create(CreateOrder input);
        void Update(int id, UpdateOrder input);
        void Delete(int id);
        OrderDto GetById(int id);
        void AddCartItemToOrder(int orderId, int userId);
        List<OrderDetail> GetOrderDetails(int id);
    }
}
