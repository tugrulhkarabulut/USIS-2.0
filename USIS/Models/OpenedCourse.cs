using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace USIS.Models
{
    [Table("opened_courses")]
    public class OpenedCourse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("courseID")]
        public virtual Course course { get; set; }

        public int courseID { get; set; }

        [ForeignKey("lecturerID")]
        public virtual Lecturer lecturer { get; set; }

        public int lecturerID { get; set; }

        public virtual List<CourseRegistration> courseRegistrations { get; set; }
    
        public int year { get; set; }

        public string semester { get; set; }

        public int capacity { get; set; }

    }
}