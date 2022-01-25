using System;

namespace UserSystem.Models.Entities.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.IsActive = true;
            this.DateOfRegistration = DateTime.Now;
        }

        public bool IsActive { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
