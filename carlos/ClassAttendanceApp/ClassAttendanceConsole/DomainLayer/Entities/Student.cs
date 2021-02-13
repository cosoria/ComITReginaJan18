using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace DomainLayer.Entities
{
    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Level { get; private set; }
        public IEnumerable<string> Languages { get; private set; }
    
    }

    public class Course
    {
        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public int Level { get; private set; }
        public IEnumerable <Student> Students { get; private set; }
        public IEnumerable <Class> Classes { get; private set; }
        public Teacher Teacher { get; private set; }
        public TeacherAssistant TeacherAssistant { get; private set; }
    }

    public class Class
    {
        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public IEnumerable<Topic> Topics { get; private set; }
        public IEnumerable<Attendance> Attendance { get; private set; }
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