using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var userResult = await _userDAL.AddUserAsync(mappedUser);

            return _mapper.Map<UserDto>(userResult);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userDAL.GetUserByIdAsync(id);
            return await _userDAL.DeleteAsync(user);

        }

        public async Task<UserListDto> GetAllUsersAsync(int currentPage)
        {

            int maxRows = 10;
            UserListDto userListDto = new UserListDto();

            var result = await _userDAL.GetAllUsersAsync();

            userListDto.Users = _mapper.Map<List<UserDto>>(result
                        .OrderBy(user => user.Id)
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows).ToList());

            double pageCount = (double)((decimal)result.Count() / Convert.ToDecimal(maxRows));
            userListDto.PageCount = (int)Math.Ceiling(pageCount);

            userListDto.CurrentPageIndex = currentPage;


            return userListDto;
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
