using System;
using System.Security.Claims;
using ClassAttendanceDomain;

namespace ClassAttendanceWebUI.Models
{
    public class HomePageModel
    {
        public ApplicationUser User { get; set; }
        public bool Authenticated => User != null;

        public string FullUserName
        {
            get
            {
                if (Authenticated)
                {
                    return $"{User.FirstName} {User.LastName}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public HomePageModel()
        {
            User = null;
        }

        public void PopulateFrom(ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                return;
            }

            if (User == null)
            {
                User = new ApplicationUser();
            }

            User.Id = Convert.ToInt32(principal.FindFirstValue(ClaimTypes.NameIdentifier));
            User.Email = principal.FindFirstValue(ClaimTypes.Email);
            User.FirstName = principal.FindFirstValue(ClaimTypes.GivenName);
            User.LastName = principal.FindFirstValue(ClaimTypes.Surname);
            User.Language = principal.FindFirstValue("Language");
            User.Password = "";
        }
    }
}