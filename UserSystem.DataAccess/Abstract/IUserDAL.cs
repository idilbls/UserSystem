using System.Collections.Generic;
using System.Threading.Tasks;
using UserSystem.Models.Entities.Users;

namespace UserSystem.DataAccess.Abstract
{
    public interface IUserDAL 
    {
        Task<IList<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(User user);

    }
}
