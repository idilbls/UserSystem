using System.Collections.Generic;
using System.Threading.Tasks;
using UserSystem.Shared.DTOs.Users;

namespace UserSystem.BusinessLogic.Abstract
{
    public interface IUserBLL
    {
        Task<IList<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> AddUserAsync(UserDto user);
        Task<UserDto> UpdateAsync(UserDto user);
        Task<bool> DeleteAsync(int id);
    }
}
