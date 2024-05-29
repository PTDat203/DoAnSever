using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DoAnSever.Dto.User
{
    public class UserDto
    {
        
        public int IdUser { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

    }
}
