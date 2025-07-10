using AttendanceApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AttendanceApi.Repository.Data.Contexts
{
    public static class AttendanceSeedDbContext
    {
        public async static Task SeedData(AttendanceDbContext context)
        {

            if (context.Students.Count() == 0)
            {
                var studentData = File.ReadAllText("E:\\GP\\AttendanceApi\\AttendanceApi.Repository\\Data\\DataSeed\\student.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var student = JsonSerializer.Deserialize<List<Student>>(studentData, options);
                if (student?.Count > 0)
                {
                    await context.Students.AddRangeAsync(student);
                    context.SaveChanges();
                }
            }
            if (context.Instructors.Count() == 0)
            {
                var studentData = File.ReadAllText("E:\\GP\\AttendanceApi\\AttendanceApi.Repository\\Data\\DataSeed\\instructor.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var student = JsonSerializer.Deserialize<List<Instructor>>(studentData, options);
                if (student?.Count > 0)
                {
                    await context.Instructors.AddRangeAsync(student);
                    context.SaveChanges();
                }
            }
            if (context.Courses.Count() == 0)
            {
                var courseData = File.ReadAllText("E:\\GP\\AttendanceApi\\AttendanceApi.Repository\\Data\\DataSeed\\course.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var course = JsonSerializer.Deserialize<List<Course>>(courseData, options);
                if (course?.Count > 0)
                {
                    await context.Courses.AddRangeAsync(course);
                    context.SaveChanges();
                }
            }
            if (context.Lectures.Count() == 0)
            {
                var deviceData = File.ReadAllText("E:\\GP\\AttendanceApi\\AttendanceApi.Repository\\Data\\DataSeed\\lecture.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var device = JsonSerializer.Deserialize<List<Lecture>>(deviceData, options);
                if (device?.Count > 0)
                {
                    await context.Lectures.AddRangeAsync(device);
                    context.SaveChanges();
                }
            }
            if (context.StudentAttendances.Count() == 0)
            {
                var lectureData = File.ReadAllText("E:\\GP\\AttendanceApi\\AttendanceApi.Repository\\Data\\DataSeed\\studentattendance.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var lecture = JsonSerializer.Deserialize<List<StudentAttendance>>(lectureData, options);
                if (lecture?.Count > 0)
                {
                    await context.StudentAttendances.AddRangeAsync(lecture);
                    context.SaveChanges();
                }
            }
            if (context.StudentCourses.Count() == 0)
            {
                var attendanceData = File.ReadAllText("E:\\GP\\AttendanceApi\\AttendanceApi.Repository\\Data\\DataSeed\\studentcourse.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var attendance = JsonSerializer.Deserialize<List<StudentCourse>>(attendanceData, options);
                if (attendance?.Count > 0)
                {
                    await context.StudentCourses.AddRangeAsync(attendance);
                    context.SaveChanges();
                }
            }
            
           
        }



    }
}
