using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserSystem.Core.Context;
using UserSystem.DataAccess.Abstract;
using UserSystem.Models.Entities.Users;
using UserSystem.Models.Erros;

namespace UserSystem.DataAccess.Concrete
{
    public class UserDAL : IUserDAL
    {
        protected readonly UserSystemDbContext _context;

        public UserDAL(UserSystemDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.UserNotFound, ErrorMessages.UserNotFound, ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(User user)
        {
            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.UserNotFound, ErrorMessages.UserNotFound, ex.Message);
            }
        }

        public async Task<IList<User>> GetAllUsersAsync()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.UsersNotFound, ErrorMessages.UsersNotFound, ex.Message);
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                return user;
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.UserNotFound, ErrorMessages.UserNotFound, ex.Message);
            }
        }

        public async Task<User> UpdateAsync(User user)
        {
            try
            {
                var userResult = await _context.Users.FindAsync(user.Id);

                userResult.Name = user.Name;
                userResult.Surname = user.Surname;
                userResult.Description = user.Description;
                userResult.MilitaryStatus = user.MilitaryStatus;

                _context.Users.Update(userResult);
                await _context.SaveChangesAsync();
                return userResult;
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.UserNotFound, ErrorMessages.UserNotFound, ex.Message);
            }
        }
    }
}
