using System;
using System.Collections.Generic;

namespace DMS.DAL.Entities
{
    public partial class Class
    {
        public Class()
        {
            Courses = new HashSet<Course>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Section { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
