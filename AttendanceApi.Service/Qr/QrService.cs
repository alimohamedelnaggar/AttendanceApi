using AttendanceApi.Core;
using AttendanceApi.Core.Dtos.QrDto;
using AttendanceApi.Core.Entities;
using AttendanceApi.Core.Service.Contract;
using AttendanceApi.Core.Specifications.instrcutor;
using AttendanceApi.Core.Specifications.student;
using AttendanceApi.Repository.Data.Contexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Service.Qr
{
    public class QrService : IQrService
    {
        
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public QrService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<InstructorDto>> GetInstructorsAsync()
        {
            var spec = new InstructorSpecification();
            var result = mapper.Map<IEnumerable<InstructorDto>>(await unitOfWork.Repository<Instructor>().GetAllWithSpecAsync(spec));
            return result;
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            var spec = new StudentSpecification();
            var result = mapper.Map<IEnumerable<StudentDto>>(await unitOfWork.Repository<Student>().GetAllWithSpecAsync(spec));
            return result;
        }
    }
}
