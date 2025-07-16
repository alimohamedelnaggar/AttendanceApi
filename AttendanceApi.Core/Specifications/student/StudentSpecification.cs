using AttendanceApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Specifications.student
{
    public class StudentSpecification:BaseSpecification<Student>
    {
        public StudentSpecification(string universityId):base(p=>(p.UniversityId==universityId))
        {
                
        }
        public StudentSpecification()
        {
            Includes.Add(s=>s.Attendances); 
            Includes.Add(s=>s.StudentCourse); 
        }
    }
}
