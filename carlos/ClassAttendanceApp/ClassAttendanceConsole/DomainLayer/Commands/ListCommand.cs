using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using DomainLayer.Contracts;
using DomainLayer.Entities;

namespace DomainLayer.Commands
{
    public class ListCommand : CommandBase
    {
        private IDatabase _database;

        public ListCommand(IDatabase database)
        {
            _database = database;
        }
        
        // list             : list all students on the course
        // list class       : list all classes in the course
        // list class <#>   : list topics for the # class 
        // list student <#> : list the student with id #
        // list student 15 
        
        public override CommandResult Execute()
        {
            if (string.IsNullOrWhiteSpace(_entityType))
            {
                _entityType = "student";
            }

            switch (_entityType)
            {
                case "student": 
                    ListStudent(_id); 
                    break;
                case "class": 
                    ListClass(_id);
                    break;
                case "course":
                    ListCourse(_id);
                    break;
                case "teacher":
                    ListTeacher(_id);
                    break;
                case "ta":
                    ListTeacherAssistant(_id);
                    break;
            }
            
            return CommandResult.OkResult();
        }

        private void ListTeacherAssistant(int id)
        {
            Console.Write(_database.GetCourse().TeacherAssistant.ToString());
        }

        private void ListTeacher(int id)
        {
            Console.Write(_database.GetCourse().Teacher.ToString());
        }
        
        private void ListCourse(int courseNumber)
        {
            Console.Write(_database.GetCourse().ToString());
        }

        private void ListClass(int classNumber)
        {
            if (classNumber > 0)
            {
                Console.Write(_database.GetClass(classNumber).ToString());
            }
            else
            {
                foreach (var c in _database.GetAllClasses())
                {
                    Console.WriteLine(c.ToString());
                }
                
            }
        }

        private void ListStudent(int studentNumber)
        {
            if (studentNumber > 0)
            {
                Console.WriteLine(_database.GetStudent(studentNumber).ToString());
            }
            else
            {
                foreach (var student in _database.GetAllStudents())
                {
                    Console.WriteLine(student.ToString());
                }
            }
        }
        
        public override string GetHelpText()
        {
            return
                @"      Overview: 
            Displays student, class and course summary and detail information
            enter the entity name after the list command for 
    
        Usage: 
            list <entity> <id>      
            <entity>: is one of 'student','class','course' default value is student
                <id>: is a number according to the entity range from 1 to max records
        
        Examples
            :> list                 : display all students on the course
            :> list class           : display all classes in the course     
            :> list class 3         : display topics for classes number 3
            :> list student         : display all students     
            :> list student 15      : display detail information for student with id 15     
            :> list course          : display course information 
";
        }
    }
}