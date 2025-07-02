using AttendanceApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Repository.Data.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Core.Entities.Attendance>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Core.Entities.Attendance> builder)
        {
            builder.Property(p => p.IPAddress).IsRequired();
            builder.Property(p => p.CheckInTime).IsRequired();
            builder.Property(p => p.DeviceId).IsRequired();

        }
    }
}
