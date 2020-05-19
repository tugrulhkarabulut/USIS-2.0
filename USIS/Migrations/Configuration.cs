namespace USIS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using USIS.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<USIS.Models.UsisDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(USIS.Models.UsisDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var faculties = new List<Faculty>
            {
                new Faculty{ facultyName = "Chemistry and Metallurgy" },
                new Faculty{ facultyName = "Electrics and Electronics" }
            };

            faculties.ForEach(f => context.Faculties.AddOrUpdate(f));
            context.SaveChanges();
            var departments = new List<Department>
            {
                new Department { departmentName = "Mathematical Engineering", facultyID = faculties.Single(f => f.facultyName == "Chemistry and Metallurgy").id },
                new Department { departmentName = "Computer Engineering", facultyID = faculties.Single(f => f.facultyName == "Electrics and Electronics").id }
            };
            departments.ForEach(d => context.Departments.AddOrUpdate(d));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course { courseName = "Object Oriented Programming", departmentID = departments.Single(d => d.departmentName == "Mathematical Engineering").id, courseCode = "MTM1011" },
                new Course { courseName = "Data Communication", departmentID = departments.Single(d => d.departmentName == "Computer Engineering").id, courseCode = "BLM2011" },
                new Course { courseName = "Algorithms and Data Structures", departmentID = departments.Single(d => d.departmentName == "Mathematical Engineering").id, courseCode = "MTM2022" },
                new Course { courseName = "Calculus 1", departmentID = departments.Single(d => d.departmentName == "Mathematical Engineering").id, courseCode = "MTM1012" },
                new Course { courseName = "Numerical Analysis", departmentID = departments.Single(d => d.departmentName == "Computer Engineering").id, courseCode = "BLM2022" },
                new Course { courseName = "Electronic Circuits", departmentID = departments.Single(d => d.departmentName == "Computer Engineering").id, courseCode = "BLM2032" },
                new Course { courseName = "Web Programming", departmentID = departments.Single(d => d.departmentName == "Mathematical Engineering").id, courseCode = "MTM2032" },

            };

            courses.ForEach(d => context.Courses.AddOrUpdate(d));
            context.SaveChanges();

            var lecturers = new List<Lecturer>
            {
                new Lecturer { lecturerName = "Aydın Seçer" },
                new Lecturer { lecturerName = "Ahmet Mehmet" },
                new Lecturer { lecturerName = "Ayşe Fatma" }
            };

            lecturers.ForEach(d => context.Lecturers.AddOrUpdate(d));
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student { studentNumber = 17058055, departmentID = departments.Single(d => d.departmentName == "Mathematical Engineering").id, startYear = 2017, gpa = 3.49, studentName = "Tuğrul Hasan Karabulut" },
                new Student { studentNumber = 16012001, departmentID = departments.Single(d => d.departmentName == "Mathematical Engineering").id, startYear = 2016, gpa = 3.70, studentName = "Ayşe Duman" },
                new Student { studentNumber = 14022001, departmentID = departments.Single(d => d.departmentName == "Computer Engineering").id, startYear = 2014, gpa = 2.54, studentName = "Ali Veli" },
                new Student { studentNumber = 18002009, departmentID = departments.Single(d => d.departmentName == "Mathematical Engineering").id, startYear = 2018, gpa = 3.12, studentName = "Merve Soyadı" },
            };

            students.ForEach(d => context.Students.AddOrUpdate(d));
            context.SaveChanges();

            var openedCourses = new List<OpenedCourse>
            {
                new OpenedCourse { courseID = courses.Single(c => c.courseCode == "MTM1011").id, year = 2020, semester = "Spring", capacity = 50, lecturerID = context.Lecturers.First().id },
                new OpenedCourse { courseID = courses.Single(c => c.courseCode == "BLM2011").id, year = 2020, semester = "Spring", capacity = 75, lecturerID = context.Lecturers.First().id + 1 },
                new OpenedCourse { courseID = courses.Single(c => c.courseCode == "MTM2022").id, year = 2020, semester = "Spring", capacity = 75, lecturerID = context.Lecturers.First().id + 1 },
                new OpenedCourse { courseID = courses.Single(c => c.courseCode == "MTM1012").id, year = 2020, semester = "Spring", capacity = 75, lecturerID = context.Lecturers.First().id + 2 },
                new OpenedCourse { courseID = courses.Single(c => c.courseCode == "BLM2022").id, year = 2020, semester = "Spring", capacity = 75, lecturerID = context.Lecturers.First().id + 2 },
                new OpenedCourse { courseID = courses.Single(c => c.courseCode == "BLM2032").id, year = 2020, semester = "Spring", capacity = 75, lecturerID = context.Lecturers.First().id + 1 },
                new OpenedCourse { courseID = courses.Single(c => c.courseCode == "MTM2032").id, year = 2020, semester = "Spring", capacity = 75, lecturerID = context.Lecturers.First().id },
            };

            openedCourses.ForEach(c => context.OpenedCourses.AddOrUpdate(c));
            context.SaveChanges();

            var courseRegistrations = new List<CourseRegistration>
            {
                new CourseRegistration { studentID = students.Single(s => s.studentName == "Tuğrul Hasan Karabulut").id, openedCourseID = context.OpenedCourses.First().id, grade = "BB" },
                new CourseRegistration { studentID = students.Single(s => s.studentName == "Ayşe Duman").id, openedCourseID = context.OpenedCourses.First().id + 1, grade = "AA" },
                new CourseRegistration { studentID = students.Single(s => s.studentName == "Ayşe Duman").id, openedCourseID = context.OpenedCourses.First().id + 1, grade = "AA" },
                new CourseRegistration { studentID = students.Single(s => s.studentName == "Ayşe Duman").id, openedCourseID = context.OpenedCourses.First().id + 1, grade = "AA" },
                new CourseRegistration { studentID = students.Single(s => s.studentName == "Ayşe Duman").id, openedCourseID = context.OpenedCourses.First().id + 1, grade = "AA" },
                new CourseRegistration { studentID = students.Single(s => s.studentName == "Ayşe Duman").id, openedCourseID = context.OpenedCourses.First().id + 1, grade = "AA" },
                new CourseRegistration { studentID = students.Single(s => s.studentName == "Ayşe Duman").id, openedCourseID = context.OpenedCourses.First().id + 1, grade = "AA" },
                new CourseRegistration { studentID = students.Single(s => s.studentName == "Ayşe Duman").id, openedCourseID = context.OpenedCourses.First().id + 1, grade = "AA" },
            };

            courseRegistrations.ForEach(c => context.CourseRegistrations.AddOrUpdate(c));
            context.SaveChanges();

        }
    }
}
