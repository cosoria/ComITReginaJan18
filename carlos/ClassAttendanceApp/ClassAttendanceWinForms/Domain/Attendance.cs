
namespace Domain
{
    public class Attendance 
    {
        public Class Class { get; private set; }
        public Student Student { get; private set; }
        public AttendanceStatus Status { get; private set; }

        protected Attendance()
        {
        }

        public Attendance(Class @class, Student student, AttendanceStatus status)
        {
            Class = @class;
            Student = student;
            Status = status;
        }

        public void SetStatus(AttendanceStatus status)
        {
            Status = status;
        }

        public string PrintSummary()
        {
            return Status.ToString();
        }

        public string PrintDetails()
        {
            return Status.ToString();
        }

        public override string ToString()
        {
            return PrintSummary();
        }
    }
}