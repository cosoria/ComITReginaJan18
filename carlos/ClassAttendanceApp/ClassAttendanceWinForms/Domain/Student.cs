using System;
using System.Collections.Generic;

namespace Domain
{
    public class Student : Entity
    {
        private readonly List<string> _languages = new List<string>();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Level { get; private set; }
        public virtual IReadOnlyList<string> Languages => _languages;

        protected Student()
        {
        }

        public Student(int id, string firstName, string lastName, int level ,IEnumerable<string> languages) : base(id)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("firstName");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("lastName");
            }

            FirstName = firstName;
            LastName = lastName;
            Level = level;

            _languages.AddRange(languages);
        }

        public Student(string firstName, string lastName, int level, IEnumerable<string> languages) 
            : this(0, firstName, lastName, level, languages)
        {
        }

        public void SetLevel(int level)
        {
            if (level < Level)
            {
                return;
            }

            Level = level;
        }

        public void NameChange(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("firstName");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("lastName");
            }

            FirstName = firstName;
            LastName = lastName;
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
    }
}