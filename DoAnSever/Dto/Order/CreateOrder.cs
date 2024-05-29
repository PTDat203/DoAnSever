using System.ComponentModel.DataAnnotations;

namespace DoAnSever.Dto.Order
{
    public class CreateOrder
    {
        private string _shippingAddress;
        [Required]
        public string ShippingAddress
        {
            get => _shippingAddress;
            set => _shippingAddress = value?.Trim();

        }
        [Required]
        public int IdUser {  get; set; }
        [Required]
        public int IdPayment { get; set; }
        [Required]
        public float TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public int Status { get; set; }
        
    }
}
