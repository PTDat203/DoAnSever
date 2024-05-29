using DoAnSever.Dto.Cart;
using DoAnSever.Dto.Common;
using DoAnSever.Dto.Product;

namespace DoAnSever.Service.Interfaces
{
    public interface IProductService
    {
        void  Create(CreateProduct input);
        void Update(int id, UpdateProduct input);
        void Delete(int id);
        ProductDto GetById(int id);
        IEnumerable<ProductDto> GetAll();
    }
}
