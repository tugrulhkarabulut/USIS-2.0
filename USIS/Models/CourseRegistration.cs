using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace USIS.Models
{
    [Table("course_registrations")]
    public class CourseRegistration
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("studentID")]
        public virtual Student student { get; set; }

        public int studentID { get; set; }

        [ForeignKey("openedCourseID")]
        public virtual OpenedCourse openedCourse { get; set; }

        public int openedCourseID { get; set; }

        public string grade { get; set; }

    }
}