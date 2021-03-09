using System;
using System.Collections.Generic;

namespace ClassAttendanceCommon.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllMatching(Predicate<T> condition);
        T GetOne(int id);
        void Update(T item);
        void Delete(int id);


    }
}