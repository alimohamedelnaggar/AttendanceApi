using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Entities
{
    public class Student : BaseEntity // Attendance
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }

        // navigation
        public ICollection<Attendance> Attendances { get; set; }

        public StudentDevice Device { get; set; }

    }
}
