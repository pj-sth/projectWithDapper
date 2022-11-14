using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace backend.Data.Models
{
    public class Subject
    {
        [Key]
        public int subjectid { get; set; }
        public string subjectname { get; set; }
        
    }
    // Create student with subjects
}