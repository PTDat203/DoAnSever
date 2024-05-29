using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnSever.Entities
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPayment { get; set; }
        [Required]
        public int IdUser { get; set; }
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public string DeliveryMethod { get; set; }

        public ICollection<Order> Orders { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }

        

    }
}
