using System;
using System.Collections.Generic;

namespace SMS.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentRegs = new HashSet<StudentReg>();
        }

        public int Courseid { get; set; }
        public string Coursename { get; set; } = null!;
        public int Coursefees { get; set; }

        public virtual ICollection<StudentReg> StudentRegs { get; set; }
    }
}
