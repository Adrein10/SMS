using System;
using System.Collections.Generic;

namespace SMS.Models
{
    public partial class StudentReg
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public string StudentEmail { get; set; } = null!;
        public int Courseid { get; set; }
        public DateTime StartDate { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
}
