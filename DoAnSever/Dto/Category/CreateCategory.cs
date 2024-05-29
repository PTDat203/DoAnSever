using System.ComponentModel.DataAnnotations;

namespace DoAnSever.Dto.Category
{
    public class CreateCategory
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
