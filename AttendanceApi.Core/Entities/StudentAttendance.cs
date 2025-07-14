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
    public class StudentAttendance : BaseEntity
    {

        public int StudentId { get; set; }

        public Student Student { get; set; }

        
        public string Department { get; set; }
        
        public string NationalId { get; set; }
        
        public string UniversityId { get; set; }

        public string Gender { get; set; }

        public int LectureId { get; set; }

        public Lecture Lecture { get; set; }

        
        public DateTime CheckInTime { get; set; }


        
        

    }
}
