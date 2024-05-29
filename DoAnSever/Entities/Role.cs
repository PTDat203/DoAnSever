using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnSever.Entities
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRole { get; set; }
       
        [Required]
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

       
        
    }
}
