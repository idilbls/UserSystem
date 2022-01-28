using System;

namespace UserSystem.Models.Entities.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.IsActive = true;
            this.IsDelete = false;
            this.DateOfRegistration = DateTime.Now;
            this.DeletedTime = null;
        }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public DateTime? DeletedTime { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
