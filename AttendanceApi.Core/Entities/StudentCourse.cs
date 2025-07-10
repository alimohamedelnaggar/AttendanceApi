using AttendanceApi.Core.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceApi.Core.Entities
{
    public class StudentCourse:BaseEntity
    {
      
        public int StudentId { get; set; }
        public Student Student { get; set; }

        
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}