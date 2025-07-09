using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core
{
    public class QrPayload
    {
        public int LectureId { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
