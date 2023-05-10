using System;
using System.Collections.Generic;

namespace DMS.DAL.Entities
{
    public partial class User
    {
        public User()
        {
            StudentUsers = new HashSet<StudentUser>();
            TeacherUsers = new HashSet<TeacherUser>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public int Role { get; set; }

        public virtual ICollection<StudentUser> StudentUsers { get; set; }
        public virtual ICollection<TeacherUser> TeacherUsers { get; set; }
    }
}
