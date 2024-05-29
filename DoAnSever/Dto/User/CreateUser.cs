using System.ComponentModel.DataAnnotations;

namespace DoAnSever.Dto.User
{
    public class CreateUser
    {
        public string FullName { get; set; }

        private string _email;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email khong duoc bo trong")]
        [MaxLength(50)]
        public string Email { get => _email; set => _email = value?.Trim(); }
        public string PhoneNumber { get; set; }
        private string _password;
        [Required(AllowEmptyStrings = false, ErrorMessage = "password khong duoc bo trong ")]
        public string Password { get => _password; set => _password = value?.Trim(); }
        public string Address { get; set; }
        
    }
}
