using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DomainLayer;
using DomainLayer.Contracts;
using DomainLayer.Entities;

namespace DataAccessLayer
{
    public class InMemoryDatabase : IDatabase
    {
        private Course _course;

        public InMemoryDatabase()
        {
            Init();
        }
        
        public Student GetStudent(int id)
        {
            return _course.Students.Skip(id - 1).Take(1).First();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _course.Students;
        }

        public Class GetClass(int id)
        {
            return _course.Classes.Skip(id - 1).Take(1).First();
        }

        public IEnumerable<Class> GetAllClasses()
        {
            return _course.Classes;
        }

        public Course GetCourse()
        {
            return _course;
        }

        private void Init()
        {
            SystemTime.SetClock(() => new DateTime(2021,01,01));

            _course = new Course(".NET Core Programming", new DateTime(2021, 01, 18), 100);
            _course.SetTeacher(new Teacher("Carlos", "Osoria", ".NET Framework Stack"));
            _course.SetTeacherAssistant(new TeacherAssistant("Damian", "Jais", ".NET Framework Stack"));
            
            RegisterStudents();
            CreateClasses();

            SystemTime.ResetClock();
        }

        private void RegisterStudents()
        {
            _course.RegisterStudent(new Student("Praise", "Koobee", 1, new []{ "C++" }));
            _course.RegisterStudent(new Student("Fazal", "Kamal", 0, new []{ "" }));
            _course.RegisterStudent(new Student("Justin", "Mathenson", 0, new []{ "" }));
            _course.RegisterStudent(new Student("Samuel", "Samuel", 1, new []{ "C#" }));
            _course.RegisterStudent(new Student("Mohamed", "Rezk", 0, new []{ "" }));
            _course.RegisterStudent(new Student("Eric", "Banigo", 0, new []{ "" }));
            _course.RegisterStudent(new Student("Kalpesh", "Kunvar", 1, new []{ "C#" }));
            _course.RegisterStudent(new Student("Dornubari", "Dumpe", 0, new []{ "" }));
            _course.RegisterStudent(new Student("Bilal", "Alissa", 2, new []{ "C#", "Python", "Javascript", "C", "C++" }));
            _course.RegisterStudent(new Student("Eman", "Badreldin", 1, new []{ "C#" }));
            _course.RegisterStudent(new Student("Enesoso", "Charles", 1, new []{ "C#", "Javascript" }));
            _course.RegisterStudent(new Student("Gayatri", "Kunvar", 1, new []{ "C#" }));
            _course.RegisterStudent(new Student("Doo-olo", "Agara", 1, new []{ "C++" }));
            _course.RegisterStudent(new Student("Shakirah", "Omotayo", 1, new []{ "" }));
            _course.RegisterStudent(new Student("Marmar", "Mojdehi", 1, new []{ "" }));
            _course.RegisterStudent(new Student("Marwa", "Hassan", 0, new []{ "" }));
            _course.RegisterStudent(new Student("Shivani", "Bhatt", 1, new []{ "" }));
            _course.RegisterStudent(new Student("Rajdeep", "Minhas", 2, new []{ "" }));
            _course.RegisterStudent(new Student("Avalyn", "Jessen", 2, new []{ "C#", "Java", "Python", "Javascript", "C", "SQL" }));
            _course.RegisterStudent(new Student("Andre", "Tichinski", 1, new []{ "" }));
            _course.RegisterStudent(new Student("Christopher", "Law", 1, new []{ "" }));
            _course.RegisterStudent(new Student("Kai", "Xiao", 1, new []{ "" }));
            _course.RegisterStudent(new Student("Nitin", "Bhagat", 1, new []{ "" }));
            _course.RegisterStudent(new Student("Samir", "Momin", 2, new []{ "" }));
        }

        private void CreateClasses()
        {
            for (var i = 1; i <= 30; i++)
            {
                var startDate = GetStartDateForClass(i);
                _course.AddClass(new Class($"Class #{i}", startDate, new []{new Topic($".NET Core Topic #{i}", 100)}, _course));
            }
        }

        private DateTime GetStartDateForClass(int classIndex)
        {
            var weekNumber = (classIndex - 1) / 3;
            var classWeekIndex = (classIndex - 1) % 3;
            var dateCorrection = classWeekIndex * 2;

            return _course.StartDate.AddDays(weekNumber * 7).AddDays(dateCorrection);
        }
    }
}