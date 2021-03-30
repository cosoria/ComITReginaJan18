using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using ClassAttendance.Data;
using ClassAttendance.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClassAttendance.DbTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Class Attendance Database Tool");

            EnsureDb();
            SeedData();

            // CreateAdmin();
            // CreateUser();
            // CreateTransformer();
            // CreateUserThatWillBeDeleted();

            // UpdateUser();
            // DeleteUser();

            DisplayAll();
        }

        

        private static void CreateUserThatWillBeDeleted()
        {
            using (var context = new ClassAttendanceDbContext())
            {
                var user = new ApplicationUser("DeleteMe", "WhenYouGetAChance", "nobody@comit.com", "password");

                user.SetRole(ApplicationUserRole.User);
                user.SetLanguage("English");

                context.Entry(ApplicationUserRole.User).State = EntityState.Unchanged;

                context.Users.Add(user);

                context.SaveChanges();
            }
        }

        private static void EnsureDb()
        {
            using (var context = new ClassAttendanceDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        private static void UpdateUser()
        {
            using (var context = new ClassAttendanceDbContext())
            {

                var user = context
                    .Users
                    .FirstOrDefault(u => u.FirstName == "Optimus" && u.LastName == "Prime");

                if (user != null)
                {
                    user.ChangeName(user.FirstName, "The Prime");
                    context.SaveChanges();
                    Console.WriteLine("User has been updated");
                }
                else
                {
                    Console.WriteLine("User not found");
                }
            }
        }

        private static void DeleteUser()
        {
            using (var context = new ClassAttendanceDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.FirstName == "DeleteMe");
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        private static void CreateTransformer()
        {
            
            using (var context = new ClassAttendanceDbContext())
            {
                if (context.Users.FirstOrDefault(u => u.Email == "optimus@cybertron.com") != null)
                {
                    return;
                }
                
                var transformerRole = context.Roles.FirstOrDefault(r => r.Role == "Transformer");

                var transformer = new ApplicationUser("Optimus", "Prime", "optimus@cybertron.com", "password");
                transformer.SetLanguage("Cybertronian");
                transformer.SetRole(transformerRole);

                context.Users.Add(transformer);
                context.SaveChanges();

                Console.WriteLine("Transformer created");
            }
        }

        private static void CreateUser()
        {
            using (var context = new ClassAttendanceDbContext())
            {
                if (context.Users.FirstOrDefault(u => u.Email == "carlos@comit.com") != null)
                {
                    return;
                }

                var userRole = context.Roles.First(r => r.Role == "User");
                var user = new ApplicationUser("Carlos", "Osoria", "carlos@comit.com", "password");
                
                user.SetLanguage("Spanish");
                user.SetRole(userRole);

                context.Users.Add(user);
                context.SaveChanges();

                Console.WriteLine("User created");
            }
        }
        
        private static void CreateAdmin()
        {
            using (var context = new ClassAttendanceDbContext())
            {
                if (context.Users.FirstOrDefault(a => a.Email == "admin@comit.com") != null)
                {
                    return;
                }

                var role = context.Roles.First(r => r.Role == "Admin");

                var admin = new ApplicationUser("Admin", "ComIT", "admin@comit.com", "password");
                admin.SetLanguage("English");
                admin.SetRole(role);

                context.Users.Add(admin);
                context.SaveChanges();

                Console.WriteLine("Admin created");
            }
        }

        private static void DisplayAll()
        {
            using (var context = new ClassAttendanceDbContext())
            {
                var users = context
                    .Users
                    // .Include(u => u.Role)
                    .ToArray();

                foreach (var user in users)
                {
                    Console.WriteLine(user.ToString());
                }

                var studentCourse = context.StudentCourses.Where(sc => EF.Functions.Like(sc.LastName, "%ar%")).ToArray();

                foreach (var sc in studentCourse)
                {
                    Console.WriteLine($" {sc.FirstName} {sc.LastName} {sc.Title} {sc.StartDate}");
                }
                /*

                var courses = context.Courses
                    .Where(c => c.Students.Where(s => s.LastName.Length > 4).Any())
                    .Where(c => c.Classes.Where(c => c.Topics.Any()).Any())
                    .Select(c => new  { c.Title, c.StartDate, c.Classes.Aggregate(),  })

                var teacher = context.Teachers.Where(t => t.LastName == "Jais").Select( t => new { t.Experience });

                var courses = context.Courses.Where(c => c.Teacher.FirstName == "Carlos").ToList();

                var classesWithTopics = context
                    .Courses
                    .Where(c => c.Title.Contains("C#"))
                    .Select(c => c.Classes)
                    .SelectMany(c => c.Select( c => c.Topics));
                */
                // var coursesWhereStudentKnow = context.Courses.Where(c => c.Students.Where(s => s.Languages.Contains("C#")).Count() > 1).ToList();
            }
        }
        
        private static void SeedData()
        {
            /*
                DELETE FROM [Users]
                DELETE FROM [Roles]
                DELETE FROM [Topics]
                DELETE FROM [Classes]
                DELETE FROM [Students]
                DELETE FROM [Courses]
                DELETE FROM [Teachers]

                DBCC CHECKIDENT ('Users', RESEED, 0)
                DBCC CHECKIDENT ('Roles', RESEED, 0)
                DBCC CHECKIDENT ('Topics', RESEED, 0)
                DBCC CHECKIDENT ('Classes', RESEED, 0)
                DBCC CHECKIDENT ('Teachers', RESEED, 0)
                DBCC CHECKIDENT ('Students', RESEED, 0)
                DBCC CHECKIDENT ('Courses', RESEED, 0)
             */

            SystemTime.SetClock(() => new DateTime(2021, 1, 1));

            using (var context = new ClassAttendanceDbContext())
            {
                var adminRole = new ApplicationUserRole("Admin");
                var userRole = new ApplicationUserRole("User");
                var transformerRole = new ApplicationUserRole("Transformer");

                if (context.Roles.Count() == 0)
                {
                    context.Roles.AddRange(new[]
                    {
                        adminRole,
                        userRole,
                        transformerRole,
                    });
                }

                if (context.Users.Count() == 0)
                {
                    var admin = new ApplicationUser("Admin", "ComIT", "admin@comit.com", "password");
                    admin.SetRole(adminRole);
                    admin.SetLanguage("English");
                    
                    var user = new ApplicationUser("User", "ComIT", "user@comit.com", "password");
                    user.SetRole(userRole);
                    user.SetLanguage("English");
                    
                    var robot = new ApplicationUser("Robot", "ComIT", "robot@comit.com", "password");
                    robot.SetRole(transformerRole);
                    robot.SetLanguage("Cybertronian");

                    context.Users.AddRange(new[]
                    {
                        admin,
                        user,
                        robot,
                    });
                }

                var students = new List<Student>();
                if (context.Students.Count() == 0)
                {
                    students.AddRange(AddStudents(context));
                }

                var carlos = new Teacher("Carlos", "Osoria");
                carlos.SetExperience("Masters Degree");

                var damian = new Teacher("Damian", "Jais");
                damian.SetExperience("University Degree");

                if (context.Teachers.Count() == 0)
                {
                    context.Teachers.AddRange(new[]
                    {
                        carlos,
                        damian,
                        new Teacher("Bill", "Gate"),
                        new Teacher("Steve", "Jobs"),
                    });
                }
                
                if (context.Courses.Count() == 0)
                {
                    var netCoreStartDate = new DateTime(2021, 02, 01);
                    var netCore = new Course("Introduction to .NET Core", new DateTime(2021, 02, 01), 100);
                    netCore.SetTeacher(carlos);
                    netCore.SetTeacherAssistant(damian);
                    
                    netCore.AddClass(new Class("Intro", netCoreStartDate, new[] { new Topic("Intro", 100), new Topic("Materials", 100), new Topic("Review", 100) }, netCore));
                    netCore.AddClass(new Class("C# Intro", netCoreStartDate.AddDays(2), new[] { new Topic("Intro", 100), new Topic("Materials", 100), new Topic("Review", 100) }, netCore));
                    netCore.AddClass(new Class("ASP.NET Intro", netCoreStartDate.AddDays(4), new[] { new Topic("Intro", 100), new Topic("Materials", 100), new Topic("Review", 100) }, netCore));
                    netCore.AddClass(new Class("ASP.NET WebApi Intro", netCoreStartDate.AddDays(4), new[] { new Topic("Intro", 100), new Topic("Materials", 100), new Topic("Review", 100) }, netCore));
                    netCore.AddClass(new Class("EF Core Intro", netCoreStartDate.AddDays(6), new[] { new Topic("Intro", 100), new Topic("Materials", 100), new Topic("Review", 100) }, netCore));
                    netCore.AddClass(new Class("Windows Forms Intro", netCoreStartDate.AddDays(8), new[] { new Topic("Intro", 100), new Topic("Materials", 100), new Topic("Review", 100) }, netCore));
                    netCore.AddClass(new Class("Xamarin Intro", netCoreStartDate.AddDays(10), new[] { new Topic("Intro", 100), new Topic("Materials", 100), new Topic("Review", 100) }, netCore));
                    netCore.AddClass(new Class("WPF Intro", netCoreStartDate.AddDays(12), new[] { new Topic("Intro", 100), new Topic("Materials", 100), new Topic("Review", 100) }, netCore));
                    netCore.AddClass(new Class("Azure Intro", netCoreStartDate.AddDays(14), new[] { new Topic("Intro", 100), new Topic("Materials", 100), new Topic("Review", 100) }, netCore));
                    
                    // Register all students
                    foreach (var student in students)
                    {
                        netCore.RegisterStudent(student);
                    }
                    
                    var cSharpStartDate = new DateTime(2021, 04, 01);
                    var cSharpInDepth = new Course(".NET Core Advanced Topic", cSharpStartDate, 200);
                    cSharpInDepth.SetTeacher(carlos);
                    cSharpInDepth.SetTeacherAssistant(damian);

                    cSharpInDepth.AddClass(new Class("Intro", cSharpStartDate, new[] { new Topic("Intro", 200), new Topic("Materials", 200), new Topic("Review", 200) }, cSharpInDepth));
                    cSharpInDepth.AddClass(new Class("C# Intro", cSharpStartDate.AddDays(2), new[] { new Topic("Intro", 200), new Topic("Materials", 200), new Topic("Review", 200) }, cSharpInDepth));
                    cSharpInDepth.AddClass(new Class("C# Types", cSharpStartDate.AddDays(4), new[] { new Topic("Intro", 200), new Topic("Materials", 100), new Topic("Review", 200) }, cSharpInDepth));
                    cSharpInDepth.AddClass(new Class("C# Object Oriented Programming", cSharpStartDate.AddDays(4), new[] { new Topic("Intro", 200), new Topic("Materials", 200), new Topic("Review", 200) }, cSharpInDepth));
                    cSharpInDepth.AddClass(new Class("C# LINQ", cSharpStartDate.AddDays(6), new[] { new Topic("Intro", 200), new Topic("Materials", 200), new Topic("Review", 200) }, cSharpInDepth));
                    cSharpInDepth.AddClass(new Class("C# and SOLID", cSharpStartDate.AddDays(8), new[] { new Topic("Intro", 200), new Topic("Materials", 200), new Topic("Review", 200) }, cSharpInDepth));

                    context.Courses.AddRange(new[]
                    {
                        netCore,
                        cSharpInDepth,
                    });
                }
                
                context.SaveChanges();
            }

            SystemTime.ResetClock();
        }

        private static List<Student> AddStudents(ClassAttendanceDbContext context)
        {
            var allStudents = new List<Student>()
            {
                new Student("Praise", "Koobee", 1, new []{ "C++" }),
                new Student("Fazal", "Kamal", 0, new []{ "" }),
                new Student("Justin", "Mathenson", 0, new []{ "" }),
                new Student("Samuel", "Samuel", 1, new[] { "C#" }),
                new Student("Mohamed", "Rezk", 0, new[] { "" }),
                new Student("Eric", "Banigo", 0, new[] { "" }),
                new Student("Kalpesh", "Kunvar", 1, new[] { "C#" }),
                new Student("Dornubari", "Dumpe", 0, new[] { "" }),
                new Student("Bilal", "Alissa", 2, new[] { "C#", "Python", "Javascript", "C", "C++" }),
                new Student("Eman", "Badreldin", 1, new[] { "C#" }),
                new Student("Enesoso", "Charles", 1, new[] { "C#", "Javascript" }),
                new Student("Gayatri", "Kunvar", 1, new[] { "C#" }),
                new Student("Doo-olo", "Agara", 1, new[] { "C++" }),
                new Student("Shakirah", "Omotayo", 1, new[] { "" }),
                new Student("Marmar", "Mojdehi", 1, new[] { "" }),
                new Student("Marwa", "Hassan", 0, new[] { "" }),
                new Student("Shivani", "Bhatt", 1, new[] { "" }),
                new Student("Rajdeep", "Minhas", 2, new[] { "" }),
                new Student("Avalyn", "Jessen", 2, new[] { "C#", "Java", "Python", "Javascript", "C", "SQL" }),
                new Student("Andre", "Tichinski", 1, new[] { "" }),
                new Student("Christopher", "Law", 1, new[] { "" }),
                new Student("Kai", "Xiao", 1, new[] { "" }),
                new Student("Nitin", "Bhagat", 1, new[] { "" }),
                new Student("Samir", "Momin", 2, new[] { "C#","Java","Javascript" }),
            };

            context.Students.AddRange(allStudents);

            return allStudents;
        }

        private void CreateTransformers()
        {
            using (var context = new ClassAttendanceDbContext())
            {
                var transformerRole = context.Roles.FirstOrDefault(r => r.Role == "Transformer");

                foreach (var transformer in _transformers)
                {
                    transformer.SetRole(transformerRole);
                    context.Users.Add(transformer);
                }

                context.SaveChanges();
            }
        }

        private readonly List<ApplicationUser> _transformers = new List<ApplicationUser>()
        {
            /*
            new ApplicationUser()
            {
                Id = 0, 
                Password = "password", 
                FirstName = "Bumble", 
                LastName = "Bee", 
                Language = "Cybertronian", 
                Email = "bumblebee@cybertron.com"
            },
            new ApplicationUser()
            {
                Id = 0, 
                Password = "password", 
                FirstName = "Iron", 
                LastName = "Hide", 
                Language = "Cybertronian", 
                Email = "ironhide@cybertron.com"
            },
            new ApplicationUser()
            {
                Id = 0, 
                Password = "password", 
                FirstName = "Mega", 
                LastName = "Tron", 
                Language = "Cybertronian", 
                Email = "megatron@cybertron.com"
            },
            new ApplicationUser()
            {
                Id = 0, 
                Password = "password", 
                FirstName = "Shock", 
                LastName = "Wave", 
                Language = "Cybertronian", 
                Email = "shockwave@cybertron.com",
            }
            */
        };
    }
}
