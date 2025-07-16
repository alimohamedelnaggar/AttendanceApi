using AttendanceApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Specifications
{
    public class CourseSpecification:BaseSpecification<Course>
    {
        public CourseSpecification(string code,int instructorId) :base(
            p=>
            (p.Code==code )&&(p.InstructorId==instructorId))
        {

        }
        public CourseSpecification(int courseId):base(p=>(p.Id==courseId))
        {
            
        }
    }
}
