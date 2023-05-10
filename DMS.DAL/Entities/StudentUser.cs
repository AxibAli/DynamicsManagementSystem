using System;
using System.Collections.Generic;

namespace DMS.DAL.Entities
{
    public partial class StudentUser
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? UserId { get; set; }

        public virtual Student? Student { get; set; }
        public virtual User? User { get; set; }
    }
}
