using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KickTask.Models
{
    [MetadataType(typeof(AccountMetaData))]
    public partial class Account
    {
        public string ConfirmPassword { get; set; }

        public long OpenTasks { get; set; }

        public long ClosedTasks { get; set; }
    }

    public class AccountMetaData
    {
        [Display(Name = "Full Name*")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "Fullname is required")]
        public string Fullname { get; set; }

        [Display(Name = "Username*")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Display(Name = "Email*")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Display(Name = "Password*")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage ="Minimum 6 characters required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "AgreedPolicy*")]    
        public bool AgreedPolicy { get; set; }
    }
}