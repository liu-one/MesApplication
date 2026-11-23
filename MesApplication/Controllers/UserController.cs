using MES.Application.DTOS.Identiry;
using MES.Application.InterFaces.Identity;
using MES.Application.Services.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace MesApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
        
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
           var users= _userService.GetAllUsersAsync();
            if(users==null)
            {
                return Ok("查询个数为零");
            }
            return Ok(new {data=users,IsSucccess=true});
        }
        [HttpGet("active")]
        public async Task<IActionResult> GetAllActive()
        {
            var result= await _userService.GetActiveAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result=_userService.GetUserById(id);
            if(result==null)
            {
                return NotFound("用户不存在");

            }
            return Ok(new {data=result,IsSuccess=true});

        }
        [HttpGet("department/{depatrment}")]
        public async Task<IActionResult> GetByDepartment(int depatrmentId)
        {
            var user=await _userService.GetUserByDepartmentIdAsync(depatrmentId);
            if (user == null)
                return NotFound("用户不存在");
            return Ok(user);

                

        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            try
            {
                var user = await _userService.CreateUserAsync(userDto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var result = _userService.DeleteUserAsync(id);
                return Ok(new { result, date="用户删除成功" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="changePassWordDto"></param>
        /// <returns></returns>
        [HttpPut("change-password")]
        public async Task<IActionResult> changePassword([FromBody]ChangePassWordDto changePassWordDto)
        {
            try
            {
                var result = _userService.ChangePasswordAsync(changePassWordDto);
                return Ok(new { result, date = "修改密码成功" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("resete-password/{id}")]
        public async Task<IActionResult> ResetePassWord(int id)
        {
            try
            {
                var result = _userService.RestPasswordAsync(id);
                return  Ok(new { result, date = "重置密码成功" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
    }
}
