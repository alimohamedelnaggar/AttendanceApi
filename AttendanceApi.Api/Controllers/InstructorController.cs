using AttendanceApi.Core;
using AttendanceApi.Core.Dtos;
using AttendanceApi.Core.Dtos.QrDto;
using AttendanceApi.Core.Entities;
using AttendanceApi.Core.Service.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AttendanceApi.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
         private readonly IInstructorService instructorService;
        public InstructorController(IInstructorService instructorService ,IUnitOfWork unitOfWork)
        {
            this.instructorService = instructorService;
            this.unitOfWork = unitOfWork;
        }

        //[HttpDelete("delete/{code}")]
        //public async Task<ActionResult> DeleteCourse(string code)
        //{
        //    //var result = await instructorService.RemoveCourseAsync(dto.Code ,dto.InstructorId);
        //    //if (result is null)
        //    //    return NotFound("Course not found or unauthorized");

        //    //return Ok(new { message = $"{result} " });

        //    var claim = User.FindFirst("InstructorId");
        //    if (claim == null) return Unauthorized();
        //    int instructorId=int claim.Value;
        //   var result= await instructorService.RemoveCourseAsync(code, instructorId);
        //    if(result is null) return NotFound();
        //    //return Ok(new {message=$"{result}"});

        //}
        [HttpPost("add-course")]
        public async Task<IActionResult> AddCourse(CourseDto dto)
        {
            var success = await instructorService.AddCourseAsync(dto);
            if (success is null)
                return BadRequest("Could not add course.");

            return Ok("Course added successfully.");
        }

        [HttpGet("allstudent")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudent()
        {
            var students=await instructorService.GetAllStudentsAsync();
            if (students is null)
                return BadRequest();
            return Ok(students);
        }
    }
}
