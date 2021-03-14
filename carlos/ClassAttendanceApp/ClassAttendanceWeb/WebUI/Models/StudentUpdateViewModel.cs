using System.Collections.Generic;
using ClassAttendance.Domain;

namespace ClassAttendance.WebUI.Models
{
    public class StudentUpdateViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Level { get; set; }
        public List<string> Languages { get; set; }

        
        public StudentUpdateViewModel()
        {
            Languages = new List<string>();
        }

        public StudentUpdateViewModel(Student student) : this()
        {
            CopyInformation(student);
            Languages.AddRange(student.Languages);
        }

        private void CopyInformation(Student student)
        {
            FirstName = student.FirstName;
            LastName = student.LastName;
            Level = student.Level;
            Id = student.Id;
        }
    }
}