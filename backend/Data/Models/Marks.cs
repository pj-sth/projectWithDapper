using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace backend.Data.Models
{
    public class Marks
    {
        [Key]
        public int marksid { get; set; }
        public int studentid { get; set; }
        public Student student { get; set; }
        public int subjectid { get; set; }
        public Subject subject { get; set; }
        public string marks { get; set; }
    }
}