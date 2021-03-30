using System.Collections.Generic;
using Domain;

namespace Common.Interfaces
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetLockedUsers();
    }
}