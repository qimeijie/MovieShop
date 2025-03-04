﻿namespace ApplicationCore.Entities
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        //navigation prop
        public User User { get; set; } = new User();
        public Role Role { get; set; } = new Role();
    }
}
