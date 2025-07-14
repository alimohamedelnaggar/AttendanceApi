using AttendanceApi.Core;
using AttendanceApi.Core.Dtos;
using AttendanceApi.Core.Dtos.QrDto;
using AttendanceApi.Core.Entities;
using AttendanceApi.Core.Service.Contract;
using AttendanceApi.Core.Specifications;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Service
{


    public class InstructorService : IInstructorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public InstructorService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Course> AddCourseAsync(CourseDto courseDto)
        {
            var course = new Course()
            {
                Code = courseDto.Code,
                Name = courseDto.Name,
            };

            await unitOfWork.Repository<Course>().AddAsync(course);
            await unitOfWork.CompleteAsync();
            return course;

        }

        public Task<IEnumerable<StudentAttendance>> GetAllStudentAttendance()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentAttendance>> GetAllStudentAttendanceFromCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await unitOfWork.Repository<Student>().GetAllAsync();
            var mappedStudent=mapper.Map<IEnumerable<StudentDto>>(students);
            if (mappedStudent is null) return null;
            return mappedStudent;

        }

        public Task<IEnumerable<Student>> GetAllStudentsAsyncFromCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentAsyncByUniversityId(string universityId)
        {
            throw new NotImplementedException();
        }

        //public async Task<string> RemoveCourseAsync(string code,int instructorId)
        //{
        //    var spec = new CourseSpecification(code,instructorId);
        //    var course = await unitOfWork.Repository<Course>().GetByCodeAsync(spec);
        //    if (course is null)
        //        return "Course not found or unauthorized.";


        //    unitOfWork.Repository<Course>().Remove(course);
        //    await unitOfWork.CompleteAsync();

        //    return $"Course '{course.Name}' has been deleted successfully.";
        //}


    }
}
