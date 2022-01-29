using System.ComponentModel.DataAnnotations;
using UserSystem.Shared.Enums;

namespace UserSystem.Shared.DTOs.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }
        public string Description { get; set; }
        public int MilitaryStatus { get; set; }
    }
}
