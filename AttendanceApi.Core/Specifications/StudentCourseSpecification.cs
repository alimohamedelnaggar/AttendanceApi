using AttendanceApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Specifications
{
    public class StudentCourseSpecification:BaseSpecification<StudentCourse>
    {
        public StudentCourseSpecification(int courseId): base(p=>(p.CourseId==courseId) )
        {
            
        }
    }
}
