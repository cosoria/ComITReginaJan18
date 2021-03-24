using System;
using System.Security.Claims;
using ClassAttendance.Domain;

namespace ClassAttendance.WebUI.Models
{
    public class HomeViewModel
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

        public HomeViewModel()
        {
            User = null;
        }

        public void PopulateFrom(ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                return;
            }

            var Id = Convert.ToInt32(principal.FindFirstValue(ClaimTypes.NameIdentifier));
            var email = principal.FindFirstValue(ClaimTypes.Email);
            var firstName = principal.FindFirstValue(ClaimTypes.GivenName);
            var lastName = principal.FindFirstValue(ClaimTypes.Surname);
            var Language = principal.FindFirstValue("Language");
            var password = "";


            User = new ApplicationUser(firstName, lastName, email, password);
            User.SetLanguage(Language);
        }
    }
}