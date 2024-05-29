using DoAnSever.Dto.Payment;
using DoAnSever.Dto.User;

namespace DoAnSever.Service.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        void Create(CreateUser input);
        void Update(int id, UpdateUser input);
        void Delete(int id);
        UserDto GetById(int id);
    }
}
