using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnSever.Entities
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrderDetail { get; set; }
        [Required]
        public int IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public Order Order { get; set; }
        
        [Required]
        public int IdProduct { get; set; }
        public Product Product { get; set; }
       
       
        [Required]
        public string Thumbnail { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float TotalPrice { get; set; }
        [Required]
        public int Status { get; set; }



   
        

    }
}
