using System.Collections.Generic;

namespace UserSystem.Shared.DTOs.Users
{
    public class UserListDto
    {
        public List<UserDto> Users { get; set; }

        public int CurrentPageIndex { get; set; }

        public int PageCount { get; set; }
    }
}
