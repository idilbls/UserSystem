using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserSystem.BusinessLogic.Abstract;
using UserSystem.DataAccess.Abstract;
using UserSystem.Models.Entities.Users;
using UserSystem.Shared.DTOs.Users;

namespace UserSystem.BusinessLogic.Service
{
    public class UserBLL : IUserBLL 
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;

        public UserBLL(IUserDAL userDAL, IMapper mapper)
        {
            _userDAL = userDAL;
            _mapper = mapper;
        }

        public async Task<UserDto> AddUserAsync(UserDto user)
        {
            var mappedUser = _mapper.Map<User>(user);
            var userResult =  await _userDAL.AddUserAsync(mappedUser);

            return _mapper.Map<UserDto>(userResult);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userDAL.GetUserByIdAsync(id);
            return await _userDAL.DeleteAsync(user);

        }

        public async Task<IList<UserDto>> GetAllUsersAsync()
        {
            var result = await _userDAL.GetAllUsersAsync();
            return _mapper.Map<List<UserDto>>(result);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var result = await _userDAL.GetUserByIdAsync(id);
            return _mapper.Map<UserDto>(result);
        }

        public async Task<UserDto> UpdateAsync(UserDto user)
        {
            var mappedUser = _mapper.Map<User>(user);
            var userResult = await _userDAL.UpdateAsync(mappedUser);

            return _mapper.Map<UserDto>(userResult);
        }
    }
}
