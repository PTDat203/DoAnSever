using System.ComponentModel.DataAnnotations;

namespace DoAnSever.Dto.Payment
{
    public class CreatePayment
    {
        [Required]
        public int IdUser { get; set; }
        public DateTime PaymentDate { get; set; }
        private string _paymentMethod;
        [Required]
        public string PaymentMethod
        {
            get => _paymentMethod;
            set => _paymentMethod = value?.Trim();

        }
        private string _deliveryMethod;
        [Required]
        public string DeliveryMethod
        {
            get => _deliveryMethod;
            set => _deliveryMethod = value?.Trim();

        }
        
    }
}
