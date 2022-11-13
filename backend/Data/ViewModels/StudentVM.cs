using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.ViewModels
{
    public class StudentVM
    {
        public string studentname { get; set; }

        // Navigation Property
        public List<int> subjectids { get; set; }
    }
}