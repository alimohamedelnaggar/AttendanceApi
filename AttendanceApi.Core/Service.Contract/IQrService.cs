using AttendanceApi.Core.Dtos.QrDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Service.Contract
{
    public interface IQrService
    {
        Task<IEnumerable<StudentDto>> GetStudentsAsync();
        Task<IEnumerable<InstructorDto>> GetInstructorsAsync();
        
    }
}
