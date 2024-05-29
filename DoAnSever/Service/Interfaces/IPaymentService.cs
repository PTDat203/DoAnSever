using DoAnSever.Dto.Cart;
using DoAnSever.Dto.Payment;
using DoAnSever.Entities;

namespace DoAnSever.Service.Interfaces
{
    public interface IPaymentService
    {
        IEnumerable<PaymentDto> GetAll();
        void Create(CreatePayment input);
        void Update(int id, UpdatePayment input);
        void Delete(int id);
        PaymentDto GetById(int id);

    }
}
