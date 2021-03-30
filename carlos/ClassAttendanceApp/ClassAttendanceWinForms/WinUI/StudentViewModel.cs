using System.Collections.Generic;
using Domain;

namespace WinUI
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public int Level { get; set; }
        public List<string> Languages { get; private set; }
        public string FullName => $"{LastName}, {FistName}";

        public StudentViewModel()
        {
            Languages = new List<string>();
        }

        public static StudentViewModel FromStudent(Student student)
        {
            var model = new StudentViewModel()
            {
                Id = student.Id,
                FistName = student.FirstName,
                LastName = student.LastName,
                Level = student.Level,
            };

            model.Languages.AddRange(student.Languages);

            return model;
        }

        public string GetLevelString()
        {
            if (Level == 0) return "None";
            if (Level == 1) return "Beginner";
            if (Level == 2) return "Intermediate";
            if (Level == 3) return "Senior";
            if (Level > 3) return "Alien";

            return "Unknown";
        }
    }
}