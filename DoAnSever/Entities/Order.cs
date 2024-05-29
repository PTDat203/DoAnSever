using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnSever.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrder { get; set; }
        [Required]
        public int IdUser { get; set; }
        [ForeignKey(nameof(User.IdUser))]
        public User User { get; set; }
       
        [Required]
        public string ShippingAddress { get; set; }
        [Required]
        public int IdPayment {  get; set; }
        public Payment Payment { get; set; }
        [Required]
        public float TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public int Status { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
       


       

      
    }
}
