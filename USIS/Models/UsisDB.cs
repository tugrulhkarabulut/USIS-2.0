using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace USIS.Models
{
    public class UsisDB : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public System.Data.Entity.DbSet<USIS.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<USIS.Models.Faculty> Faculties { get; set; }

        public System.Data.Entity.DbSet<USIS.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<USIS.Models.OpenedCourse> OpenedCourses { get; set; }

        public System.Data.Entity.DbSet<USIS.Models.CourseRegistration> CourseRegistrations { get; set; }

        public System.Data.Entity.DbSet<USIS.Models.Lecturer> Lecturers { get; set; }
    }
}