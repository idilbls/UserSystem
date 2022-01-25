using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserSystem.Models.Entities.Core;
using UserSystem.Models.Enums;

namespace UserSystem.Models.Entities.Users
{
    [Table("User")]
    public class User : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }
        public string Description { get; set; }
        public MilitaryStatus MilitaryStatus { get; set; }
    }
}
