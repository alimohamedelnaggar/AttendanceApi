using AttendanceApi.Core.Dtos;
using AttendanceApi.Core.Dtos.QrDto;
using AttendanceApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Service.Contract
{
    public interface IInstructorService
    {
        public   Task<Course> AddCourseAsync(CourseDto courseDto);
        //public Task<string> RemoveCourseAsync(string code, int instructorId);

        //

        public Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
       // public Task<IEnumerable<Student>> GetAllStudentsAsyncFromCourse(int courseId);
        public Task<Student> GetStudentAsyncByUniversityId(string universityId);

        //

        public Task<IEnumerable<StudentAttendance>> GetAllStudentAttendance();
        public Task<IEnumerable<StudentAttendance>> GetAllStudentAttendanceFromCourse(int courseId);


    }
}
