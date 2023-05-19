using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BL.DTOs.TeacherDTOs
{
    public class UpdateTeacherDTO
    {
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
    }
}
