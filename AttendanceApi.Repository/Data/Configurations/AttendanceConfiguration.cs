using AttendanceApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Repository.Data.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Core.Entities.StudentAttendance>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Core.Entities.StudentAttendance> builder)
        {
            
            builder.Property(p => p.CheckInTime).IsRequired();
            

        }
    }
}
