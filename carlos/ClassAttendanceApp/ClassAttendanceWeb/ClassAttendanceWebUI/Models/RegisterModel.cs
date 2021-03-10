﻿using System.ComponentModel.DataAnnotations;
using ClassAttendanceDomain;

namespace ClassAttendanceWebUI.Models
{
    public class RegisterModel
    {
        [Display(Name = "Email Address")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(EMAIL_REGEX, ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Display(Name = "Preferred Language")]
        [StringLength(50)]
        public string Language { get; set; }

        public string Error { get; set; }
        public bool Failed => !string.IsNullOrWhiteSpace(Error);

        private const string EMAIL_REGEX = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
    }

    public static class RegisterModelExtensions
    {
        public static ApplicationUser ToApplicationUser(this RegisterModel model)
        {
            return new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Language = model.Language,
                Password = model.Password
            };
        }
    }
}