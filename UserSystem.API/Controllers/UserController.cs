using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserSystem.BusinessLogic.Abstract;
using UserSystem.Shared.DTOs.Users;
using UserSystem.Shared.Responses;

namespace UserSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserBLL userBLL, ILogger<UserController> logger)
        {
            _userBLL = userBLL;
            _logger = logger;
        }

        [HttpGet("get_all")]
        public async Task<Response<UserListDto>> GetAllUsers([FromQuery]int currentPage)
        {
            try
            {
                var responseDto =  await _userBLL.GetAllUsersAsync(currentPage);
                return await Response<UserListDto>.Run(responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<UserListDto>.Catch(new ResponseError { Message = ex.Message });
            }
        }

        [HttpGet("get_user_by_id")]
        public async Task<Response<UserDto>> GetUserById([FromQuery]int id)
        {
            try
            {
                var responseDto =  await _userBLL.GetUserByIdAsync(id);
                return await Response<UserDto>.Run(responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<UserDto>.Catch(new ResponseError { Message = ex.Message });
            }
            
        }

        [HttpPost("add")]
        public async Task<Response<UserDto>> AddUser([FromBody]UserDto user)
        {
            try
            {
                var responseDto = await _userBLL.AddUserAsync(user);
                return await Response<UserDto>.Run(responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<UserDto>.Catch(new ResponseError { Message = ex.Message });
            }
            
        }

        [HttpPost("update")]
        public async Task<Response<UserDto>> Update([FromBody]UserDto user)
        {
            try
            {
                var responseDto = await _userBLL.UpdateAsync(user);
                return await Response<UserDto>.Run(responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<UserDto>.Catch(new ResponseError { Message = ex.Message });
            }
        }

        [HttpDelete("delete")]
        public async Task<Response<bool>> DeleteAsync([FromQuery]int id)
        {
            try
            {
                var responseDto = await _userBLL.DeleteAsync(id);
                return await Response<bool>.Run(responseDto);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<bool>.Catch(new ResponseError { Message = ex.Message });
            }
        }
    }
}
