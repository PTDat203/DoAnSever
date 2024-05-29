using DoAnSever.Dtos.UserRole;
using DoAnSever.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnSever.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _service;
        public UserRoleController(IUserRoleService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(UserRoleDto input)
        {
            try
            {
                _service.Create(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Get(int idRole)
        {
            return Ok(_service.GetUserFromRole(idRole));
        }

        [HttpDelete]
        public IActionResult Delete(int idRole, int idUser)
        {
            try
            {
                _service.DeleteUserFromRole(idRole, idUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
