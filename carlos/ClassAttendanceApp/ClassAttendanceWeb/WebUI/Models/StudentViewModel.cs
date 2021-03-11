using System.Collections.Generic;
using ClassAttendance.Domain;

namespace ClassAttendance.WebUI.Models
{
    public class StudentViewModel
    {
        public IReadOnlyList<Student> Students { get; private set; }

        public StudentViewModel(IEnumerable<Student> students)
        {
            Students = new List<Student>(students);
        }
    }
}