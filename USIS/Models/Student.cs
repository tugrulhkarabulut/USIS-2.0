using System;
using System.Collections.Generic;
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

        public int studentNumber { get; set; }

        [ForeignKey("departmentID")]
        public virtual Department department { get; set; }

        public int departmentID { get; set; }

        public virtual List<CourseRegistration> coursesRegistrations { get; set; }

        public int startYear { get; set; }

        public double gpa { get; set; }

        public string studentName { get; set; }


    }
}