using System.Collections.Generic;
using DomainLayer.Contracts;
using DomainLayer.Entities;

namespace DataAccessLayer
{
    public class SqliteDatabase : IDatabase
    {
        public Student GetStudent(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            throw new System.NotImplementedException();
        }

        public Class GetClass(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Class> GetAllClasses()
        {
            throw new System.NotImplementedException();
        }

        public Course GetCourse()
        {
            throw new System.NotImplementedException();
        }
    }
}