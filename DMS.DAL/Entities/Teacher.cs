using System;
using System.Collections.Generic;

namespace DMS.DAL.Entities
{
    public partial class Teacher
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
            TeacherUsers = new HashSet<TeacherUser>();
        }

        public int Id { get; set; }
        public string? Picture { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Cnic { get; set; } = null!;
        public int Gender { get; set; }
        public DateTime DoB { get; set; }
        public int Age { get; set; }
        public string PrimaryPhoneNumber { get; set; } = null!;
        public string SecondaryPhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<TeacherUser> TeacherUsers { get; set; }
    }
}
