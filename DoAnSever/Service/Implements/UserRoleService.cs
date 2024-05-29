using DoAnSever.DbContexts;
using DoAnSever.Dto.User;
using DoAnSever.Dtos.UserRole;
using DoAnSever.Entities;
using DoAnSever.Service.Interfaces;

namespace DoAnSever.Service.Implements
{
    public class UserRoleService : IUserRoleService
    {

        private readonly MyDbContext _context;
        public UserRoleService(MyDbContext context)
        {
            _context = context;
        }
        public UserRoleDto Create(UserRoleDto input)
        {
            var userRole = new UserRole
            {
                IdRole = input.IdRole,
                IdUser = input.IdUser,
            };
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
            return input;
        }

        public void DeleteUserFromRole(int idRole, int idUser)
        {
            var deleteUser = _context.UserRoles
                .SingleOrDefault(sp => sp.IdRole == idRole && sp.IdUser == idUser);
            if (deleteUser == null)
            {
                throw new Exception("Moi quan he giua nguoi dung va role khong ton tai");
            }
            _context.UserRoles.Remove(deleteUser);
            _context.SaveChanges();
        }

        public IEnumerable<UserDto> GetUserFromRole(int idRole)
        {
            var uRole = _context.UserRoles
                .Where(sp => sp.IdRole == idRole)
                .Select(sp => new UserDto
                {
                    IdUser = sp.User.IdUser,
                    FullName = sp.User.FullName,
                    Email = sp.User.Email,
                    PhoneNumber = sp.User.PhoneNumber,
                    Address = sp.User.Address,
                    Password = sp.User.Password,
                }).ToList();
            return uRole;
        }
    }
}
