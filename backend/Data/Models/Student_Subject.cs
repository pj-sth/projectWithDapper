using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Models
{
    public class Student_Subject
    {
        [Key]
        public int studentsubjectId { get; set; }
        //Navigation Property
        public int studentid { get; set; }
        public Student student { get; set; }

        public int subjectid { get; set; }
        public Subject subject { get; set; }
    }
}