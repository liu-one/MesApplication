using MES.Application.DTOS.Identiry;
using MES.Application.InterFaces.Identity;
using MES.Domain.Entitys.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MesApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto dto)
        {
            try
            {
                var role = _roleService.CreateRoleAsync(dto);
                return Ok(new { role, success = true });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                await _roleService.DeleteRoleAsync(id);
                return Ok(new { success = true });
            }
            catch(Exception ex)
            {  return BadRequest(ex.Message); }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = _roleService.GetAllRolesAsync();
                return Ok(new { success = true, data = roles });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetIsActiveRoles()
        {
            try
            {
                var roles = _roleService.GetIsActiveRoleAsync();
                return Ok(new { success = true, data = roles });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetRoleByCode(string code)
        {
            try
            {
                var roles = _roleService.GetRoleByCodeAsync(code);
                return Ok(new { success = true, data = roles });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleByUserId(int id)
        {
            try
            {
                var roles = await _roleService.GetRolesByUserIdAsync(id);
                return Ok(new { success = true, data = roles });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleByUserId(int id)
        {
            try
            {
                var roles = await _roleService.GetRolesByUserIdAsync(id);
                return Ok(new { success = true, data = roles });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
