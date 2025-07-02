using AttendanceApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Repository.Data.Configurations
{
    internal class StudentDeviceConfiguration : IEntityTypeConfiguration<StudentDevice>
    {
        public void Configure(EntityTypeBuilder<StudentDevice> builder)
        {
            builder.Property(p => p.IPAddress).IsRequired();
            builder.Property(p => p.DeviceType).IsRequired();
            builder.Property(p => p.RegisteredAt).IsRequired();
            
        }
    }
}
