using DoAnSever.DbContexts;
using DoAnSever.Dto.Cart;
using DoAnSever.Dto.Order;
using DoAnSever.Dto.Payment;
using DoAnSever.Dto.Role;
using DoAnSever.Entities;

using DoAnSever.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoAnSever.Service.Implements
{
    public class OrderService : IOrderService
    {
        private readonly MyDbContext _context;
        public OrderService(MyDbContext context)
        {
            _context = context;
        }
        public void Create(CreateOrder input)
        {
            

            _context.Orders.Add(new Order
            {
                IdUser = input.IdUser,
                ShippingAddress = input.ShippingAddress,
                IdPayment = input.IdPayment,
                TotalAmount = input.TotalAmount,
                OrderDate = input.OrderDate,
                Status = input.Status,
            });
            _context.SaveChanges();
        }

        public void Update(int id, UpdateOrder input)
        {
            var ord = _context.Orders.SingleOrDefault(s => s.IdOrder == id);
            if (ord == null)
            {
                throw new Exception("Khong tim thay order");
            }
            ord.ShippingAddress = input.ShippingAddress;
            ord.IdPayment = input.IdPayment;
            ord.TotalAmount = input.TotalAmount;
            ord.OrderDate = input.OrderDate;
            ord.Status = input.Status;
            
            _context.SaveChanges();

        }

        public IEnumerable<OrderDto> GetAll()
        {
            var ord = _context.Orders.Select(p => new OrderDto
            {
                IdOrder = p.IdOrder,
                IdUser = p.IdUser,
                ShippingAddress = p.ShippingAddress,
                IdPayment = p.IdPayment,
                TotalAmount = p.TotalAmount,
                OrderDate = p.OrderDate,
                Status = p.Status,

            }).ToList();
            return ord;
        }

        public OrderDto GetById(int id)
        {
            var order = _context.Orders
                .Select(p => new OrderDto
                {
                    IdOrder = p.IdOrder,
                    IdUser= p.IdUser,
                    ShippingAddress = p.ShippingAddress,
                    IdPayment = p.IdPayment,
                    TotalAmount = p.TotalAmount,
                    OrderDate = p.OrderDate,
                    Status = p.Status,
                })
                .FirstOrDefault(d => d.IdOrder == id);
            if (order == null)
            {
                throw new Exception("Không tìm thấy thông tin order");
            }
            return order;

        }


        public void Delete(int id)
        {
            try
            {
                var delete = _context.Orders.Find(id);
                if (delete == null)
                {
                    throw new Exception("Không tìm thấy Order");
                }

                var orderDetails = _context.OrderDetails.Where(od => od.IdOrder == id).ToList();
                _context.OrderDetails.RemoveRange(orderDetails);

                _context.Orders.Remove(delete);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Lỗi: {ex.Message}, Chi tiết: {ex.InnerException?.Message}");
                throw;
            }
        }
        public void AddCartItemToOrder(int orderId, int userId)
        {
            var order = _context.Orders.Find(orderId);
            var user = _context.Users.Find(userId);
            if (order == null)
            {
                throw new Exception("Không tìm thấy đơn hàng");
            }
            order.ShippingAddress = user.Address;
            var cartItems = _context.Carts.Where(c => c.IdUser == userId).Select(c => new Cart
            {
                IdUser = c.IdUser,
                IdProduct = c.IdProduct,
                Quantity = c.Quantity,
                Price = c.Price,
            }).ToList();
            foreach (var cartItem in cartItems)
            {
                var product = _context.Products.Find(cartItem.IdProduct);
                if (product == null)
                {
                    throw new Exception("Không tìm thấy sản phẩm trong giỏ hàng");
                }

                var orderDetail = new OrderDetail
                {
                    IdOrder = orderId,
                    IdProduct = cartItem.IdProduct,
                    Quantity = cartItem.Quantity,
                    TotalPrice = cartItem.Price,
                    Thumbnail="",

                };
                order.TotalAmount += orderDetail.TotalPrice;
                _context.OrderDetails.Add(orderDetail);
                _context.Carts.Remove(cartItem);
            }
            
            _context.SaveChanges();
        }
        public List<OrderDetail> GetOrderDetails(int id)
        {
            var orderDetail = _context.OrderDetails.Where(o=>o.IdOrder == id).ToList();
            return orderDetail;
        }
    }
}
