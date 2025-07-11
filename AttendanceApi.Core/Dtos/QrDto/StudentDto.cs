using AttendanceApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Dtos.QrDto
{
    public class StudentDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int NationalId { get; set; }
        public string Department { get; set; }
        public string? Faculty { get; set; }
        public int? Year { get; set; }
        public string UniversityId { get; set; }
        
    }
}
