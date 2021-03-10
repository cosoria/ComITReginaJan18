using System.Collections.Generic;

namespace ClassAttendanceDomain
{
    public class ApplicationUser
    {
        private readonly List<string> _roles = new List<string>();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
        public IReadOnlyList<string> Roles => _roles;

        public void AddRole(string role)
        {
            _roles.Add(role);
        }
    }
}