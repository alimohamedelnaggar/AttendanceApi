using AttendanceApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Dtos.QrDto
{
    public class AttendanceDto
    {
        
        public int StudentId { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string  NationalId { get; set; }
        
        public int LectureId { get; set; }
        [Required]
        public DateTime CheckInTime { get; set; }
    }
}
