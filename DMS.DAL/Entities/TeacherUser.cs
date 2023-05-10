using System;
using System.Collections.Generic;

namespace DMS.DAL.Entities
{
    public partial class TeacherUser
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? UserId { get; set; }

        public virtual Teacher? Teacher { get; set; }
        public virtual User? User { get; set; }
    }
}
