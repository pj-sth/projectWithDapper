using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.ViewModels
{
    public class StudentSubjectVM
    {
        public int studentid { get; set; }
        public List<int> subjectids { get; set; }
    }
}