using DoAnSever.DbContexts;
using DoAnSever.Dto.Cart;
using DoAnSever.Dto.Common;
using DoAnSever.Dto.Product;
using DoAnSever.Entities;
using DoAnSever.Service.Interfaces;

namespace DoAnSever.Service.Implements
{
    public class ProductService : IProductService
    {
        private readonly MyDbContext _context;
        public ProductService(MyDbContext context)
        {
            _context = context;
        }
        public void Create(CreateProduct input)
        {
            if (_context.Products.Any(e => e.Name == input.Name))
            {
                throw new Exception("Tên sản phẩm bị trùng");
            }

            _context.Products.Add(new Product
            {
                Name = input.Name,
                Price = input.Price,
                Size = input.Size,
                Color = input.Color,
                Images = input.Images,
                Description = input.Description,
                IdCategory = input.IdCategory,
            });
            _context.SaveChanges();
        }

        public void Update(int id, UpdateProduct input)
        {
            var prod = _context.Products.SingleOrDefault(s => s.IdProduct == id);
            if (prod == null)
            {
                throw new Exception("Không tìm thấy sản phẩm");
            }

            prod.Name = input.Name;
            prod.Price = input.Price;
            prod.Size = input.Size;
            prod.Color = input.Color;
            prod.Images = input.Images;
            prod.Description = input.Description;
            prod.IdCategory = input.IdCategory;


            _context.SaveChanges();

        }
        public ProductDto GetById(int id)
        {
            var prod = _context.Products
                .Select(p => new ProductDto
                {
                    IdProduct = p.IdProduct,
                    Name = p.Name,
                    Price = p.Price,
                    Size = p.Size,
                    Color = p.Color,
                    Images = p.Images,
                    Description = p.Description,
                    IdCategory = p.IdCategory,
                })
                .FirstOrDefault(d => d.IdProduct == id);
            if (prod == null)
            {
                throw new Exception("Không tìm thấy sản phẩm");
            }
            return prod;

        }
        public IEnumerable<ProductDto> GetAll()
        {
            var product = _context.Products.Select(p => new ProductDto
            {
                IdCategory = p.IdCategory,
                IdProduct = p.IdProduct,
                Name = p.Name,
                Price = p.Price,
                Size = p.Size,
                Color = p.Color,
                Images = p.Images,
                Description = p.Description,

            }).ToList();
            return product;
           
        }

        public void Delete(int id)
        {
            var delete = _context.Products.Find(id);
            if (delete == null)
            {
                throw new Exception("Không tìm thấy sản phẩm");
            }
            _context.Products.Remove(delete);
            _context.SaveChanges();
        }
    }
}
