using System.ComponentModel.DataAnnotations;

namespace DoAnSever.Dto.OrderDetail
{
    public class CreateOrderDetail
    {
        [Required]
        public int IdOrder { get; set; }
        [Required]
        public int IdProduct { get; set; }
        
        private string _thumbnail;
        [Required]
        public string Thumbnail
        {
            get => _thumbnail;
            set => _thumbnail = value?.Trim();

        }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float TotalPrice { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
