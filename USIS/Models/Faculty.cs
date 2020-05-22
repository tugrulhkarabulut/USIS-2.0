using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace USIS.Models
{
    [Table("faculties")]
    public class Faculty
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Faculty Name")]
        public string facultyName { get; set; }

        [DisplayName("Departments")]
        public virtual List<Department> departments { get; set; }
    }
}