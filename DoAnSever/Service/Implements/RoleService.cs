using DoAnSever.DbContexts;
using DoAnSever.Dto.Payment;
using DoAnSever.Dto.Role;
using DoAnSever.Dto.User;
using DoAnSever.Entities;
using DoAnSever.Service.Interfaces;

namespace DoAnSever.Service.Implements
{
    public class RoleService : IRoleService
    {
        private readonly MyDbContext _context;
        public RoleService(MyDbContext context) 
        {
            _context = context;
        }
        public void Create(CreateRole input)
        {
            if (_context.Roles.Any(e => e.Name == input.Name))
            {
                throw new Exception("ten role  bị trùng");
            }

            _context.Roles.Add(new Role
            {
                Name = input.Name,
            });
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRole input)
        {
            var role = _context.Roles.SingleOrDefault(s => s.IdRole == id);
            if (role == null)
            {
                throw new Exception("Khong tim thay role");
            }

            role.Name = input.Name;
            _context.SaveChanges();

        }

        public IEnumerable<RoleDto> GetAll()
        {
            var role = _context.Roles.Select(p => new RoleDto
            {
                IdRole = p.IdRole,
                Name = p.Name,
                
            }).ToList();
            return role;
        }
        public RoleDto GetById(int id)
        {
            var order = _context.Roles
                .Select(p => new RoleDto
                {
                    IdRole = p.IdRole,
                    Name = p.Name,
                })
                .FirstOrDefault(d => d.IdRole == id);
            if (order == null)
            {
                throw new Exception("Không tìm thấy thông tin Role");
            }
            return order;

        }


        public void Delete(int id)
        {
            var delete = _context.Roles.Find(id);
            if (delete == null)
            {
                throw new Exception("Khong tim thay Role");
            }
            _context.Roles.Remove(delete);
            _context.SaveChanges();
        }
    }
}
