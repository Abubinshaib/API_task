using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nohitatu_task.DTO.Input;
using Nohitatu_task.DTO.Output;
using Nohitatu_task.Services;

namespace Nohitatu_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;

        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpPost("save")]
        public async Task<ApiResDTO> SaveUser([FromBody] ApiUserReqDTO reqdto)
        {
                return await _userService.SaveUser(reqdto);
        }

        [HttpPost("update/{id}")]
        public async Task<ApiResDTO> UpdateUser(int id,[FromBody] ApiUserReqDTO reqdto)
        {
            return await _userService.UpdateUser(id, reqdto);
        }

        [HttpGet("GetAllUsers")]
        public async Task<ApiResDTO> GetUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpGet("GetUser/{id}")]
        public async Task<ApiResDTO> GetUserById(int id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpGet("DeleteUser/{id}")]
        public async Task<ApiResDTO> DeleteUserById(int id)
        {
            return await _userService.DeleteUser(id);
        }

    }
}
