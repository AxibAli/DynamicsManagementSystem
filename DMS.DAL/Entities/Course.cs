using System;
using System.Collections.Generic;

namespace DMS.DAL.Entities
{
    public partial class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal TotalMarks { get; set; }
        public decimal MinimumMarks { get; set; }
        public int? ClassId { get; set; }
        public int? TeacherId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
