using AttendanceApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Specifications
{
    public class AttendanceSpecification:BaseSpecification<StudentAttendance>
    {
        public AttendanceSpecification(int lectureId) :base(p=>(p.LectureId==lectureId))
        {

        }
    }
}
