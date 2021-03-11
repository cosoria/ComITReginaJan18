using System.Collections.Generic;
using ClassAttendance.Domain;

namespace ClassAttendance.WebUI.Models
{
    public class SecretModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}