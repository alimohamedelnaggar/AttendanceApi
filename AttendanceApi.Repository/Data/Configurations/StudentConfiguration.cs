using AttendanceApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Repository.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p=>p.Name).IsRequired();
            builder.Property(p=>p.Email).IsRequired();
         
            builder.Property(p=>p.Password).IsRequired();
            
            builder.Property(p=>p.Gender).IsRequired();
        }
    }
}
