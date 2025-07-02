using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AttendanceApi.Core.Entities
{
    public class StudentDevice:BaseEntity
    {

        public string DeviceId { get; set; } 

        
        public string DeviceType { get; set; } 
        
        public string IPAddress { get; set; } 

        public DateTime RegisteredAt { get; set; } 

        // Navigation property
        public Student Student { get; set; } 

        public int StudentId { get; set; }
    }
}