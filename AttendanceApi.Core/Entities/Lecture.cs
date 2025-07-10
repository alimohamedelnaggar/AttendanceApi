using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Entities
{
    public class Lecture :BaseEntity
    {
        
        public DateTime StartTime { get; set; }

        // navigation

        public Course Course { get; set; }

        public int CourseId { get; set; }

        public ICollection<StudentAttendance> Attendances { get; set; }
    }
}
