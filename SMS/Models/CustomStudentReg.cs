namespace SMS.Models
{
    public class CustomStudentReg
    {
        public StudentReg? CstudentReg { get; set; }
        public IEnumerable<Course>? Courselist { get; set; }
    }
}
