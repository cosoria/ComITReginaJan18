using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ClassAttendance.Domain;

namespace ClassAttendance.WebUI.Models
{
    // Information Holder 
    public class StudentUpdateViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
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


        public Student ToStudent()
        {
            var student = new Student(
                this.Id,
                this.FirstName, 
                this.LastName, 
                this.Level,
                this.Languages.AsEnumerable());

            return student;
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