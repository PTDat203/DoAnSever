using System.ComponentModel.DataAnnotations;

namespace DoAnSever.Dto.Cart
{
    public class CreateCart
    {

        [Required]
        public int IdUSer { get; set; }
        [Required]
        public int IdOrder { get; set; }
    }
}
