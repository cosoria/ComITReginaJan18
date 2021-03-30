using System.Collections.Generic;
using Common.Interfaces;
using Domain;

namespace Data.Repositories
{
    public class TeacherRepository : InMemoryRepository<Teacher>, ITeacherRepository
    {
        protected override IList<Teacher> GetItemsInternal()
        {
            return _allTeachers;
        }

        private static readonly List<Teacher> _allTeachers = new List<Teacher>()
        {
            new Teacher(1, "Carlos", "Osoria"),
            new Teacher(2, "Damian", "Jais")
        };
    }
}