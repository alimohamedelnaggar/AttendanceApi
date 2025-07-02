using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Entities
{
    public class Attendance : BaseEntity
    {

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }

        public DateTime CheckInTime { get; set; }

        public string DeviceId { get; set; }
        public string IPAddress { get; set; }


    }
}
