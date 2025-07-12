using AttendanceApi.Core;
using AttendanceApi.Core.Dtos.QrDto;
using AttendanceApi.Core.Entities;
using AttendanceApi.Core.Service.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AttendanceApi.Api.Controllers
{

    public class AttendanceController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IQrService qrService;

        public AttendanceController(IUnitOfWork unitOfWork, IQrService qrService)
        {
            this.unitOfWork = unitOfWork;
            this.qrService = qrService;
        }

        [HttpGet("student")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudent()
        {
            var students = await qrService.GetStudentsAsync();
            if (students is null) return BadRequest();
            return Ok(students);
        }
        [HttpGet("instructor")]
        public async Task<ActionResult<IEnumerable<InstructorDto>>> GetAllInstructor()
        {
            var instructors = await qrService.GetInstructorsAsync();
            if (instructors is null) return BadRequest();
            return Ok(instructors);
        }
        [HttpPost]
        public async Task<IActionResult> RecordAttendance(AttendanceDto attendanceDto)
        {
            var attendance = new StudentAttendance()
            {
                CheckInTime =attendanceDto.CheckInTime,
                Department =attendanceDto.Department,
                StudentId =attendanceDto.StudentId,
                LectureId =attendanceDto.LectureId,
            };
            await unitOfWork.Repository<StudentAttendance>().AddAsync(attendance);
            await unitOfWork.CompleteAsync();
            return Ok(new {message="Attendance Add Successfully"});
        }
    }
}
