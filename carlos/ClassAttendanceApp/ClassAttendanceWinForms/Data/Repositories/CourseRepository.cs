using System;
using System.Collections.Generic;
using Common.Interfaces;
using Domain;

namespace Data.Repositories
{
    public class CourseRepository : InMemoryRepository<Course>, ICourseRepository
    {
        protected override IList<Course> GetItemsInternal()
        {
            return _allCourses;
        }
        
        private static readonly List<Course> _allCourses = new List<Course>()
        {
            new Course(1, "Introduction to .NET Core", new DateTime(2021,01,18), 100),
            new Course(2, ".NET Core Advanced Topic", new DateTime(2021,04,01), 200),
            new Course(3, "C# In Depth", new DateTime(2021,02,15), 200)
        };
    }
}