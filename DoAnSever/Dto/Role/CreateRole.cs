using System.ComponentModel.DataAnnotations;

namespace DoAnSever.Dto.Role
{
    public class CreateRole
    {
        private string _name;
        [Required]
        public string Name
        {
            get => _name;
            set => _name = value?.Trim();
        }
    }
}
