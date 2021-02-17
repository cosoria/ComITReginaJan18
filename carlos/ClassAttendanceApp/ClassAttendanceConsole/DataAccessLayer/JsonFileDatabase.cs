using System;
using System.Collections.Generic;
using DomainLayer.Contracts;
using DomainLayer.Entities;

namespace DataAccessLayer
{
    public class JsonFileDatabase : IDatabase
    {
        public Student GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Class GetClass(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Class> GetAllClasses()
        {
            throw new NotImplementedException();
        }

        public Course GetCourse()
        {
            throw new NotImplementedException();
        }
    }
}
