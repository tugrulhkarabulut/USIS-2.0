using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USIS.Models
{
    [Table("logs")]
    public class Log
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string message { get; set; }

        public string type { get; set; }

        public DateTime dateTime { get; set; }
    }
}