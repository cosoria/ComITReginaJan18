using System;
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

        public Student GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Class GetClass(int id)
        {
            throw new NotImplementedException();
        }

        public Class GetAllClasses()
        {
            throw new NotImplementedException();
        }

        public Class GetCourse()
        {
            throw new NotImplementedException();
        }
    }
}
