using System;
using System.Collections.Generic;

namespace ClassAttendance.Domain
{
    public class Student 
    {
        private List<string> _languages = new List<string>();

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Level { get; private set; }
        public IEnumerable<string> Languages { get { return _languages; } }
        
        public Student(int id, string firstName, string lastName, int level ,IEnumerable<string> languages)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("firstName");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("lastName");
            }

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Level = level;

            _languages.AddRange(languages);
        }

        public void SetLevel(int level)
        {
            if (level < Level)
            {
                return;
            }

            Level = level;
        }
        
        public void AddProgrammingLanguage(string language)
        {
            foreach (var lang in _languages)
            {
                if (string.Equals(lang, language, StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }
            }

            _languages.Add(language);
        }

        
        public string PrintSummary()
        {
            return $"{FirstName} {LastName}";
        }

        public string PrintDetails()
        {
            var level = GetLevelString();
            return $"{FirstName} {LastName} Level:{level}";
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

        public override string ToString()
        {
            return PrintSummary();
        }
        
        public static bool operator ==(Student a, Student b)
        {
            if (ReferenceEquals(a, b)) return true;

            if (a == null || b == null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Student a, Student b)
        {
            return !(a == b);
        }

        protected bool Equals(Student other)
        {
            return FirstName == other.FirstName && 
                   LastName == other.LastName && 
                   Level == other.Level;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Student) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FirstName, LastName, Level);
        }
    }
}