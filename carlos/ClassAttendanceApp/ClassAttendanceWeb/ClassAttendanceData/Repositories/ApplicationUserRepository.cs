using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using ClassAttendanceCommon.Interfaces;
using ClassAttendanceDomain;

namespace ClassAttendanceData.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        public IEnumerable<ApplicationUser> GetAll()
        {
            return _allUsers;
        }

        public IEnumerable<ApplicationUser> GetAllMatching(Predicate<ApplicationUser> condition)
        {
            return _allUsers.Where(u => condition(u)).ToArray();
        }

        public ApplicationUser GetOne(int id)
        {
            return _allUsers.FirstOrDefault(u => u.Id == id);
        }

        public void Update(ApplicationUser item)
        {
            var user = GetOne(item.Id);

            if (user == null)
            {
                throw new ArgumentException("Application user not found");
            }

            user.FirstName = item.FirstName;
            user.LastName = item.LastName;
            user.Email = item.Email;
            user.Language = item.Language;
            user.Password = item.Password;
        }

        public void Delete(int id)
        {
            var user = GetOne(id);

            if (user == null)
            {
                throw new ArgumentException("Application user not found");
            }

            _allUsers.Remove(user);
        }


        private static readonly List<ApplicationUser> _allUsers = new List<ApplicationUser>()
        {
            new ApplicationUser()
            {
                Id = 1, Password = "th3pa$$w0rd", FirstName = "Optimus", LastName = "Prime", Language = "Cybertronian", Email = "optimus@cybertron.com"
            },
            new ApplicationUser()
            {
                Id = 2, Password = "th3pa$$w0rd", FirstName = "Bumble", LastName = "Bee", Language = "Cybertronian", Email = "bumblebee@cybertron.com"
            },
            new ApplicationUser()
            {
                Id = 3, Password = "th3pa$$w0rd", FirstName = "Iron", LastName = "Hide", Language = "Cybertronian", Email = "ironhide@cybertron.com"
            },
            new ApplicationUser()
            {
                Id = 4, Password = "th3pa$$w0rd", FirstName = "Mega", LastName = "Tron", Language = "Cybertronian", Email = "megatron@cybertron.com"
            },
            new ApplicationUser()
            {
                Id = 5, Password = "th3pa$$w0rd", FirstName = "Shock", LastName = "Wave", Language = "Cybertronian", Email = "shockwave@cybertron.com"
            },
        };
    }

    
}