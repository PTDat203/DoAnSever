using System.ComponentModel.DataAnnotations;

namespace DoAnSever.Dto.Cart
{
    public class CartDto
    {
        public int IdCart { get; set; }
        public int IdUSer { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public float Price  { get; set; }
    }
}
