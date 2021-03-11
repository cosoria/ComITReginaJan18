using System.Collections.Generic;
using ClassAttendance.Domain;

namespace ClassAttendance.WebUI.Models
{
    public class SecretViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}