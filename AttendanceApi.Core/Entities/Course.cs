using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Lecture> Lecture { get; set; }
    }
}
