using AttendanceApi.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Entities
{
    public class Course : BaseEntity
    {
        
        public string Name { get; set; }
        public string Code { get; set; } 

        public Instructor Instructor { get; set; }
        
        public int? InstructorId { get; set; }

        // Navigation
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Lecture> Lectures { get; set; }
    }
}
