using AttendanceApi.Core.Dtos.QrDto;
using AttendanceApi.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Mapper
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Student,StudentDto>().ReverseMap();
            CreateMap<Instructor,InstructorDto>().ReverseMap();
        }

    }
}
