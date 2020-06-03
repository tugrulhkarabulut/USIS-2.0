using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace USIS.Models
{
    [Table("courses")]
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Course Code")]
        public string courseCode { get; set; }

        [DisplayName("Course Name")]
        public string courseName { get; set; }

        [ForeignKey("departmentID")]
        public virtual Department department { get; set; }

        public int departmentID { get; set; }

        [DisplayName("Year")]
        public int year { get; set; }

        [DisplayName("Semester")]
        public int semester { get; set; }

        [DisplayName("Credit")]
        public int credit { get; set; }

        public virtual List<OpenedCourse> openedCourses { get; set; }
    }
}