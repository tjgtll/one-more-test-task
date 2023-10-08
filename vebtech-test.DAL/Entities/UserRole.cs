﻿using vebtech_test.DAL.Entities.Base;

namespace vebtech_test.DAL.Entities
{
    public class UserRole: BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public User User { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}
