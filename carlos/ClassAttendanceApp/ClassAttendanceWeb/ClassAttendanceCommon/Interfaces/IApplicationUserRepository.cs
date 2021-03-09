using System.Collections.Generic;
using System.Xml;
using ClassAttendanceDomain;

namespace ClassAttendanceCommon.Interfaces
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetLockedUsers();
    }
}