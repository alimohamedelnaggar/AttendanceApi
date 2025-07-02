using AttendanceApi.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Repository.Identity.contexts
{
    public class AttendanceIdentity:IdentityDbContext<AppUser>
    {
        public AttendanceIdentity(DbContextOptions<AttendanceIdentity> options):base(options)
        {
            
        }
    }
}
