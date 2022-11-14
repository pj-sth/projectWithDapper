using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace backend.Data.Models
{
    public class Student
    {
        [Key]
        public int studentid { get; set; }
        public string studentname { get; set; }

    }
}