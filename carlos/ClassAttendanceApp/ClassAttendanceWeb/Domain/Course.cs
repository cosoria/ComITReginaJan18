using System;
using System.Collections.Generic;

namespace ClassAttendance.Domain
{
    public class Course : IEntity
    {
        private readonly List<Student> _students = new List<Student>();
        private readonly List<Class> _classes = new List<Class>();
        
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public int Level { get; private set; }
        public IReadOnlyList<Student> Students => _students;
        public IReadOnlyList<Class> Classes => _classes;
        public Teacher Teacher { get; private set; }
        public Teacher TeacherAssistant { get; private set; }

        public Course(int id, string title, DateTime startDate, int level)
        {
            Id = id;
            Title = title;
            StartDate = startDate;
            Level = level;
        }

        public Course(int id, string title, DateTime startDate) : this(id, title, startDate, 0)
        {
        }
        

        public void SetTeacher(Teacher teacher)
        {
            Teacher = teacher;
        }
        
        public void SetTeacherAssistant(Teacher assistant)
        {
            TeacherAssistant = assistant;
        }

        public void RegisterStudent(Student student)
        {
            if (_students.Count > 25)
            {
                throw new InvalidOperationException("Course is full");
            }

            _students.Add(student);
        }

        public void UnRegisterStudent(Student student)
        {
            _students.Remove(student);
        }

        public void AddClass(Class theClass)
        {
            if (SystemTime.Now >= StartDate)
            {
                throw new InvalidOperationException("Classes cannot be added, after the course has started");
            }

            _classes.Add(theClass);
        }

        public void RemoveClass(Class theClass)
        {
            if (SystemTime.Now >= StartDate)
            {
                throw new InvalidOperationException("Classes cannot be removed, after the course has started");
            }

            _classes.Remove(theClass);
        }

        public string PrintSummary()
        {
            return Title;
        }

        public string PrintDetails()
        {
            return Title;
        }

        public override string ToString()
        {
            return PrintSummary();
        }
    }
}