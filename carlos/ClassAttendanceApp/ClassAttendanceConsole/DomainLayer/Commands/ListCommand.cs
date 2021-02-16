using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DomainLayer.Entities;

namespace DomainLayer.Commands
{
    public class ListCommand : ICommand
    {
        private string _action = "";
        private int _id = -1;


        // list             : list all students on the course
        // list class       : list all classes in the course
        // list class <#>   : list topics for the # class 
        // list student <#> : list the student with id #
        // list student 15 
        public void Init(string[] commandParameters)
        {
            if (string.Equals(commandParameters[1],"student"))
            {
                _action = "student";
            }

            if (string.Equals(commandParameters[1], "class"))
            {
                _action = "class";
            }
            
            if (string.IsNullOrWhiteSpace(commandParameters[2]))
            {
                try
                {
                    _id = int.Parse(commandParameters[2]);
                }
                catch
                {
                    _id = -1;
                }
            }
        }

        public string GetHelpText()
        {
            return
@"      Usage: 
            list             : list all students on the course
            list class       : list all classes in the course 
            list class <#>   : list topics for the # class 
            list student <#> : list the student with id #
";
        }

        public CommandResult Execute()
        {
            return CommandResult.OkResult();
        }

        private void ListAllStudents()
        {
            var allStudents = GetAllStudents();

            foreach (var student in allStudents)
            {
                Console.WriteLine("FirstName:" + student.FirstName + " LastName:" + student.LastName);
            }
        }

        private IEnumerable<Student> GetAllStudents()
        {
            return Enumerable.Empty<Student>();
        }
    }
}