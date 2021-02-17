using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using DomainLayer.Contracts;

namespace DomainLayer.Entities
{
    public class Student : IConsolePrintable
    {
        private List<string> _languages = new List<string>();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Level { get; private set; }
        public IEnumerable<string> Languages { get { return _languages; } }
        
        public Student(string firstName, string lastName, int level ,IEnumerable<string> languages)
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

        private string GetLevelString()
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