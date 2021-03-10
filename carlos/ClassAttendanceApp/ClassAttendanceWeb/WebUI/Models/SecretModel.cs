using System.Collections.Generic;
using ClassAttendanceDomain;

namespace ClassAttendanceWebUI.Models
{
    public class SecretModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}