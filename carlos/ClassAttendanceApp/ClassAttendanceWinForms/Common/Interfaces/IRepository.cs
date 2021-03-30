using System;
using System.Collections.Generic;
using Domain;

namespace Common.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllMatching(Predicate<T> condition);
        T GetOne(int id);

        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}