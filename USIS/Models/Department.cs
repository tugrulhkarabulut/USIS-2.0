using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace USIS.Models
{
    [Table("departments")]
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("facultyID")]
        [DisplayName("Faculty")]
        public virtual Faculty faculty { get; set; }

        public int facultyID { get; set; }

        [DisplayName("Department Name")]
        public string departmentName { get; set; }
    }
}