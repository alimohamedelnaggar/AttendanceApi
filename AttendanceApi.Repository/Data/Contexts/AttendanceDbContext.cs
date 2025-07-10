using AttendanceApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Repository.Data.Contexts
{
    public class AttendanceDbContext : DbContext
    {
        public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        // Fully qualify 'Attendance' to resolve ambiguity  
    }
}
