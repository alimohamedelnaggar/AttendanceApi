using AttendanceApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Specifications.instrcutor
{
    public class InstructorSpecification:BaseSpecification<Instructor>
    {
        public InstructorSpecification()
        {
            Includes.Add(i => i.Courses);   
        }
    }
}
