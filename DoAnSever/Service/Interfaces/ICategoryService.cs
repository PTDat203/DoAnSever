using DoAnSever.Dto.Cart;
using DoAnSever.Dto.Category;
using DoAnSever.Dto.Product;

namespace DoAnSever.Service.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAll();
        void Create(CreateCategory input);
        void Update(int id, UpdateCategory input);
        CategoryDto GetById(int id);
        void Delete(int id);
        List<ProductDto> GetProductByCategory(int id);
    }
}
