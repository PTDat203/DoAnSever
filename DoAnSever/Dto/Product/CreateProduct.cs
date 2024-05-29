using System.ComponentModel.DataAnnotations;

namespace DoAnSever.Dto.Product
{
    public class CreateProduct
    {
        private string _name;
        [Required]
        public string Name
        {
            get => _name;
            set => _name = value?.Trim();

        }
        [Required]
        public float Price { get; set; }
        private string _size;
        [Required]
        public string Size
        {
            get => _size;
            set => _size = value?.Trim();

        }
        private string _color;
        [Required]
        public string Color
        {
            get => _color;
            set => _color = value?.Trim();

        }
        private string _images;
        [Required]
        public string Images
        {
            get => _images;
            set => _images = value?.Trim();

        }
        private string _description;
        [Required]
        public string Description
        {
            get => _description;
            set => _description = value?.Trim();

        }
        [Required]
        public int IdCategory { get; set; }
       
    }
}
