using DoAnSever.DbContexts;
using DoAnSever.Dto.Payment;
using DoAnSever.Dto.Role;
using DoAnSever.Dto.User;
using DoAnSever.Entities;
using DoAnSever.Service.Interfaces;
using System.Net;

namespace DoAnSever.Service.Implements
{
    public class UserService : IUserService
    {

        private readonly MyDbContext _context;
        public UserService(MyDbContext context)
        {
            _context = context;
        }
        public void Create(CreateUser input)
        {
            if (_context.Users.Any(e => e.FullName == input.FullName))
            {
                throw new Exception("Tên người dùng bị trùng");
            }

            var newUser = new User
            {
                FullName = input.FullName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Address = input.Address,
                Password = input.Password
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            
            const int userRoleId = 2;

            var userRole = new UserRole
            {
                IdUser = newUser.IdUser, 
                IdRole = userRoleId
            };

            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateUser input)
        {
            var user = _context.Users.SingleOrDefault(s => s.IdUser == id);
            if (user == null)
            {
                throw new Exception("Khong tim thay nguoi dung");
            }

            user.FullName = input.FullName;
            user.Email = input.Email;
            user.PhoneNumber = input.PhoneNumber;
            user.Address = input.Address;
            user.Password = input.Password;

            _context.SaveChanges();

        }

        public IEnumerable<UserDto> GetAll()
        {
            var user = _context.Users.Select(p => new UserDto
            {
                IdUser = p.IdUser,
                FullName = p.FullName,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                Address = p.Address,
                Password = p.Password,
            }).ToList();
            return user;
        }
        public UserDto GetById(int id)
        {
            var order = _context.Users
                .Select(p => new UserDto
                {
                    IdUser = p.IdUser,
                    FullName = p.FullName,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber,
                    Address = p.Address,
                    Password = p.Password,
                })
                .FirstOrDefault(d => d.IdUser == id);
            if (order == null)
            {
                throw new Exception("Không tìm thấy thông tin user");
            }
            return order;

        }


        public void Delete(int id)
        {
            var delete = _context.Users.Find(id);
            if (delete == null)
            {
                throw new Exception("Khong tim thay nguoi dung");
            }
            var orders = _context.Orders.Where(o => o.IdUser == id).ToList();
            _context.Orders.RemoveRange(orders);
            var carts = _context.Carts.Where(c => c.IdUser == id).ToList();
            _context.Carts.RemoveRange(carts);
            var userRoles = _context.UserRoles.Where(o => o.IdUser == id).ToList();
            _context.UserRoles.RemoveRange(userRoles);
            _context.Users.Remove(delete);
            _context.SaveChanges();
        }
    }
}
