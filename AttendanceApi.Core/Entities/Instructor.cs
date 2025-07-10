using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Entities
{
    public class Instructor:BaseEntity
    {
        
        public string FullName { get; set; }

      
        public string Email { get; set; }


        public string? Department { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
