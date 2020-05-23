using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace USIS.Models
{
    [Table("students")]
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Student Number")]
        public int studentNumber { get; set; }

        [ForeignKey("departmentID")]
        [DisplayName("Department")]
        public virtual Department department { get; set; }

        public int departmentID { get; set; }

        public virtual List<CourseRegistration> coursesRegistrations { get; set; }

        [DisplayName("Start Year")]
        public int startYear { get; set; }

        [DisplayName("GPA")]
        public double gpa { get; set; }

        [DisplayName("Student Name")]
        public string studentName { get; set; }

        public DateTime lastActivity { get; set; }

        public string email { get; set; }


    }
}