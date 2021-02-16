using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace DomainLayer.Entities
{
    public class Student
    {
        private List<string> _languages = new List<string>();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Level { get; private set; }
        public IEnumerable<string> Languages { get { return _languages; } }
        
        public Student(string firstName, string lastName, IEnumerable<string> languages)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("firstName");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("lastName");
            }

            if (languages.Any())
            {
                throw new ArgumentException("languages");
            }

            FirstName = firstName;
            LastName = lastName;

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

        public bool KnowLanguage(string language)
        {
            return true;
        }
    }

    public class Course
    {
        private List<Student> _students = new List<Student>();
        private List<Class> _classes = new List<Class>();
        
        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public int Level { get; private set; }
        public IEnumerable<Student> Students { get { return _students; } }
        public IEnumerable<Class> Classes { get { return _classes; } }
        public Teacher Teacher { get; private set; }
        public TeacherAssistant TeacherAssistant { get; private set; }

        public Course(string title, DateTime startDate, int level)
        {
            Title = title;
            StartDate = startDate;
            Level = level;
            // Students = new List<Student>();
        }

        public void SetTeacher(Teacher t)
        {
            Teacher = t;
        }
        
        public void SetTeacherAssistant(TeacherAssistant assistant)
        {
            TeacherAssistant = assistant;
        }

        public void RegisterStudent(Student student)
        {
            if (_students.Count > 25)
            {
                return;
            }

            _students.Add(student);
        }

        public void UnRegisterStudent(Student student)
        {
            _students.Remove(student);
        }

        public void AddClass(Class theClass)
        {
            _classes.Add(theClass);
        }

        public void RemoveClass(Class theClass)
        {
            _classes.Remove(theClass);
        }

        public int KnowLanguage(string language)
        {
            return 0;
        }
    }



    public class Class
    {
        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public IEnumerable<Topic> Topics { get; private set; }
        public IEnumerable<Attendance> Attendance { get; private set; }

        public Class()
        {
            var c = new Course("", DateTime.Now, 0);

            var howMany = c.Students.Count();

            // Asking for information 
            var howKnowCSharp1 = c.Students.Count(s => s.Languages.Any(l => l == "c#"));

            // Ask for help (not for information)
            var howKnowCSharp = c.KnowLanguage("c#");
        }
    }

    public class Topic
    {
        public string Title { get; private set; }
        public int Level { get; private set; }
    }

    public enum AttendanceStatus
    {
        Present,
        Late,
        Absent
    }

    public class Attendance
    {
        public Class Class { get; private set; }
        public Student Student { get; private set; }
        public AttendanceStatus Status { get; private set; }
    }

    public class Teacher
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }

    public class TeacherAssistant
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }

}