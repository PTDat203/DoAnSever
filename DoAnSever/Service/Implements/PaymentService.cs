using DoAnSever.DbContexts;
using DoAnSever.Dto.Order;
using DoAnSever.Dto.Payment;
using DoAnSever.Entities;
using DoAnSever.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoAnSever.Service.Implements
{
    public class PaymentService : IPaymentService
    {
        private readonly MyDbContext _context;
        public PaymentService(MyDbContext context)
        {
            _context = context;
        }

       
        public void Create(CreatePayment input)
        {
            
            _context.Payments.Add(new Payment
            {
                IdUser = input.IdUser,
                PaymentDate = input.PaymentDate,
                PaymentMethod = input.PaymentMethod,
                DeliveryMethod = input.DeliveryMethod,

            });
            _context.SaveChanges();
        }

        public void Update(int id, UpdatePayment input)
        {
            var payment = _context.Payments.SingleOrDefault(s => s.IdPayment == id);
            if (payment == null)
            {
                throw new Exception("Khong tim thay thanh toan");
            }

            payment.IdUser = input.IdUser;
            payment.PaymentDate = input.PaymentDate;
            payment.PaymentMethod = input.PaymentMethod;
            payment.DeliveryMethod = input.DeliveryMethod;

            _context.SaveChanges();
            

        }

        public IEnumerable<PaymentDto> GetAll()
        {
            var payment = _context.Payments.Select(p => new PaymentDto
            {
                IdPayment = p.IdPayment,
                IdUser = p.IdUser,
                PaymentDate = p.PaymentDate,
                PaymentMethod = p.PaymentMethod,
                DeliveryMethod = p.DeliveryMethod,
            }).ToList();
            return payment;
        }
        public PaymentDto GetById(int id)
        {
            var order = _context.Payments
                .Select(p => new PaymentDto
                {

                    IdPayment = p.IdPayment,
                    IdUser = p.IdUser,
                    PaymentDate = p.PaymentDate,
                    PaymentMethod = p.PaymentMethod,
                    DeliveryMethod = p.DeliveryMethod,
                })
                .FirstOrDefault(d => d.IdPayment == id);
            if (order == null)
            {
                throw new Exception("Không tìm thấy thông tin payment");
            }
            return order;

        }

        public void Delete(int id)
        {
            var delete = _context.Payments.Find(id);
            if (delete == null)
            {
                throw new Exception("Khong tim thay thanh toan");
            }
            _context.Payments.Remove(delete);
            _context.SaveChanges();
        }
    }
}
