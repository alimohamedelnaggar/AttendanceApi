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
        
        [Required]
        public string Department { get; set; }

        [Required]
        public string NationalId { get; set; }

        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }

        [Required]
        public DateTime CheckInTime { get; set; }


        
        

    }
}
