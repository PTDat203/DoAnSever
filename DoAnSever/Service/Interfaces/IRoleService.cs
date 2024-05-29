using DoAnSever.Dto.Payment;
using DoAnSever.Dto.Role;
using DoAnSever.Dto.User;

namespace DoAnSever.Service.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAll();
        void Create(CreateRole input);
        void Update(int id, UpdateRole input);
        void Delete(int id);
        RoleDto GetById(int id);
    }
}
