using System;
using System.Collections.Generic;
using DomainLayer.Entities;

namespace DomainLayer.Contracts
{
    public interface IDatabase
    {
        Student GetStudent(int id);
        IEnumerable<Student> GetAllStudents();
        Class GetClass(int id);
        IEnumerable<Class> GetAllClasses();
        Course GetCourse();
    }
}