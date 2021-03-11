using System.Collections.Generic;
using ClassAttendance.Domain;

namespace ClassAttendance.Common.Interfaces
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetLockedUsers();
    }
}