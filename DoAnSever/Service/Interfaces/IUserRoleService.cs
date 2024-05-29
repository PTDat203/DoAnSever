using DoAnSever.Dto.User;
using DoAnSever.Dtos.UserRole;

namespace DoAnSever.Service.Interfaces
{
    public interface IUserRoleService
    {
        UserRoleDto Create(UserRoleDto input);
        void DeleteUserFromRole(int idRole, int idUser);
        IEnumerable<UserDto> GetUserFromRole(int idRole);
    }
}
