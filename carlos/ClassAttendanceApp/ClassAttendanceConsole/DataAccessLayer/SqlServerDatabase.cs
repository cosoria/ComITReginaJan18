﻿using DomainLayer.Contracts;
using DomainLayer.Entities;

namespace DataAccessLayer
{
    public class SqlServerDatabase : IDatabase
    {
        public Student GetStudent(int id)
        {
            throw new System.NotImplementedException();
        }

        public Student GetAllStudents()
        {
            throw new System.NotImplementedException();
        }

        public Class GetClass(int id)
        {
            throw new System.NotImplementedException();
        }

        public Class GetAllClasses()
        {
            throw new System.NotImplementedException();
        }

        public Course GetCourse()
        {
            throw new System.NotImplementedException();
        }
    }
}