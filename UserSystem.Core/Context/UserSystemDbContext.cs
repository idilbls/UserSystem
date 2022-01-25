using Microsoft.EntityFrameworkCore;
using UserSystem.Models.Entities.Users;

namespace UserSystem.Core.Context
{
    public class UserSystemDbContext : DbContext
    {
        public UserSystemDbContext(DbContextOptions<UserSystemDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
