using System.Collections.Generic;
using Common.Interfaces;
using Domain;

namespace Data.Repositories
{
    public class StudentRepository : InMemoryRepository<Student>, IStudentRepository
    {
        protected override IList<Student> GetItemsInternal()
        {
            return _allStudents;
        }

        private static readonly List<Student> _allStudents = new List<Student>()
        {
            new Student(1,"Praise", "Koobee", 1, new []{ "C++" }),
            new Student(2,"Fazal", "Kamal", 0, new []{ "" }),
            new Student(3,"Justin", "Mathenson", 0, new []{ "" }),
            new Student(4,"Samuel", "Samuel", 1, new[] { "C#" }),
            new Student(5,"Mohamed", "Rezk", 0, new[] { "" }),
            new Student(6,"Eric", "Banigo", 0, new[] { "" }),
            new Student(7,"Kalpesh", "Kunvar", 1, new[] { "C#" }),
            new Student(8,"Dornubari", "Dumpe", 0, new[] { "" }),
            new Student(9,"Bilal", "Alissa", 2, new[] { "C#", "Python", "Javascript", "C", "C++" }),
            new Student(10,"Eman", "Badreldin", 1, new[] { "C#" }),
            new Student(11,"Enesoso", "Charles", 1, new[] { "C#", "Javascript" }),
            new Student(12,"Gayatri", "Kunvar", 1, new[] { "C#" }),
            new Student(13,"Doo-olo", "Agara", 1, new[] { "C++" }),
            new Student(14,"Shakirah", "Omotayo", 1, new[] { "" }),
            new Student(15,"Marmar", "Mojdehi", 1, new[] { "" }),
            new Student(16,"Marwa", "Hassan", 0, new[] { "" }),
            new Student(17,"Shivani", "Bhatt", 1, new[] { "" }),
            new Student(18,"Rajdeep", "Minhas", 2, new[] { "" }),
            new Student(19,"Avalyn", "Jessen", 2, new[] { "C#", "Java", "Python", "Javascript", "C", "SQL" }),
            new Student(20,"Andre", "Tichinski", 1, new[] { "" }),
            new Student(21,"Christopher", "Law", 1, new[] { "" }),
            new Student(22,"Kai", "Xiao", 1, new[] { "" }),
            new Student(23,"Nitin", "Bhagat", 1, new[] { "" }),
            new Student(24,"Samir", "Momin", 2, new[] { "" }),
        };

        
    }
}