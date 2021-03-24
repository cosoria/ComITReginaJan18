using System;
using System.Collections.Generic;
using System.Linq;
using ClassAttendance.Common.Interfaces;
using ClassAttendance.Domain;

namespace ClassAttendance.Data.Repositories
{
    public abstract class InMemoryRepository<T> : IRepository<T> where T:IEntity
    {
        public IEnumerable<T> GetAll()
        {
            return GetItemsInternal();
        }

        public IEnumerable<T> GetAllMatching(Predicate<T> condition)
        {
            return GetItemsInternal().Where(s => condition(s)).ToArray();
        }

        public T GetOne(int id)
        {
            return GetItemsInternal().FirstOrDefault(s => s.Id == id);
        }

        public void Add(T item)
        {
            // var nextId = GetItemsInternal().Count + 1;
            // item.Id = nextId;
            GetItemsInternal().Add(item);
        }

        public void Update(T item)
        {
            var storedItem = GetOne(item.Id);

            if (storedItem == null)
            {
                throw new ArgumentException("Application user not found");
            }

            if (object.ReferenceEquals(item, storedItem))
            {
                return;
            }

            Delete(storedItem.Id);
            Add(item);
        }

        public void Delete(int id)
        {
            var item = GetOne(id);

            if (item == null)
            {
                throw new ArgumentException("Application user not found");
            }

            GetItemsInternal().Remove(item);
        }

        protected abstract IList<T> GetItemsInternal();
    }
}